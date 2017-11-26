using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestPrect.BAL;

namespace TestPrect
{
    public partial class EmpAllList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataSet ds =UserInfo.GetAllList() ;
            grdAllList.DataSource = ds.Tables[0];
            grdAllList.DataBind();
        }
    }
}