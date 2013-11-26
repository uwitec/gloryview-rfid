using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.SystemManagement
{
    class SystemManagerFactory
    {
        private SystemManagerFactory() { }
        private static SystemSetting systemSetting = new SystemSetting();

        public static SystemSetting SystemSetting
        {
            get { return systemSetting; }
            set { systemSetting = value; }
        }
        private static DataSecurity sataSecurity = new DataSecurity();

        public static DataSecurity SataSecurity
        {
            get { return SystemManagerFactory.sataSecurity; }
            set { SystemManagerFactory.sataSecurity = value; }
        }
        private static AllUserLog userLog = new AllUserLog();

        public static AllUserLog UserLog
        {
            get { return SystemManagerFactory.userLog; }
            set { SystemManagerFactory.userLog = value; }
        }
        private static MovedDevicesLog movedDevicesLog = new MovedDevicesLog();

        public static MovedDevicesLog MovedDevicesLog
        {
            get { return SystemManagerFactory.movedDevicesLog; }
            set { SystemManagerFactory.movedDevicesLog = value; }
        }
        private static AlarmSetting alarmSetting = new AlarmSetting();

        public static AlarmSetting AlarmSetting
        {
            get { return SystemManagerFactory.alarmSetting; }
            set { SystemManagerFactory.alarmSetting = value; }
        }

    }
}
