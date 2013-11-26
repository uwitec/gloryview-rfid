using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.Utilities
{
    class BaseRequest
    {
        public static int IS_LOGIN = 0;
        public const  string DATE_FORMAT = "yyyy-MM-dd";

        public static string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static string DATE_MS_FORMAT = "yyyy-MM-dd HH:mm";
        public static readonly int SYSTEM_EXCEPTION = 3;  //系统异常
        public static readonly int SUCCESS = 0;  //成功
        public static readonly int ERROR = 1;   //失败
        public static readonly int HAS = 2; //已存在
        public static readonly int PASSWORD_ERROR = 4;//密码不一致
        public static readonly int TIME = 1000;     //登陆退出时间记录时间隔
        public static readonly int PAGE_SIZE = 17;   //分页大小
        public static int PAGE_CURRENT = 1; //默认当前页
        public static int MAX_PAGE = 1;
        public static int TOTAL = 0; //一共多少条数据
        public static readonly int INPUT_STATUS = 1; //新设备入库状态
        public static readonly int REPAIR_STATUS = 15; //设备报修状态
        public static readonly int OUT = 7;//设备请求出库状态
        public static readonly int SCRAP_STATUS = 11; //设备报废状态
        public static readonly int REMOVE_STATUS = 19;  //设备迁移状态
        public static readonly int ALARM_STATUS = 0;  //未处理报警
        public static readonly int DONE_ALARM_STATUS = 1;  //已处理报警
        public static readonly int ALARM_TIME = 10000;   //报警是刷新时间(分)
        //系统退出时间
        public static int _ExitSystemTime = 30;  
        //EPC标签编码规格
        public static ushort[] _Readdata = { 4096, 48, 56, 32, 0, 0 };

        public void exitSystem()
        {
            Session.UserId =0;
            Session.UserAccount = null;

        }
    }
}
