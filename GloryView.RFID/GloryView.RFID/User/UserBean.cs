using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.User
{
    class UserBean
    {
        private int id; //用户ID

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string account; //用户帐号

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string userName;  //用户名称

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private int type;        //用户类型

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string typeName; //用户类型转换

        public string TypeName
        {
            get {
                if (this.type == 1)
                {
                    typeName = "管理员";
                }
                else
                {
                    typeName = "用户";
                }
                  return typeName; 
                }
        }
        private string password;  //用户密码

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int status;      //状态

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private string statusName;

        public string StatusName
        {
            get {
                if (this.status == 0)
                {
                    statusName = "激 活";
                }
                else if (this.status == 1)
                {
                    statusName = "启 用";
                }
                else
                {
                    statusName="禁 用";
                }
                    return statusName; 
                }
        }
        private int createId;    //创建者

        public int CreateId
        {
            get { return createId; }
            set { createId = value; }
        }
        private string createName;

        public string CreateName
        {
            get { return createName; }
            set { createName = value; }
        }
        private string phone;    //联系电话

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private DateTime loginTime;   //最近登录时间

        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }
        private string loginDate; //最近登陆时间字符串

        public string LoginDate
        {
            get { return loginDate; }
            set { loginDate = value; }
        }

        private DateTime updateTime;   //更新时间

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
        private DateTime createTime;   //创建时间

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string createDate;  //创建日期字符串

        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
    }
}
