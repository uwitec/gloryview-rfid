using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.ReaderAndWriterClass
{
    public class AntAndBoll
    {
        public AntAndBoll(int ant, bool conn)
        {
            antid = ant;
            isConn = conn;
        }
        
        public int antid;
        public bool isConn;
        public UInt16 rpower;
        public UInt16 wpower;
    }
}
