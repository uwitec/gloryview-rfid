using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using System.Data;
using GloryView.RFID.RoomManagement;
using GloryView.RFID.RoomManagement.Rooms;

namespace GloryView.RFID.Utilities
{
    class AlarmClass
    {
        //string _Asql = "SELECT * FROM alarm_original AS ao GROUP BY ao.EQUIPMENT_NUMBER,ao.ALARM_TYPE_ID";
      //private  int logId;
       // private MysqlDataDao dao = new MysqlDataDaoImpl();
      
        public  void TimerRun()
        {
            DispatcherTimer dTimer;
            dTimer = new System.Windows.Threading.DispatcherTimer();
            //设置事件处理函数
            dTimer.Tick += new EventHandler(diplayAlrm_Tick);
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, BaseRequest.ALARM_TIME);
            dTimer.Start();
        }
        private  void diplayAlrm_Tick(object sender, EventArgs e)
        {
            MyTransaction.insertAlarm();
            Alarm alarm = RoomManagerBean.Alarm;
            RoomClass _Rclass = new RoomClass();
            DataSet _Alarm_Set = _Rclass.queryAlarmList();
            alarm.page.ShowPages(alarm.alarmGrid, _Alarm_Set, BaseRequest.PAGE_SIZE);
        }
    }
}
