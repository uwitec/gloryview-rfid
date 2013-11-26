using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace GloryView.RFID.PrintDocument
{
    class FileBean
    {
        private int _FontSize;

        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }
        private Brush _Color;

        public Brush Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

       
        private int _Width;

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

    }
}
