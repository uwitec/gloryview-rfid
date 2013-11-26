using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.SystemManagement.SystemClass
{
    class OperationTypeString
    {
        public static string getTypeStr(int type)
        {
            switch (type)
            {
                case 6: return "完成入库";
                case 10: return "完成出库";
                case 14: return "完成报废";
                case 18: return "完成报修";
                case 25: return "完成迁移";

            }
            return null;
        }
    }
}
