using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloryView.RFID.Utilities;

namespace GloryView.RFID.PrintDocument
{
    class ExportFileSql
    {
        //历史报警数据导出
        public static string sql = "SELECT a.ALARM_ID as \"序号\",e.NUMBER as \"设备编号\",dc.TYPE_NAME as \"设备类型\","+
                            "alt.NAME AS \"报警类别\",r.ROOM_NAME as \"所在机房\",u.USER_NAME as \"处理用户\",a.REMARK as \"处理说明\"," +
                            "a.PROCESSING_TIME as \"处理时间\",a.ALARM_TIME as \"报警时间\" FROM alarm AS a " +
                            "LEFT JOIN alarm_type AS alt ON a.ALARM_TYPE_ID=alt.ALARM_TYPE_ID " +
                            "LEFT JOIN equipment AS e ON a.EQUIPMENT_ID=e.ID LEFT JOIN rooms AS r ON e.ROOMS_ID=r.ID " +
                            "LEFT JOIN device_class dc ON e.DEVICE_CLASS_ID=dc.ID " +
                            "LEFT JOIN users AS u ON a.USER_ID=u.ID WHERE a.STATUS=" + BaseRequest.DONE_ALARM_STATUS +
                            " order by a.PROCESSING_TIME desc";
    }
}
