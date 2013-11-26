using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.PrintDocument
{
    class AlarmEnum
    {
        //public enum AlarmColumnsName : uint
        //{
        //    ALARM_ID, NUMBER, NAME, TYPE_NAME,ALARM_TYPE_NAME,ALARM_TIME
        //}
        //SELECT a.ALARM_ID,e.NUMBER,dc.TYPE_NAME,alt.NAME AS ALARM_TYPE_NAME,r.ROOM_NAME,a.ALARM_TIME,"+
                            //"u.USER_NAME,a.ALARM_TIME,a.PROCESSING_TIME
        public static string AlarmColumnsName(string ColumnsName)
        {
            switch (ColumnsName)
            {
                case "ALARM_ID":
                    return "序号";
                case "NUMBER":
                    return "设备编号";
                case "NAME":
                    return "设备名称";
                case "TYPE_NAME":
                    return "设备类型";
                case "ALARM_TYPE_NAME":
                    return "报警类别";
                case "ALARM_TIME":
                    return "报警时间";
                case "ROOM_NAME":
                    return "机 房";
                case "USER_NAME":
                    return "处理用户";
                case "PROCESSING_TIME":
                    return "处理时间";
            };
            return "";
        }
    }
}
