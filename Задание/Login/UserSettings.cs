using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание
{
    public class UserSettings
    {
        public static List<User> UserList = new List<User>();
        public static List<Settings> SettingsList = new List<Settings>();

        public class User
        {
            public int UserID { get; set; }
            public bool IsAdmin { get; set; }
            public bool LoadSettings { get; set; }
            public bool IsAnimation { get; set; }
            public bool IsDisconnect { get; set; }
            public int DisconnectTimeout { get; set; }
            public string Theme { get; set; }
        }

        public class Settings
        {
            public string UserSurname { get; set; }
            public string UserName { get; set; }
            public string UserSecondName { get; set; }
            public string UserPosition { get; set; }
            public string UserTitle { get; set; }
            public string UserComputer { get; set; }
            public string UserPhone { get; set; }
            public string UserDivision { get; set; }
            public string UserService { get; set; }
            public string UserLine { get; set; }
            public string UserDepartment { get; set; }
            public string UserOffice { get; set; }
            public string HeadSurname { get; set; }
            public string HeadName { get; set; }
            public string HeadSecondName { get; set; }
            public string HeadPosition { get; set; }
            public string HeadTitle { get; set; }
            public string HeadDivision { get; set; }
            public string HeadService { get; set; }
            public string HeadLine { get; set; }

            public string UserSurnameDative { get; set; }
            public string UserNameDative { get; set; }
            public string UserSecondNameDative { get; set; }
            public string UserPositionDative { get; set; }
            public string UserTitleDative { get; set; }
            public string HeadSurnameDative { get; set; }
            public string HeadNameDative { get; set; }
            public string HeadSecondNameDative { get; set; }
            public string HeadPositionDative { get; set; }
            public string HeadTitleDative { get; set; }
        }

        #region Call Methods
        public int UserID
        {
            get { return UserList[0].UserID; }
        }

        public bool IsAdmin
        {
            get { return UserList[0].IsAdmin; }
        }

        public bool LoadSettings
        {
            get { return UserList[0].LoadSettings; }
        }

        public bool IsAnimation
        {
            get { return UserList[0].IsAnimation; }
        }

        public bool IsDisconnect
        {
            get { return UserList[0].IsDisconnect; }
        }

        public int DisconnectTimeout
        {
            get { return UserList[0].DisconnectTimeout; }
            set { UserList[0].DisconnectTimeout = value; }
        }

        public string Theme
        {
            get { return UserList[0].Theme; }
        }
        #endregion
    }
}
