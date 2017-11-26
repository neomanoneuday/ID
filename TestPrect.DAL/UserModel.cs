using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrect.DAL
{
    public class UserModel
    {
        public int PersonalID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string PosstionApplyFor { get; set; }
        public string AvailbleDate { get; set; }

        public string FullTime { get; set; }
        public string PartTime { get; set; }
        public string Seasional { get; set; }



        public System.Data.DataTable dtEducation { get; set; }

        public System.Data.DataTable dtEducationHistory { get; set; }
    }
    public class EducationDetail
    {

        public int EDU_Id { get; set; }
        public string EDU_SchoolName { get; set; }
        public string EDU_Location { get; set; }
        public string EDU_YearAttanded { get; set; }
        public string EDU_DegreeReceived { get; set; }
        public string EDU_Major { get; set; }
    }

}
