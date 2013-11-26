using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace GloryView.RFID.Utilities
{
    class Session
    {
        private static int userId=0;
        private static int logId;
        private static int userType;

        public static int UserType
        {
            get { return Session.userType; }
            set { Session.userType = value; }
        }
        public static int LogId
        {
            get { return Session.logId; }
            set { Session.logId = value; }
        }

      
        public static int UserId
        {
          get { return Session.userId; }
          set { Session.userId = value; }
        }
        
       
        private static string userAccount = null;

        public static string UserAccount
        {
            get { return Session.userAccount; }
            set { Session.userAccount = value; }
        }
        private static string loginTime = null;

        public static string LoginTime
        {
            get { return Session.loginTime; }
            set { Session.loginTime = value; }
        }
        //MD5加密
        public static string MD5Encrypt(string strText)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strText));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
      
    }
}
