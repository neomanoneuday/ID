using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestPrect.DAL;
using TestPrect.BAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace TestPrect
{
    public partial class Emp_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionString.constr = ConfigurationManager.ConnectionStrings["FormCon"].ConnectionString;

            if (!Page.IsPostBack)
            {
                ViewState["ID"] = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                {
                    EditDetail(Convert.ToInt16(Request.QueryString["pid"]));
                    ViewState["ID"] = Convert.ToInt16(Request.QueryString["pid"]);
                }
                else
                {
                    SetInitialRow();
                    SetInitialRowEmp();
                }
            }
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            
            dt.Columns.Add(new DataColumn("EDU_SchoolName", typeof(string)));
            dt.Columns.Add(new DataColumn("EDU_Location", typeof(string)));
            dt.Columns.Add(new DataColumn("EDU_YearAttanded", typeof(string)));
            dt.Columns.Add(new DataColumn("EDU_DegreeReceived", typeof(string)));
            dt.Columns.Add(new DataColumn("EDU_Major", typeof(string)));
            dt.Columns.Add(new DataColumn("EDU_Id", typeof(int)));
            dr = dt.NewRow();

            
            dr["EDU_SchoolName"] = string.Empty;
            dr["EDU_Location"] = string.Empty;
            dr["EDU_YearAttanded"] = string.Empty;
            dr["EDU_DegreeReceived"] = string.Empty;
            dr["EDU_Major"] = string.Empty;
            dr["EDU_Id"] = 0;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            grdEdu.DataSource = dt;
            grdEdu.DataBind();
        }


        private void SetInitialRowEmp()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("EH_Employer", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_JobTitle", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_Address", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_City", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_State", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_Zip", typeof(string)));
            dt.Columns.Add(new DataColumn("EH_DatesEmployed", typeof(string)));
            dr = dt.NewRow();

            dr["EH_Employer"] = string.Empty;
            dr["EH_JobTitle"] = string.Empty;
            dr["EH_Address"] = string.Empty;
            dr["EH_City"] = string.Empty;
            dr["EH_State"] = string.Empty;
            dr["EH_Zip"] = string.Empty;
            dr["EH_DatesEmployed"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTableEmp"] = dt;

            rptEmpHistory.DataSource = dt;
            rptEmpHistory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("Name", typeof(string));
            dtInfo.Columns.Add("Address", typeof(string));
            dtInfo.Columns.Add("City", typeof(string));
            dtInfo.Columns.Add("State", typeof(string));
            dtInfo.Columns.Add("Zip", typeof(string));
            dtInfo.Columns.Add("PhoneNo", typeof(string));
            dtInfo.Columns.Add("MobileNo", typeof(string));
            dtInfo.Columns.Add("Email", typeof(string));
            dtInfo.Columns.Add("PosstionApplyFor", typeof(string));
            dtInfo.Columns.Add("AvailbleDate", typeof(string));
            dtInfo.Columns.Add("FullTime", typeof(string));
            dtInfo.Columns.Add("PartTime", typeof(string));
            dtInfo.Columns.Add("Seasional", typeof(string));

            ds.Tables.Add(dtInfo);

            DataTable dtEdu = new DataTable();
            dtEdu.Columns.Add("EDU_SchoolName", typeof(string));
            dtEdu.Columns.Add("EDU_Location", typeof(string));
            dtEdu.Columns.Add("EDU_YearAttanded", typeof(string));
            dtEdu.Columns.Add("EDU_DegreeReceived", typeof(string));
            dtEdu.Columns.Add("EDU_Major", typeof(string));
            dtEdu.Columns.Add("EDU_Id", typeof(int));
            ds.Tables.Add(dtEdu);

            DataTable dtEmployer = new DataTable();
            dtEmployer.Columns.Add("EH_Employer", typeof(string));
            dtEmployer.Columns.Add("EH_JobTitle", typeof(string));
            dtEmployer.Columns.Add("EH_Address", typeof(string));
            dtEmployer.Columns.Add("EH_City", typeof(string));
            dtEmployer.Columns.Add("EH_State", typeof(string));
            dtEmployer.Columns.Add("EH_Zip", typeof(string));
            dtEmployer.Columns.Add("EH_DatesEmployed", typeof(string));

            ds.Tables.Add(dtEmployer);

            DataRow dr = ds.Tables[0].NewRow();

            dr["Name"] = txtName.Text;
            dr["MobileNo"] = txtMobileNumber.Text;
            dr["Address"] = txtAddress.Text;
            dr["City"] = txtCity.Text;
            dr["State"] = txtState.Text;
            dr["Zip"] = txtZip.Text;
            dr["PhoneNo"] = txtPhoneNumber.Text;
            dr["Email"] = txtEmailAddress.Text;
            dr["PosstionApplyFor"] = txtPositionYouAreApplyingFor.Text;
            dr["AvailbleDate"] = txtAvailableStartDate.Text;
            dr["FullTime"] = chkFulltime.Checked ? "1" : "0";
            dr["PartTime"] = chkFulltime.Checked ? "1" : "0";
            dr["Seasional"] = chkFulltime.Checked ? "1" : "0";

            ds.Tables[0].Rows.Add(dr);

            int rowIndex = 0;
            DataRow drEdu;// = ds.Tables[1].NewRow();
            for (int i = 0; i < grdEdu.Rows.Count; i++)
            {
                drEdu = ds.Tables[1].NewRow();
                //extract the TextBox values
                drEdu["EDU_SchoolName"] = ((TextBox)grdEdu.Rows[rowIndex].Cells[0].FindControl("txtSchool")).Text.ToString();
                drEdu["EDU_Location"] = ((TextBox)grdEdu.Rows[rowIndex].Cells[1].FindControl("txtLocation")).Text.ToString();
                drEdu["EDU_YearAttanded"] = ((TextBox)grdEdu.Rows[rowIndex].Cells[2].FindControl("txtYear")).Text.ToString();
                drEdu["EDU_DegreeReceived"] = ((TextBox)grdEdu.Rows[rowIndex].Cells[3].FindControl("txtDegreeReceivedeived")).Text.ToString();
                drEdu["EDU_Major"] = ((TextBox)grdEdu.Rows[rowIndex].Cells[4].FindControl("txtMajor")).Text.ToString();
                drEdu["EDU_Id"] = 0;
                ds.Tables[1].Rows.Add(drEdu);
                rowIndex++;
            }

            DataRow drEmp;// = ds.Tables[1].NewRow();
            for (int i = 0; i <= rptEmpHistory.Items.Count - 1; i++)
            {

                drEmp = ds.Tables[2].NewRow();
                //extract the TextBox values
                drEmp["EH_Employer"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtEmployer")).Text;
                drEmp["EH_JobTitle"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtJobTitle")).Text;
                drEmp["EH_DatesEmployed"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtDatesEmployed")).Text;
                drEmp["EH_Address"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtHistoryAddress")).Text;
                drEmp["EH_City"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtHistoryCity")).Text;
                drEmp["EH_State"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtHistoryState")).Text;
                drEmp["EH_Zip"] = ((TextBox)rptEmpHistory.Controls[i].FindControl("txtHistoryZip")).Text;

                //get the values from the TextBoxes
                //then add it to the collections with a comma "," as the delimited values
                ds.Tables[2].Rows.Add(drEmp);
            }

            UserModel objuser = new UserModel();
            objuser.PersonalID = 0;
            objuser.Name = txtName.Text;
            objuser.MobileNo = txtMobileNumber.Text;
            objuser.Address = txtAddress.Text;
            objuser.City = txtCity.Text;
            objuser.State = txtState.Text;
            objuser.Zip = txtZip.Text;
            objuser.PhoneNo = txtPhoneNumber.Text;
            objuser.Email = txtEmailAddress.Text;
            objuser.PosstionApplyFor = txtPositionYouAreApplyingFor.Text;
            objuser.AvailbleDate = txtAvailableStartDate.Text;
            objuser.FullTime = chkFulltime.Checked ? "1" : "0";
            objuser.PartTime = chkFulltime.Checked ? "1" : "0";
            objuser.Seasional = chkFulltime.Checked ? "1" : "0";

            
            dtEdu.Columns.Remove("EDU_Id");
           
            objuser.dtEducation = dtEdu;
            objuser.dtEducationHistory = dtEmployer;

            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                objuser.PersonalID = Convert.ToInt16(Request.QueryString["pid"]);
            }

            string strResp = UserInfo.InsertInfo(objuser);

            if (strResp == "Success")
            {
                Response.Redirect("EmpAllList.aspx");
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)grdEdu.Rows[rowIndex].Cells[0].FindControl("txtSchool");
                        TextBox box2 = (TextBox)grdEdu.Rows[rowIndex].Cells[1].FindControl("txtLocation");
                        TextBox box3 = (TextBox)grdEdu.Rows[rowIndex].Cells[2].FindControl("txtYear");
                        TextBox box4 = (TextBox)grdEdu.Rows[rowIndex].Cells[3].FindControl("txtDegreeReceivedeived");
                        TextBox box5 = (TextBox)grdEdu.Rows[rowIndex].Cells[4].FindControl("txtMajor");

                        drCurrentRow = dtCurrentTable.NewRow();


                        dtCurrentTable.Rows[i - 1]["EDU_SchoolName"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["EDU_Location"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["EDU_YearAttanded"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["EDU_DegreeReceived"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["EDU_Major"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["EDU_Id"] = 0;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grdEdu.DataSource = dtCurrentTable;
                    grdEdu.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)grdEdu.Rows[rowIndex].Cells[0].FindControl("txtSchool");
                        TextBox box2 = (TextBox)grdEdu.Rows[rowIndex].Cells[1].FindControl("txtLocation");
                        TextBox box3 = (TextBox)grdEdu.Rows[rowIndex].Cells[2].FindControl("txtYear");
                        TextBox box4 = (TextBox)grdEdu.Rows[rowIndex].Cells[3].FindControl("txtDegreeReceivedeived");
                        TextBox box5 = (TextBox)grdEdu.Rows[rowIndex].Cells[4].FindControl("txtMajor");

                        box1.Text = dt.Rows[i]["EDU_SchoolName"].ToString();
                        box2.Text = dt.Rows[i]["EDU_Location"].ToString();
                        box3.Text = dt.Rows[i]["EDU_YearAttanded"].ToString();
                        box4.Text = dt.Rows[i]["EDU_DegreeReceived"].ToString();
                        box5.Text = dt.Rows[i]["EDU_Major"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonEmp_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;

            if (ViewState["CurrentTableEmp"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableEmp"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtEmployer");
                        TextBox box2 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtJobTitle");
                        TextBox box3 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtDatesEmployed");
                        TextBox box4 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryAddress");
                        TextBox box5 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryCity");
                        TextBox box6 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryState");
                        TextBox box7 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryZip");

                        drCurrentRow = dtCurrentTable.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["EH_Employer"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["EH_JobTitle"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["EH_DatesEmployed"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["EH_Address"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["EH_City"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["EH_State"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["EH_Zip"] = box7.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTableEmp"] = dtCurrentTable;

                    rptEmpHistory.DataSource = dtCurrentTable;
                    rptEmpHistory.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousRptData();
        }


        private void SetPreviousRptData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTableEmp"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableEmp"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtEmployer");
                        TextBox box2 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtJobTitle");
                        TextBox box3 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtDatesEmployed");
                        TextBox box4 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryAddress");
                        TextBox box5 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryCity");
                        TextBox box6 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryState");
                        TextBox box7 = (TextBox)rptEmpHistory.Controls[0].FindControl("txtHistoryZip");

                        box1.Text = dt.Rows[i]["EH_Employer"].ToString();
                        box2.Text = dt.Rows[i]["EH_JobTitle"].ToString();
                        box3.Text = dt.Rows[i]["EH_DatesEmployed"].ToString();
                        box4.Text = dt.Rows[i]["EH_Address"].ToString();
                        box5.Text = dt.Rows[i]["EH_City"].ToString();
                        box6.Text = dt.Rows[i]["EH_State"].ToString();
                        box7.Text = dt.Rows[i]["EH_Zip"].ToString();

                        rowIndex++;
                    }
                }
            }
        }


        protected void EditDetail(int id)
        {
            DataSet ds = UserData.EditUserData(id);

            if (ds != null)
            {

                DataTable dt_Personal = ds.Tables[0];//  Personal Info Bind

                if (dt_Personal != null)
                {
                    if (dt_Personal.Rows.Count > 0)
                    {
                        txtName.Text = dt_Personal.Rows[0]["PI_Name"].ToString();
                      //  txtAddress.Text = dt_Personal.Rows[0]["Address"].ToString();
                        txtCity.Text = dt_Personal.Rows[0]["PI_City"].ToString();
                        txtState.Text = dt_Personal.Rows[0]["PI_State"].ToString();
                        txtZip.Text = dt_Personal.Rows[0]["PI_Zip"].ToString();
                        txtPhoneNumber.Text = dt_Personal.Rows[0]["PI_PhoneNo"].ToString();
                        txtMobileNumber.Text = dt_Personal.Rows[0]["PI_MobileNo"].ToString();
                        txtEmailAddress.Text = dt_Personal.Rows[0]["PI_EmailAddress"].ToString();
                        txtPositionYouAreApplyingFor.Text = dt_Personal.Rows[0]["PI_PosstionApplyFor"].ToString();

                        chkFulltime.Checked = Convert.ToBoolean(dt_Personal.Rows[0]["PI_FullTime"]);
                        chkPartTime.Checked = Convert.ToBoolean(dt_Personal.Rows[0]["PI_PartTime"]);
                        chkSeasional.Checked = Convert.ToBoolean(dt_Personal.Rows[0]["PI_SeasonalTemporary"]);
                        if (!string.IsNullOrEmpty(dt_Personal.Rows[0]["PI_AvaliableStartDate"].ToString()))
                        {
                            txtAvailableStartDate.Text = Convert.ToDateTime(dt_Personal.Rows[0]["PI_AvaliableStartDate"]).ToString("dd-MM-yyyy");    
                        }
                        
                    }
                }
                DataTable dt_Education = ds.Tables[1];//  Personal Info Bind  
                if (dt_Education != null)
                {
                    if (dt_Education.Rows.Count > 0)
                    {
                        ViewState["CurrentTable"] = dt_Education;
                        grdEdu.DataSource = dt_Education;
                        grdEdu.DataBind();
                    }
                }
                DataTable dt_EducationHis = ds.Tables[2];//  Personal Info Bind  
                if (dt_EducationHis != null)
                {
                    if (dt_EducationHis.Rows.Count > 0)
                    {
                        ViewState["CurrentTableEmp"] = dt_EducationHis;
                        rptEmpHistory.DataSource = dt_EducationHis;
                        rptEmpHistory.DataBind();
                    }
                }
            }

        }

        protected void grdEdu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="Edit")
            {
                EducationDetail objedu = new EducationDetail();
                int ID = Convert.ToInt32(e.CommandArgument);

                string EduID = ((HiddenField)grdEdu.Rows[ID].Cells[0].FindControl("Hdn_EDU_Id")).Value;
                objedu.EDU_SchoolName = ((TextBox)grdEdu.Rows[ID].Cells[0].FindControl("txtSchool")).Text;
                objedu.EDU_Location = ((TextBox)grdEdu.Rows[ID].Cells[0].FindControl("txtLocation")).Text;
                objedu.EDU_YearAttanded = ((TextBox)grdEdu.Rows[ID].Cells[0].FindControl("txtYear")).Text;
                objedu.EDU_DegreeReceived = ((TextBox)grdEdu.Rows[ID].Cells[0].FindControl("txtDegreeReceivedeived")).Text;
                objedu.EDU_Major = ((TextBox)grdEdu.Rows[ID].Cells[0].FindControl("txtMajor")).Text;

                string strResp = UserInfo.UpdateEducation(objedu);
                if (strResp == "Success")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Successfully Updated');", true);
                }
            }
        }

        protected void grdEdu_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void rptEmpHistory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int ID = e.Item.ItemIndex; 
                string txtEmployeer = ((TextBox)rptEmpHistory.Controls[ID].FindControl("txtEmployer")).Text;
            }
        }


    }


}