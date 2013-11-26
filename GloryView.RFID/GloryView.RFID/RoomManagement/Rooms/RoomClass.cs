using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloryView.RFID.Utilities;
using MySql.Data.MySqlClient;
using System.Data;

namespace GloryView.RFID.RoomManagement.Rooms
{
    class RoomClass : BaseRequest
    {
        private MySqlDataReader reade;
        private MySqlParameter parameter = new MySqlParameter();
        //添加机房
        public int AddRoom(RoomBean bean)
        {
            try
            {
                string selectSql="SELECT * FROM rooms AS r WHERE r.ROOM_NAME='"+@bean.RoomName+"'";
                parameter.ParameterName="@bean.RoomName";
                parameter.Value=bean.RoomName;
                reade=MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text,selectSql, parameter);
                if(reade.Read()) return HAS;
                string dateTime = Convert.ToDateTime(DateTime.Now).ToString(DATE_MS_FORMAT);
                string sql = "INSERT INTO rooms (ROOM_NAME,FLOOR,BELONGS,PURPOSE,USERS_ID,CREATION_DATE) VALUES('"+
                             @bean.RoomName+"','"+@bean.Floor+"','"+@bean.Belongs+"','"+@bean.Purpose+"',"+@Session.UserId+",'"+
                             @dateTime+"')";
                MySqlParameter[] parameters =
                    {
                        new MySqlParameter("@bean.RoomName",bean.RoomName),
                        new MySqlParameter("@bean.Floor",bean.Floor),
                        new MySqlParameter("@bean.Belongs",bean.Belongs),
                        new MySqlParameter("@bean.Purpose",bean.Purpose),
                        new MySqlParameter("@Session.UserId",Session.UserId),
                        new MySqlParameter("@dateTime",dateTime),
                     };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
        }
        //机房列表
        public DataSet queryRoomsList()
        {
            try
            {
                string sql = "SELECT r.ID,r.ROOM_NAME,r.FLOOR,r.BELONGS,r.PURPOSE,r.CREATION_DATE,u.USER_NAME FROM "+
                            "rooms AS r LEFT JOIN users AS u ON r.USERS_ID=u.ID";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //查询机房信息
        public MySqlDataReader EditRooms(int id)
        {
            try
            {
                string sql = "SELECT r.ID,r.ROOM_NAME,r.FLOOR,r.BELONGS,r.PURPOSE,r.CREATION_DATE,u.USER_NAME FROM rooms AS"
                             +" r LEFT JOIN users AS u ON r.USERS_ID=u.ID WHERE r.ID=" + @id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql, new MySqlParameter("@id", id));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //编辑机房信息
        public int saveEditRoom(RoomBean bean)
        {
            try
            {
                string sql = "UPDATE rooms AS r SET r.ROOM_NAME='" + @bean.RoomName + "',r.FLOOR='" + @bean.Floor
                            + "',r.PURPOSE='" + @bean.Purpose + "',r.BELONGS='" + @bean.Belongs + "' WHERE r.ID=" + @bean.Id;
                MySqlParameter[] parameters=
                {
                    new MySqlParameter("@bean.RoomName",bean.RoomName),
                    new MySqlParameter("@bean.Floor",bean.Floor),
                    new MySqlParameter("@bean.Purpose",bean.Purpose),
                    new MySqlParameter("@bean.Belongs",bean.Belongs),
                    new MySqlParameter("@bean.Id",bean.Id),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
            
        }
        //前台机房管理只树状显示
        public MySqlDataReader queryRoomsName()
        {
            try
            {
                string sql = "SELECT ID,ROOM_NAME FROM rooms";
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //添加设备类别
        public int addType(string typeName)
        {
            try{
                string seletSql = "SELECT * FROM device_class AS dc WHERE dc.TYPE_NAME='"+@typeName+"'";
                reade= MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, seletSql);
                if (reade.Read()) return HAS;
                string dateTime = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "INSERT INTO device_class(TYPE_NAME,CREATE_USER_ID,CREATE_TIME) VALUES('" + @typeName + "',"+
                             @Session.UserId + ",'" + @dateTime + "')";
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@typeName",typeName),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@dateTime",dateTime),
                 };
                MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql,parameters);
                return SUCCESS;
            }catch(Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
        }
        //设备类别列表
        public DataSet queryType()
        {
            try
            {
                string sql = "SELECT dc.ID,dc.TYPE_NAME,u.USER_NAME AS CREATE_USER,us.USER_NAME AS EDITE_USER,dc.EDIT_TIME,"
                            + "dc.CREATE_TIME FROM device_class AS dc LEFT JOIN users AS u ON dc.CREATE_USER_ID=u.ID LEFT "
                            + "JOIN users AS us ON dc.EDIT_USER_ID=us.ID";
                
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //设备类别编辑
        public MySqlDataReader getTypeInfor(int id)
        {
            try
            {
                string sql = "SELECT dc.ID,dc.TYPE_NAME,u.USER_NAME AS CREATE_USER,us.USER_NAME AS EDITE_USER,dc.EDIT_TIME,"
                            + "dc.CREATE_TIME FROM device_class AS dc LEFT JOIN users AS u ON dc.CREATE_USER_ID=u.ID LEFT "
                            + "JOIN users AS us ON dc.EDIT_USER_ID=us.ID where dc.ID="+@id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql,new MySqlParameter("@id",id));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }

        //设备类别列表
        public MySqlDataReader getTypeList()
        {
            string sql = "SELECT ID,TYPE_NAME FROM device_class";
            return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
        }
        //设备类别编辑保存
        public int saveEditType(int id, string name)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "UPDATE device_class AS dc SET dc.TYPE_NAME='" + @name + "',dc.EDIT_USER_ID="+@Session.UserId
                            + ",dc.EDIT_TIME='" +@date+ "' WHERE dc.ID=" + @id;
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@name",name),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                    new MySqlParameter("@id",id),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return SYSTEM_EXCEPTION;
            }
        }
        //设备列表
        public DataSet queryEquipmentList(EquipmentBean bean)
        {
            try
            {
                string sql = "SELECT erw.ID,erw.DEVICE_CLASS_ID,erw.NUMBER,erw.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME,erw.STORAGE_TIME FROM" +
                           "((SELECT e.ID,e.NUMBER,e.NAME,e.DEVICE_CLASS_ID,e.ROOMS_ID,e.USER_ID,e.STORAGE_TIME FROM " +
                           "equipment AS e WHERE e.WORK_STATUS=0) " +
                           "UNION (SELECT rw.READER_WRITER_ID,rw.NUMBER,rw.NAME,rw.DEVICE_CLASS_ID,rw.ROOM_ID,rw.CREATE_USER_ID," +
                           "rw.CREATE_TIME FROM reader_writer AS rw " +
                           " )) AS erw LEFT JOIN device_class AS dc ON erw.DEVICE_CLASS_ID=dc.ID " +
                           "LEFT JOIN rooms AS r ON erw.ROOMS_ID=r.ID LEFT JOIN users AS u ON r.USERS_ID=u.ID "+
                           "WHERE erw.NUMBER LIKE '%" + @bean.Number + "%'";
                if (bean.Type !=0)
                {
                    sql += " and erw.DEVICE_CLASS_ID=" + bean.Type;
                }
                //System.Windows.MessageBox.Show("===" + sql);
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, new MySqlParameter("@bean.Number", bean.Number));

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //设备信息查看
        public MySqlDataReader getEquipmentInfo(int id)
        {
            try
            {
                string sql = "SELECT e.ID,e.NUMBER,e.NAME,dc.TYPE_NAME,r.ROOM_NAME,e.POWER_SOURCE,e.POSITION,e.STORAGE_TIME,u.USER_NAME,e.WORK_STATUS " +
                            "FROM equipment AS e  LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID "+
                            "LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID  LEFT JOIN users AS u ON e.USER_ID=u.ID WHERE e.ID="+@id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql, new MySqlParameter("@id",id));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //读写器信息查看
        public MySqlDataReader getWriteAndReaderInformation(int id)
        {
            try
            {
                string sql = "SELECT rw.READER_WRITER_ID,rw.NUMBER,rw.NAME,rw.IP,rw.PORT,rw.ANTENNA_SUM,rw.TYPE,rw.SWEEP_TIME,"+
                    "dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME,rw.CREATE_TIME FROM reader_writer AS rw LEFT JOIN users AS u ON "+
                    "rw.CREATE_USER_ID=u.ID LEFT JOIN rooms AS r ON rw.ROOM_ID=r.ID LEFT JOIN device_class AS dc ON rw.DEVICE_CLASS_ID=dc.ID "+ 
                    "WHERE rw.READER_WRITER_ID="+id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //编辑读写器信息
        public int updateWriteAndReader(int id,string name,string ip,int port,int type,float sweepTime)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "UPDATE reader_writer SET NAME='"+@name+"',IP='"+@ip+"',PORT="+@port+",TYPE="+@type+","+
                             "SWEEP_TIME=" + @sweepTime + ",UPDATE_USER_ID=" + @Session.UserId + ",UPDATE_TIME='" + @date + "'"+
                             " WHERE READER_WRITER_ID=" + @id;
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@name",name),
                    new MySqlParameter("@ip",ip),
                    new MySqlParameter("@port",port),
                    new MySqlParameter("@type",type),
                    new MySqlParameter("@sweepTime",sweepTime),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                    new MySqlParameter("@id",id),
                };
                 MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //编辑设备列表信息
        public int updateEquipmentInformation(int id,string name,int type)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "UPDATE equipment SET NAME='" + @name + "',DEVICE_CLASS_ID=" + @type + ",EDIT_USER=" + @Session.UserId +
                           ",EDIT_TIME='" + @date + "' WHERE ID=" + @id;
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@name",name),
                    new MySqlParameter("@type",type),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                    new MySqlParameter("@id",id),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //设备盘点列表
        public DataSet queryInventory()
        {
            try
            {
                string sql = "SELECT ts.TAKE_STOCK_ID,u.ID AS USER_ID,u.ACCOUNT,u.USER_NAME,ts.START_TIME,ts.END_TIME "
                            + "FROM take_stock AS ts LEFT JOIN users AS u ON ts.USER_ID=u.ID WHERE ''ts.START_TIME ORDER BY ts.START_TIME DESC ";

                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //报警列表
        public DataSet queryAlarmList()
        {
            try
            {
                string sql = "SELECT a.ALARM_ID,e.NUMBER,e.NAME,dc.TYPE_NAME,alt.NAME AS ALARM_TYPE_NAME,r.ROOM_NAME,"+
                            "a.ALARM_TIME FROM alarm AS a LEFT JOIN alarm_type AS alt ON a.ALARM_TYPE_ID=alt.ALARM_TYPE_ID "+
                             "LEFT JOIN equipment AS e ON a.EQUIPMENT_ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID "+
                             "LEFT JOIN device_class dc ON e.DEVICE_CLASS_ID=dc.ID WHERE a.STATUS=" + BaseRequest.ALARM_STATUS;
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                
            }
            return null;
        }
        //历史报警列表
        public DataSet queryHistoryAlarmList()
        {
            try
            {
                string sql = "SELECT a.ALARM_ID,e.NUMBER,dc.TYPE_NAME,alt.NAME AS ALARM_TYPE_NAME,r.ROOM_NAME,a.ALARM_TIME,"+
                            "u.USER_NAME,a.PROCESSING_TIME FROM alarm AS a "+
                            "LEFT JOIN alarm_type AS alt ON a.ALARM_TYPE_ID=alt.ALARM_TYPE_ID "+
                            "LEFT JOIN equipment AS e ON a.EQUIPMENT_ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID "+
                            "LEFT JOIN device_class dc ON e.DEVICE_CLASS_ID=dc.ID "+
                            "LEFT JOIN users AS u ON a.USER_ID=u.ID WHERE a.STATUS=" + BaseRequest.DONE_ALARM_STATUS+
                            " order by a.PROCESSING_TIME desc";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //报警信息查询
        public MySqlDataReader getAlarmInformation(int id)
        {
            try
            {
                string sql="SELECT a.ALARM_ID,e.NUMBER,e.NAME,dc.TYPE_NAME,alt.NAME AS ALARM_TYPE_NAME,r.ROOM_NAME,"+
                            "a.ALARM_TIME FROM alarm AS a LEFT JOIN alarm_type AS alt ON a.ALARM_TYPE_ID=alt.ALARM_TYPE_ID "+
                             "LEFT JOIN equipment AS e ON a.EQUIPMENT_ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID "+
                             "LEFT JOIN device_class dc ON e.DEVICE_CLASS_ID=dc.ID WHERE a.ALARM_ID=" + id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                
            }
            return null;
        }
        //报警处理
        public int doAlarmInformation(int id,string msg)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "UPDATE alarm AS a SET a.REMARK='"+@msg+"',a.PROCESSING_TIME='"+@date+"',"+
                             "a.USER_ID="+@Session.UserId+",a.STATUS="+@BaseRequest.DONE_ALARM_STATUS+
                             " WHERE a.ALARM_ID="+@id;
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@msg",msg),
                    new MySqlParameter("@date",date),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@BaseRequest.DONE_ALARM_STATUS",BaseRequest.DONE_ALARM_STATUS),
                    new MySqlParameter("@id",id),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
          //历史信息详情查看
        public MySqlDataReader getHistoryAlarmImformation(int id)
        {
            try
            {
                string sql = "SELECT a.ALARM_ID,e.NUMBER,e.NAME,dc.TYPE_NAME,alt.NAME AS ALARM_TYPE_NAME,r.ROOM_NAME,a.REMARK,u.USER_NAME," +
                           "a.ALARM_TIME,a.PROCESSING_TIME FROM alarm AS a LEFT JOIN alarm_type AS alt ON a.ALARM_TYPE_ID=alt.ALARM_TYPE_ID " +
                           "LEFT JOIN equipment AS e ON a.EQUIPMENT_ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID " +
                           "LEFT JOIN device_class dc ON e.DEVICE_CLASS_ID=dc.ID " +
                           "LEFT JOIN users AS u ON a.USER_ID=u.ID WHERE a.ALARM_ID="+id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //历史设备列表
        public DataSet queryHistoryEquipment()
        {
            try
            {
                string sql = "SELECT he.ID,he.NUMBER,he.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME,he.TAKE_TIME FROM " +
                            "history_equipment AS he LEFT JOIN users AS u ON he.TAKE_USER_ID=u.ID " +
                            "LEFT JOIN rooms AS r ON he.ROOMS_ID=R.ID " +
                            "LEFT JOIN device_class AS dc ON he.DEVICE_CLASS_ID=dc.ID";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //查看历史设备详细信息
        public MySqlDataReader queryHistoryEquipmentInformation(int id)
        {
            try
            {
                string sql = "SELECT he.ID,he.NUMBER,he.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME AS TAKE_NAME,he.TAKE_TIME,"+
                            "us.USER_NAME,he.STORAGE_TIME FROM history_equipment AS he "+ 
                            "LEFT JOIN users AS u ON he.TAKE_USER_ID=u.ID LEFT JOIN users AS us ON he.USER_ID=us.ID "+
                            "LEFT JOIN rooms AS r ON he.ROOMS_ID=R.ID "+
                            "LEFT JOIN device_class AS dc ON he.DEVICE_CLASS_ID=dc.ID WHERE he.ID="+id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}