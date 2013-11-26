using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloryView.RFID.Utilities;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace GloryView.RFID.DeviceMigrations.DeviceClass
{
    class EquipmentClass:BaseRequest
    {
        private MySqlDataReader reade;
        private MySqlParameter parameter = new MySqlParameter();
        //添加设备
        public int addEquipment(DeviceBean bean, Window win)
        {
          
               return MyTransaction.addEquipmentService(bean,win);
            
        }

        //取出设备表最大ID
        public MySqlDataReader getMaxId()
        {
            try
            {
                string sql = "SELECT MAX(id+1)as ID  FROM (SELECT MAX(id)  id FROM equipment UNION SELECT MAX(id)  id FROM history_equipment) AS id";
                return reade=MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);
               
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //等待入库设备列表
        public DataSet comingEquipment()
        {
            try
            {
                //string sql = "SELECT erw.ID,erw.NUMBER,erw.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME,erw.STORAGE_TIME FROM "+
                //            "((SELECT e.ID,e.NUMBER,e.NAME,e.DEVICE_CLASS_ID,e.ROOMS_ID,e.USER_ID,e.STORAGE_TIME FROM "+
                //            "equipment AS e WHERE e.WORK_STATUS="+BaseRequest.INPUT_STATUS+") "+
                //            "UNION (SELECT rw.READER_WRITER_ID,rw.NUMBER,rw.NAME,rw.DEVICE_CLASS_ID,rw.ROOM_ID,rw.CREATE_USER_ID,"+
                //            "rw.CREATE_TIME FROM reader_writer AS rw WHERE rw.STATUS=" + BaseRequest.INPUT_STATUS +
                //            ")) AS erw LEFT JOIN device_class AS dc ON erw.DEVICE_CLASS_ID=dc.ID "+
                //            "LEFT JOIN rooms AS r ON erw.ROOMS_ID=r.ID LEFT JOIN users AS u ON r.USERS_ID=u.ID";
                string sql = "SELECT e.ID,e.NUMBER,e.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.USER_NAME,e.STORAGE_TIME FROM equipment AS e " +
                            "LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID " +
                            "LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN users AS u ON r.USERS_ID=u.ID " +
                            "WHERE e.WORK_STATUS="+BaseRequest.INPUT_STATUS;
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //报修设备列表
        public DataSet getRepairEquipmentList()
        {
            try
            {
                string sql = "SELECT e.ID,e.NAME,dc.TYPE_NAME,r.ROOM_NAME FROM equipment AS e "+
                             "LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID "+
                             "LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID WHERE e.WORK_STATUS=18";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //申请报修设备入库
        public int repairEquipmentComing(int id)
        {
            return MyTransaction.repairEquipmentCome(id);
        }
        //编辑等待入库设备信息
        public MySqlDataReader editNewEquipment(int id)
        {
            try
            {
                string sql = "SELECT e.ID as ID,e.NUMBER,e.NAME,dc.TYPE_NAME,r.ID as RID,r.ROOM_NAME,u.USER_NAME,e.STORAGE_TIME FROM equipment " +
                            "AS e LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN device_class AS dc ON " +
                            "e.DEVICE_CLASS_ID=dc.ID LEFT JOIN users AS u ON e.USER_ID=u.ID WHERE e.ID="+@id;
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql,new MySqlParameter("@id",id));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //保存编辑新设备信息
        public int saveEditEquipment(int _Eid, string _Name, int _RoomId)
        {
            try
            {
                string sql = "UPDATE equipment AS e SET e.NAME='" + @_Name + "',e.ROOMS_ID=" + @_RoomId + " WHERE e.ID=" + @_Eid;
                MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@_Name", _Name),
                    new MySqlParameter("@_RoomId", _RoomId),
                    new MySqlParameter("@_Eid",_Eid),
                };
                MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql, _Parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //所有正常设备列表
        public DataSet getWorkEquipment()
        {
            try
            {
                string sql = "SELECT e.ID,e.NUMBER,e.NAME,u.USER_NAME,dc.TYPE_NAME,r.ROOM_NAME,e.STORAGE_TIME FROM "+
                             "equipment AS e LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID LEFT JOIN rooms "+
                             "AS r ON e.ROOMS_ID=r.ID LEFT JOIN users AS u ON e.USER_ID=u.ID "+
                             "WHERE e.ID NOT IN(SELECT wo.ID FROM work_order AS wo LEFT JOIN equipment AS e ON wo.ID=e.ID);";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
               
            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }
        }
        //申请出库
        public int outRoomEquipment(int id)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES("+@id+","+@BaseRequest.OUT+","+@Session.UserId+",'"+@date+"')";
                MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@id",id),
                    new MySqlParameter("@BaseRequest.OUT",BaseRequest.OUT),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, _Parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //申请报修
        public int repairEquipment(int id)
        {
                return MyTransaction.addRepair(id);
        }
        //申请报废
        public int scrapEquipment(int id)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES(" + @id + "," + @BaseRequest.SCRAP_STATUS + "," + @Session.UserId + ",'" + @date + "')";
                MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@id",id),
                    new MySqlParameter("@BaseRequest.SCRAP_STATUS",BaseRequest.SCRAP_STATUS),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, _Parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //设备迁移
        public int moveEquipment(int id)
        {
            try
            {
                string date = Convert.ToDateTime(DateTime.Now).ToString(BaseRequest.DATE_TIME_FORMAT);
                string sql = "INSERT INTO work_order(ID,STATUS,USER_ID,DATE_TIME) VALUES(" + @id + "," + @BaseRequest.REMOVE_STATUS + "," + @Session.UserId + ",'" + @date + "')";
                MySqlParameter[] _Parameters =
                {
                    new MySqlParameter("@id",id),
                    new MySqlParameter("@BaseRequest.REMOVE_STATUS",BaseRequest.REMOVE_STATUS),
                    new MySqlParameter("@Session.UserId",Session.UserId),
                    new MySqlParameter("@date",date),
                };
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql, _Parameters);
                return BaseRequest.SUCCESS;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //显示出库列表
        public DataSet getDeliverEquipment()
        {
            try
            {
                string sql = "SELECT wo.ID,e.NUMBER,wo.STATUS,wo.DATE_TIME,u.USER_NAME,e.NAME,dc.TYPE_NAME,r.ROOM_NAME FROM " +
                          "work_order AS wo LEFT JOIN users AS u ON wo.USER_ID=u.ID LEFT JOIN equipment AS e ON " +
                          "wo.ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN device_class AS dc ON " +
                          "e.DEVICE_CLASS_ID=dc.ID WHERE wo.STATUS IN(7,8,9)";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //显示报修设备列表
        public DataSet getRepairEquipment()
        {
            try
            {
                string sql = "SELECT wo.ID,e.NUMBER,wo.STATUS,wo.DATE_TIME,u.USER_NAME,e.NAME,dc.TYPE_NAME,r.ROOM_NAME FROM "+
                            "work_order AS wo LEFT JOIN users AS u ON wo.USER_ID=u.ID LEFT JOIN equipment AS e ON "+
                            "wo.ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN device_class AS dc ON "+
                            "e.DEVICE_CLASS_ID=dc.ID WHERE wo.STATUS IN(15,16,17)";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //报废设备列表
        public DataSet getScrappingEquipment()
        {
            try
            {

                string sql = "SELECT wo.ID,e.NUMBER,wo.STATUS,wo.DATE_TIME,u.USER_NAME,e.NAME,dc.TYPE_NAME,r.ROOM_NAME FROM " +
                            "work_order AS wo LEFT JOIN users AS u ON wo.USER_ID=u.ID LEFT JOIN equipment AS e ON " +
                            "wo.ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN device_class AS dc ON " +
                            "e.DEVICE_CLASS_ID=dc.ID WHERE wo.STATUS IN(11,12,13)";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //迁移设备列表
        public DataSet getMoveEquipment()
        {
            try
            {
                string sql = "SELECT wo.ID,e.NUMBER,wo.STATUS,wo.DATE_TIME,u.USER_NAME,e.NAME,dc.TYPE_NAME,r.ROOM_NAME FROM " +
                            "work_order AS wo LEFT JOIN users AS u ON wo.USER_ID=u.ID LEFT JOIN equipment AS e ON " +
                            "wo.ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID LEFT JOIN device_class AS dc ON " +
                            "e.DEVICE_CLASS_ID=dc.ID WHERE wo.STATUS IN(19,20,21)";
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //读写器录入
        public int insertWriterReader(WriterReaderBean bean,Window win)
        {
            try
            {
                return MyTransaction.WriterReader(bean,win);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return BaseRequest.SYSTEM_EXCEPTION;
            }
        }
        //查询读写器最大ID
        public MySqlDataReader getWriderMaxId()
        {
            try
            {
                string sql = "SELECT MAX(READER_WRITER_ID+1) ID FROM reader_writer";
                return MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sql);

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //根据房间查询设备信息列表
        public DataSet getEquipmentInformationByRoom(int roomId)
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
                           "WHERE erw.ROOMS_ID=" + @roomId;
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
