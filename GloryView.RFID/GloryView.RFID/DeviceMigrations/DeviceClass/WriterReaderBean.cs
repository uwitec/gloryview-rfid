using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.DeviceMigrations.DeviceClass
{
    class WriterReaderBean
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
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Ip;

        public string Ip
        {
            get { return _Ip; }
            set { _Ip = value; }
        }
        private int _Port;

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        private int _AntennaSum;

        public int AntennaSum
        {
            get { return _AntennaSum; }
            set { _AntennaSum = value; }
        }
        private int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private int _SweepTime;

        public int SweepTime
        {
            get { return _SweepTime; }
            set { _SweepTime = value; }
        }
        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set { _RoomId = value; }
        }
        private string _EpcCode;

        public string EpcCode
        {
            get { return _EpcCode; }
            set { _EpcCode = value; }
        }

    }
}
