using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.DeviceMigrations.DeviceClass
{
    class DeviceBean
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _Number;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
      
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set { _RoomId = value; }
        }
        private string _EPCCode;

        public string EPCCode
        {
            get { return _EPCCode; }
            set { _EPCCode = value; }
        }
    }
}
