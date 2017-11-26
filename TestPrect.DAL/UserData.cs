using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestPrect.DAL
{
    public class UserData
    {
        
        public static string SaveUserData(UserModel objuser)
        {
            string con = ConnectionString.constr;
            DataSet dsr = new DataSet();
            using (SqlConnection constr = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = constr;
                cmd.CommandText = "SP_InsertData";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PI_Id", objuser.PersonalID);
                cmd.Parameters.Add("@PI_Name", objuser.Name);
                cmd.Parameters.Add("@PI_City", objuser.City);
                cmd.Parameters.Add("@PI_State", objuser.State);
                cmd.Parameters.Add("@PI_Zip", objuser.Zip);
                cmd.Parameters.Add("@PI_PhoneNo", objuser.PhoneNo);
                cmd.Parameters.Add("@PI_MobileNo", objuser.MobileNo);
                cmd.Parameters.Add("@PI_EmailAddress", objuser.Email);
                cmd.Parameters.Add("@PI_PosstionApplyFor", objuser.PosstionApplyFor);
                cmd.Parameters.Add("@PI_AvaliableStartDate", objuser.AvailbleDate);
                cmd.Parameters.Add("@PI_FullTime", objuser.FullTime);
                cmd.Parameters.Add("@PI_PartTime", objuser.PartTime);
                cmd.Parameters.Add("@PI_SeasonalTemporary", objuser.Seasional);
                cmd.Parameters.Add("@EducationDetails", objuser.dtEducation);
                cmd.Parameters.Add("@EmploymentHistory", objuser.dtEducationHistory);
                constr.Open();
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.SelectCommand = cmd;
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                cmd.ExecuteNonQuery();
                constr.Close();

            }

            return "Success";
          
        }

         public static System.Data.DataSet EditUserData(int ID)
        {
            DataSet dsEdit = new DataSet();
            string con = ConnectionString.constr;

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "EditUserDetail";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", ID);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(command);

                sda.Fill(dsEdit);
                connection.Close();
               
            }
            return dsEdit;
        }

         public static DataSet GetAllEmpData()
         {
             DataSet ret = new DataSet();
             string con = ConnectionString.constr;
             using (SqlConnection constr=new SqlConnection(con))
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = constr;
                 cmd.CommandText = "EditUserDetail";
                 cmd.CommandType = CommandType.StoredProcedure;
                 constr.Open();
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 da.SelectCommand = cmd;
                 da.Fill(ret);
                 constr.Close();
             }
             return ret;
         }

         public static string UpdateEdu(EducationDetail objedu)
         {
             string con = ConnectionString.constr;
             using (SqlConnection constr = new SqlConnection(con))
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = constr;
                 cmd.CommandText = "UpdateEducation";

                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@EDU_Id", objedu.EDU_Id);
                 cmd.Parameters.Add("@EDU_SchoolName", objedu.EDU_SchoolName);
                 cmd.Parameters.Add("@EDU_Location", objedu.EDU_Location);
                 cmd.Parameters.Add("@EDU_YearAttanded", objedu.EDU_YearAttanded);
                 cmd.Parameters.Add("@EDU_DegreeReceived", objedu.EDU_DegreeReceived);
                 cmd.Parameters.Add("@EDU_Major", objedu.EDU_Major);
                 constr.Open();
               
                 cmd.ExecuteNonQuery();
                 constr.Close();

             }

             return "Success";
         }
    }
}
