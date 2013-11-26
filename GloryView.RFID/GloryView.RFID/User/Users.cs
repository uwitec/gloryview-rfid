using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication2;
using MySql.Data.MySqlClient;
using GloryView.RFID.Utilities;
using System.Security.Cryptography;
using System.Data;
using System.ComponentModel;
using GloryView.RFID.UserManager.IU;

namespace GloryView.RFID.User
{
    class Users : BaseRequest
    {
        private MySqlDataReader reade;
        private MySqlParameter parameter = new MySqlParameter();
        //用户登陆功能
        public int userLogin(string account,string password )
        {
            try
            {
                string sql = "select * from users as u where u.ACCOUNT='" + @account + "'";
                
                parameter.ParameterName = "@account";
                parameter.Value = account;
                reade = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text,sql, parameter);
                if (reade.Read() == false) return ERROR;
                string passwordStr = Session.MD5Encrypt(password);
                if (!passwordStr.Equals(reade["PASSWORD"])) return ERROR;
                Session.UserAccount = account;
                Session.UserId = (int)reade["ID"];
                Console.WriteLine(reade["TYPE"]);
                Session.UserType = (int)reade["TYPE"];
                Session.LoginTime = Convert.ToDateTime(reade["LOGIN_TIME"]).ToString("yyyy-MM-dd hh:mm:ss");
                //登陆成功后更新最近登陆时间
                DateTime loginTime = Convert.ToDateTime(DateTime.Now); //yyyy-MM-dd hh:mm:ss
                string updateSql = "update users as u set u.LOGIN_TIME='" + @loginTime + "' where u.ID=" + @Session.UserId;
                MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@loginTime",loginTime),
                        new MySqlParameter("@Session.UserId",Session.UserId),
                     };
                parameter.ParameterName = "@loginTime";
                parameter.Value = loginTime.ToString("yyyy-MM-dd hh:mm:ss");
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, updateSql, parameter);
                string logSql = "insert into users_log(USER_ID,LOGIN_TIME) values(" + @Session.UserId + ",'" + @loginTime + "')";
                Session.LogId = MySqlHelper.ExecuteNonQueryId(MySqlHelper.Conn, CommandType.Text, logSql,parameters);
                TimeEvent exitTime = new TimeEvent(Session.LogId);
                AlarmClass alarm = new AlarmClass();
                exitTime.TimerRun();
                alarm.TimerRun();
            }catch(Exception e){
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
            return SUCCESS;
        }
        //管理员创建用户
        public int registUser(UserBean bean)
        {

            try
            {
                string selectSql = "select * from users as u where u.ACCOUNT='" + @bean.Account + "'";
                reade = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text,selectSql, new MySqlParameter("@bean.Account", bean.Account));
                if (reade.Read()) return HAS;
                string pawMd = Session.MD5Encrypt(bean.Password);
                string sql = "insert into users(ACCOUNT,USER_NAME,TYPE,PASSWORD,STATUS,CREATE_ID,CREATE_TIME,PHONE) values('" +
                            @bean.Account + "','" + @bean.UserName + "'," + @bean.Type + ",'" + @pawMd + "'," + @bean.Status + "," +
                            @bean.CreateId + ",'" + @bean.CreateTime + "','"+@bean.Phone+"')";
                MySqlParameter[] parameter = 
            {
                new MySqlParameter("@bean.Account",bean.Account),
                new MySqlParameter("@bean.UserName",bean.UserName),
                new MySqlParameter("@bean.Type",bean.Type),
                new MySqlParameter("@pawMd",pawMd),
                new MySqlParameter("@bean.Status",bean.Status),
                new MySqlParameter("@bean.CreateId",bean.CreateId),
                new MySqlParameter("@bean.CreateTime",bean.CreateTime.ToString("yyyy-MM-dd hh:mm:ss")),
                 new MySqlParameter("@bean.Phone",bean.Phone),
            };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text,sql, parameter);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
            return SUCCESS;
        }
        //用户密码修改
        public int ChangeUserPassword(string oldPassword,string password)
        {
            try
            {
                string sql = "select * from users u where u.ID=" + @Session.UserId;
                reade = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text,sql, new MySqlParameter("@Session.UserId", Session.UserId));
                string passwordStr = Session.MD5Encrypt(oldPassword);
                if (reade.Read())
                {
                    if (!passwordStr.Equals(reade["PASSWORD"])) return PASSWORD_ERROR;
                    string updateTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss");
                    string newPaw = Session.MD5Encrypt(password);
                    string updateSql = "update users as u set u.PASSWORD='" + @newPaw + "',u.UPDATE_TIME='"
                                        + @updateTime + "' where u.ID=" + @Session.UserId;
                    MySqlParameter[] parameters =
                {
                    new MySqlParameter("@newPaw",newPaw),
                    new MySqlParameter("@updateTime",updateTime),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                 };
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, updateSql, parameters);
                }
                return SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
        }
        //用户分页列表
        public DataSet getUsersList(QueryUser query)
        {
            try
            {
                //int count = (BaseRequest.PAGE_CURRENT - 1) * BaseRequest.PAGE_SIZE;
                string sql = "SELECT u.ID,u.ACCOUNT,u.USER_NAME,u.TYPE,u.STATUS,us.USER_NAME as NAME,u.LOGIN_TIME,"
                           + "u.PHONE FROM users AS u LEFT JOIN users AS us ON u.CREATE_ID=us.ID  where u.ACCOUNT like '%"
                           + @query.Account + "%' and u.USER_NAME like '%" + query.UserName + "%' ORDER BY u.CREATE_TIME DESC";
             
                //string sqlAppend = SqlApend.returnSqlStr(sql,SqlApend.SqlMap);
                DataSet set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
                return set;
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
       //用户查找
        public MySqlDataReader queryUser(int userId)
        {
            try
            {
                string sql = "SELECT u.ID,u.USER_NAME,u.ACCOUNT,u.TYPE,u.STATUS,u.PHONE,usr.USER_NAME AS CREATE_USER,us.USER_NAME AS UPDATE_USER," +
                             "u.LOGIN_TIME,u.UPDATE_TIME,u.CREATE_TIME FROM users AS u LEFT JOIN users AS us ON "+
                              "u.ID=us.UPDATE_USER_ID LEFT JOIN users AS usr ON u.CREATE_ID=usr.ID WHERE u.ID=" + @userId;
                return reade = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql, new MySqlParameter("@userId", userId));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        public int saveUserEdit(UserBean bean)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "UPDATE users AS u SET u.USER_NAME='" + @bean.UserName + "',u.TYPE=" + @bean.Type + ",u.PHONE='" +
                    @bean.Phone + "', STATUS=" + @bean.Status+ ",UPDATE_USER_ID=" + @Session.UserId + ",UPDATE_TIME='" + @date + "' where u.ID=" + @bean.Id;
                MySqlParameter[] parameters ={
                                                 new MySqlParameter("@bean.UserName",bean.UserName),
                                                 new MySqlParameter("@bean.Type",bean.Type),
                                                 new MySqlParameter("@bean.Phone",bean.Phone),
                                                 new MySqlParameter("@bean.Status",bean.Status),
                                                 new MySqlParameter("@Session.UserId",Session.UserId),
                                                 new MySqlParameter("@date",date),
                                                 new MySqlParameter("@bean.Id",bean.Id),
                                            };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return SUCCESS;
            }catch(Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
        }
        //用户登录日记
        public DataSet getUserLoginLog()
        {
            try
            {
                string sql = "SELECT ul.ID, u.ACCOUNT,u.USER_NAME,u.TYPE,ul.LOGIN_TIME,ul.EXIT_TIME,u.CREATE_TIME "+
                    "FROM users_log AS ul LEFT JOIN users AS u ON ul.USER_ID=u.ID ORDER BY ul.LOGIN_TIME DESC ";
               return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
                
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}
