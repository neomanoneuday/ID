<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emp_Form.aspx.cs" Inherits="TestPrect.Emp_Form" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <link rel="shortcut icon" href="favicon.ico">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" type="text/javascript"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script>

    <title>Home Page</title>

    <style type="text/css">
        .CustTitle {
            background-color: #b1b1b1;
            color: #FFFFFF;
            padding: 10px;
            border-bottom: 3px solid #000000;
        }

        .CustSubTitle {
            background-color: #dedcdc;
            color: #000000;
            padding: 10px;
            border-bottom: 1px solid #000000;
        }

        .TextLeft {
            text-align: left !important;
        }

        .TextRight {
            text-align: right !important;
        }

        .NoPadding {
            padding: 0 !important;
        }

        .MarginBottom0 {
            margin-bottom: 0 !important;
        }

        .MarginBottom20 {
            margin-bottom: 20px !important;
        }

        table {
            width: 100% !important;
        }

        th, td {
            padding: 5px;
            text-align: left;
        }

        .Emp-History {
            padding: 10px;
            border: 1px solid #000;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>

    <div class="container">
        <form id="Form1" runat="server">
            <h2 class="CustTitle">Personal Information</h2>
            <div class="form-horizontal MarginBottom20">
                <div class="form-group">
                    <label class="control-label col-md-12 TextLeft">Name:</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Address:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtAddress" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 NoPadding">
                        <label class="control-label col-md-12 TextLeft">City:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtCity" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 NoPadding">
                        <label class="control-label col-md-12 TextLeft">State:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtState" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Zip:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtZip" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-3 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Phone Number:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Mobile Number:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtMobileNumber" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 NoPadding">
                        <label class="control-label col-md-12 TextLeft">E-mail Address:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtEmailAddress" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <h2 class="CustTitle">Position</h2>
            <div class="form-horizontal MarginBottom20">
                <div class="form-group">
                    <div class="col-md-6 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Position You Are Applying For:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtPositionYouAreApplyingFor" runat="server" class="form-control TextLeft"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 NoPadding">
                        <label class="control-label col-md-12 TextLeft">Available Start Date:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtAvailableStartDate" runat="server" class="form-control TextLeft txtAvailableStartDate date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12 NoPadding">
                        <label class="control-label col-md-2 TextLeft">Employment Desired:</label>
                        <div class="checkbox col-md-2">
                            <label>
                                <asp:CheckBox ID="chkFulltime" runat="server" />Full Time
                                <%--<input type="checkbox" name="remember">Full Time--%>
                            </label>
                        </div>
                        <div class="checkbox col-md-2">
                            <label>
                                <asp:CheckBox ID="chkPartTime" runat="server" />Part Time
                                <%--<input type="checkbox" name="remember">Part Time--%>
                            </label>
                        </div>
                        <div class="checkbox col-md-2">
                            <label>
                                <asp:CheckBox ID="chkSeasional" runat="server" />Seasional Temporary
                               <%--<input type="checkbox" name="remember">Seasional Temporary--%>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <h2 class="CustTitle">Education
               

                <asp:Button ID="ButtonAdd" runat="server" class="btn btn-default pull-right" Text="Add New Row" OnClick="ButtonAdd_Click" /></h2>


            <div class="form-horizontal MarginBottom20">
                <div class="form-group">
                    <div class="col-md-12 col-xs-12">



                        <asp:GridView ID="grdEdu" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowCommand="grdEdu_RowCommand" OnRowEditing="grdEdu_RowEditing">
                            <Columns>
                                <asp:TemplateField HeaderText="School Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSchool" Text='<%#Eval("EDU_SchoolName")%>' runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLocation" Text='<%#Eval("EDU_Location")%>' runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year Attended">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYear" runat="server" Text='<%#Eval("EDU_YearAttanded")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Degree Received">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDegreeReceivedeived" runat="server" Text='<%#Eval("EDU_DegreeReceived")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Major">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMajor" runat="server" Text='<%#Eval("EDU_Major")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <%--<asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />--%>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Major">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Edit" Text="Update" />
                                        <asp:HiddenField ID="Hdn_EDU_Id" runat="server" Value='<%#Eval("EDU_Id")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <h2 class="CustTitle">Employment History
                <asp:Button ID="ButtonEmp" runat="server" class="btn btn-default pull-right" Text="Add New Row" OnClick="ButtonEmp_Click" /></h2>
            <div class="form-horizontal MarginBottom20">
                <asp:Repeater ID="rptEmpHistory" runat="server" OnItemCommand="rptEmpHistory_ItemCommand">
                    <ItemTemplate>
                        <div class="Emp-History">
                           
                            <div class="form-group">

                                <div class="col-md-5 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">Employer:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtEmployer" runat="server" Text='<%#Eval("EH_Employer")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-5 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">Job Title:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtJobTitle" runat="server" Text='<%#Eval("EH_JobTitle")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">Dates Employed:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtDatesEmployed" runat="server" Text='<%#Eval("EH_DatesEmployed")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">Address:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtHistoryAddress" runat="server" Text='<%#Eval("EH_Address")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">City:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtHistoryCity" runat="server" Text='<%#Eval("EH_City")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">State:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtHistoryState" runat="server" Text='<%#Eval("EH_State")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 NoPadding">
                                    <label class="control-label col-md-12 TextLeft">Zip:</label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtHistoryZip" runat="server" Text='<%#Eval("EH_Zip")%>' class="form-control TextLeft"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div class="form-group">
                                <div class="col-md-12">
                                     <asp:Button ID="btnRptEdit" runat="server" CommandArgument="<%# Container.DataItem %>" CommandName="Edit" Text="Update" />
                                    <%--<asp:HiddenField ID="HdnhistoryId" runat="server" Value='<%#Eval("EDU_Id")%>' />--%>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <h2 class="CustTitle MarginBottom0">Signature Disclaimer</h2>
            <div class="form-horizontal MarginBottom20">
                <div class="form-group">
                    <div class="col-md-12">
                        <label class="control-label col-md-12 TextLeft CustSubTitle">
                            I certify that my answers are true and complete to the best of my knowledge.<br />
                            If this application leads to employmen, I understand that false or misleading information in my application or interview may result in my release.</label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5 NoPadding">
                        <div class="col-md-12 NoPadding">
                            <label class="control-label col-md-12 TextLeft">Name (Please Print):</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtSignatureName" runat="server" class="form-control TextLeft"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 NoPadding">
                            <label class="control-label col-md-12 TextLeft">Date:</label>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtSignatureDate" runat="server" class="form-control TextLeft"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7 NoPadding">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return Validation();" />
            </div>
        </form>
    </div>



    <script type="text/javascript">
        $(document).ready(function () {
            //$('.txtAvailableStartDate').datetimepicker();

            $('.txtAvailableStartDate').datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                orientation: 'bottom'
            });
        });


        function Validation() {
            var ErrorMsg = "";
            
            if ( $("#txtName").val() == "") {
                ErrorMsg += "Enter Name";
            }







            if (ErrorMsg.length > 0) {
                alert(ErrorMsg)
                return false;
            }
            else {
                return true;
            }
        }
    </script>


</body>
</html>
