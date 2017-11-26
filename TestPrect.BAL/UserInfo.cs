using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPrect.DAL;

namespace TestPrect.BAL
{
    public class UserInfo
    {

        public static string InsertInfo(UserModel objuser)
        {
           return UserData.SaveUserData(objuser);
        }

        public static System.Data.DataSet EditUserInfo(int ID)
        {
            return UserData.EditUserData(ID);
        }




        public static System.Data.DataSet GetAllList()
        {
            return UserData.GetAllEmpData();
        }

        public static string UpdateEducation(EducationDetail objedu)
        {
            return UserData.UpdateEdu(objedu);
        }
    }
}
