using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.User
{
    class QueryUser
    {
        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
