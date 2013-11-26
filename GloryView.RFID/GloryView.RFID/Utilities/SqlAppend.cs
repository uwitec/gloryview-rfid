using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GloryView.RFID.Utilities
{
    class SqlAppend
    {
        public static DataSet SearchEquipment(SearchBean bean)
        {
             StringBuilder sb = new StringBuilder();
             sb.Append("SELECT erw.ID,erw.DEVICE_CLASS_ID,erw.ROOMS_ID,erw.NUMBER,erw.NAME,dc.TYPE_NAME," +
                        "r.ROOM_NAME, u.USER_NAME,erw.STORAGE_TIME FROM ");
            sb.Append("((SELECT e.ID,e.NUMBER,e.NAME,e.DEVICE_CLASS_ID,e.ROOMS_ID,e.USER_ID,e.STORAGE_TIME FROM ");
            sb.Append("equipment AS e WHERE e.WORK_STATUS=0) ");
            sb.Append("UNION (SELECT rw.READER_WRITER_ID,rw.NUMBER,rw.NAME,rw.DEVICE_CLASS_ID,rw.ROOM_ID,rw.CREATE_USER_ID,");
            sb.Append("rw.CREATE_TIME FROM reader_writer AS rw ");
            sb.Append(")) AS erw LEFT JOIN device_class AS dc ON erw.DEVICE_CLASS_ID=dc.ID ");
            sb.Append("LEFT JOIN rooms AS r ON erw.ROOMS_ID=r.ID LEFT JOIN users AS u ON r.USERS_ID=u.ID ");
            sb.Append(" WHERE ");
            sb.Append("erw.NUMBER like '%" + bean.Number + "%' ");
            sb.Append("and erw.NAME like '%" + bean.Name + "%' ");
            if (bean.Type != 0)
            {
                sb.Append(" and erw.DEVICE_CLASS_ID=" + bean.Type);
            }
            if (bean.RoomId != 0)
            {
                sb.Append(" and erw.ROOMS_ID ="+bean.RoomId);
            }
            sb.Append(" and u.USER_NAME='%" + bean.UserName + "%'");
            if (!bean.CreateTime.Equals(""))
            {
                sb.Append(" and " + bean.CreateTime + " < erw.STORAGE_TIME ");
            }
            if (!bean.OnTime.Equals(""))
            {
                sb.Append(" and erw.STORAGE_TIME < " + bean.OnTime);
            }
           
            return MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sb.ToString());
        }
    }
}
