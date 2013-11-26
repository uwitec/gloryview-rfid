using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloryView.RFID.UserManager.IU
{
    class UserManagerBean
    {
        private UserManagerBean() { }
        private static UserManagerBean userBean = new UserManagerBean();

       internal static UserManagerBean UserBean
        {
            get { return UserManagerBean.userBean; }
            set { UserManagerBean.userBean = value; }
        }


       private static AddUser addUser = new AddUser();

       public static AddUser AddUser
       {
           get { return UserManagerBean.addUser; }
           set { UserManagerBean.addUser = value; }
       }


       private static ChangePaw changePassword = new ChangePaw();

       public static ChangePaw ChangePassword
       {
           get { return UserManagerBean.changePassword; }
           set { UserManagerBean.changePassword = value; }
       }


       private static EditPower editPower = new EditPower();

       public static EditPower EditPower
       {
           get { return UserManagerBean.editPower; }
           set { UserManagerBean.editPower = value; }
       }


       private static LoginLog loginLog = new LoginLog();

       public static LoginLog LoginLog
       {
           get { return UserManagerBean.loginLog; }
           set { UserManagerBean.loginLog = value; }
       }


       private static ActionLog actionLog = new ActionLog();

       public static ActionLog ActionLog
       {
           get { return UserManagerBean.actionLog; }
           set { UserManagerBean.actionLog = value; }
       }

      
       // private static EditPower editPower = new EditPower();
        private static AddUsers addUsers = new AddUsers();

        public static AddUsers AddUsers
        {
            get { return UserManagerBean.addUsers; }
            set { UserManagerBean.addUsers = value; }
        }
    }
}
