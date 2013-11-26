using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace GloryView.RFID.SystemManagement.SystemClass
{
    class SystemManager
    {
        //设备操作日记
        public DataSet getEquipmentOperation()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT hwo.ID,hwo.EQUIPMENT_ID,equip.NUMBER,hwo.TYPE,equip.NAME,equip.TYPE_NAME,");
                sb.Append("equip.ROOM_NAME,equip.ACCOUNT,equip.STORAGE_TIME,hwo.DATE_TIME ");
                sb.Append(" FROM history_work_order AS hwo LEFT JOIN ");
                sb.Append("((");
                sb.Append("SELECT e.ID AS EID,e.NUMBER,e.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.ACCOUNT,e.STORAGE_TIME FROM equipment AS e ");
                sb.Append("LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID ");
                sb.Append("LEFT JOIN users AS u ON e.USER_ID=u.ID ");
                sb.Append(") ");
                sb.Append("UNION ");
                sb.Append("( ");
                sb.Append("SELECT he.ID AS EID,he.NUMBER,he.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.ACCOUNT,he.STORAGE_TIME FROM ");
                sb.Append("history_equipment AS he ");
                sb.Append("LEFT JOIN device_class AS dc ON he.DEVICE_CLASS_ID=dc.ID LEFT JOIN rooms AS r ON he.ROOMS_ID=r.ID ");
                sb.Append("LEFT JOIN users AS u ON he.USER_ID=u.ID ");
                sb.Append(")) AS equip ON hwo.EQUIPMENT_ID=equip.EID");
                return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sb.ToString());
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
        //查看详细操作设备信息
        public MySqlDataReader getEquipmentInfo(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT hwo.ID,hwo.EQUIPMENT_ID,equip.NUMBER,hwo.TYPE,equip.NAME,equip.TYPE_NAME,");
                sb.Append("equip.ROOM_NAME,equip.ACCOUNT,equip.STORAGE_TIME,hwo.DATE_TIME ");
                sb.Append(" FROM history_work_order AS hwo LEFT JOIN ");
                sb.Append("((");
                sb.Append("SELECT e.ID AS EID,e.NUMBER,e.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.ACCOUNT,e.STORAGE_TIME FROM equipment AS e ");
                sb.Append("LEFT JOIN device_class AS dc ON e.DEVICE_CLASS_ID=dc.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID ");
                sb.Append("LEFT JOIN users AS u ON e.USER_ID=u.ID ");
                sb.Append(") ");
                sb.Append("UNION ");
                sb.Append("( ");
                sb.Append("SELECT he.ID AS EID,he.NUMBER,he.NAME,dc.TYPE_NAME,r.ROOM_NAME,u.ACCOUNT,he.STORAGE_TIME FROM ");
                sb.Append("history_equipment AS he ");
                sb.Append("LEFT JOIN device_class AS dc ON he.DEVICE_CLASS_ID=dc.ID LEFT JOIN rooms AS r ON he.ROOMS_ID=r.ID ");
                sb.Append("LEFT JOIN users AS u ON he.USER_ID=u.ID ");
                sb.Append(")) AS equip ON hwo.EQUIPMENT_ID=equip.EID ");
                sb.Append("WHERE hwo.ID="+id);
                return  MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, sb.ToString());
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
            return null;
        }
    }
}
