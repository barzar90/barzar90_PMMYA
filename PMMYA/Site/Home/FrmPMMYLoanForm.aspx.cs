using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections;
using Helper;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace PMMYA.Site.Home
{
    public partial class FrmPMMYLoanForm : System.Web.UI.Page
    {

        #region Public variable declaration
        ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
        ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        DataTable dt;
        DataSet ds;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hiddenApplicationId.Value = "";
                BindLoanType();
                BindDistrict();
                BindConstitution();
                BindAddressType();
                BindGender();
                BindEducationQualification();
                // BindProofType();
                // BindKYCDocument();
                BindSocialCategory();
                BindLineofBusiness();
                BindTypeofExistingAccount();
                BindProofType();
                objApplicationFormSchema.ApplicantSessionid = System.Web.HttpContext.Current.Session.SessionID;
                ds = objApplicationFormBAL.GetApplicantDetails(objApplicationFormSchema);
                if (ds != null && (ds.Tables[0].Rows.Count > 0))
                {
                    dt = ds.Tables[0];
                    TxtApplicantName1.Text = dt.Rows[0]["Name"].ToString();
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    TxtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                    ddlLoanType.SelectedValue = dt.Rows[0]["LoanType"].ToString();
                    // ddlLoanType.Items.FindByValue(dt.Rows[0]["LoanType"].ToString()).Selected = true;
                }
            }
        }


        //protected void ddlSocialCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        objApplicationFormSchema.ID = Convert.ToInt32(ddlSocialCategory.SelectedValue);
        //        objApplicationFormSchema.Type = "MinorityCommunity";
        //        ds = new DataSet();
        //        ds = objApplicationFormBAL.GetMinorityCommunityDetails(objApplicationFormSchema);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ddlMinority.Items.Clear();
        //            ddlMinority.DataSource = ds;
        //            ddlMinority.DataTextField = "MinorityCommunityName";
        //            ddlMinority.DataValueField = "ID";
        //            ddlMinority.DataBind();
        //            ddlMinority.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlMinority.SelectedValue = "0";

        //        }
        //        else
        //        {
        //            ddlMinority.Items.Clear();
        //            ddlMinority.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlMinority.SelectedValue = "0";
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {               
                    #region Save And Get Application Id

                objApplicationFormSchema.LoanTypeID = Convert.ToInt32(ddlLoanType.SelectedValue);
                objApplicationFormSchema.LoanAmount = Convert.ToDouble(txtAmount.Text);
                objApplicationFormSchema.Districtid = Convert.ToInt32(ddldistrict.SelectedValue);
                objApplicationFormSchema.Talukaid =  Convert.ToInt32(hdnTaluka.Value);
                objApplicationFormSchema.Bankid = Convert.ToInt32(hdnBankId.Value);
                objApplicationFormSchema.BranchName = Convert.ToString(hdnBranchName.Value);
                objApplicationFormSchema.IFSCCode = TxtIFSC.Text;
                objApplicationFormSchema.BranchAddress = TxtBankAddress.Text;
                objApplicationFormSchema.FirstHolderName = TxtApplicantName1.Text;
                objApplicationFormSchema.SecondHolderName = TxtApplicantName2.Text;
                objApplicationFormSchema.FaterOrHusbandName = TxtFatherName.Text;
                objApplicationFormSchema.ConstitutionID = Convert.ToInt32(ddlConstitution.SelectedValue);
                objApplicationFormSchema.ResidentialAddress = TxtResidentialAdd.Text;
                objApplicationFormSchema.ResiAddresID = Convert.ToInt32(ddlresidenttype.SelectedValue);
                objApplicationFormSchema.BusinessAddress = TxtBusinessAddress.Text;
                objApplicationFormSchema.BusiAddresID = Convert.ToInt32(ddlBusinessAddType.SelectedValue);
                objApplicationFormSchema.DOB = Convert.ToDateTime(TxtDOB.Text);
                objApplicationFormSchema.Age = Convert.ToInt32(TxtAge.Text);
                objApplicationFormSchema.GenderID = Convert.ToInt32(ddlGender.SelectedValue);
                objApplicationFormSchema.EducationID = Convert.ToInt32(ddlQualification.SelectedValue);
                objApplicationFormSchema.KycID_VoterIDNo = TxtIDproofVoterNo.Text;
                objApplicationFormSchema.KycID_AadharNo = TxtIDProofAadharNo.Text;
                objApplicationFormSchema.KycID_DrivingLicNo = TxtIDproofDLN.Text;
                objApplicationFormSchema.KycID_OtherIDNo = TxtIDProofNameAny.Text + "-" + TxtIdProofNumberAny.Text;
                objApplicationFormSchema.KycAddr_VoterIDNo = TxtAddproofVoterNo.Text;
                objApplicationFormSchema.KycAddr_AadharNo = TxtAddProofAadharNo.Text;
                objApplicationFormSchema.KycAddr_DrivingLicNo = TxtAddproofDLN.Text;
                objApplicationFormSchema.KycAddr_OtherIDNo = TxtAddproofNameAny.Text + "-" + TxtAddproofNumberAny.Text;
                objApplicationFormSchema.TelPhNo = TxtTelephone.Text;
                objApplicationFormSchema.MobileNo = TxtMobile.Text;
                objApplicationFormSchema.EmailId = TxtEmail.Text;
                objApplicationFormSchema.BusinessTypeID = Convert.ToInt32(ddlLineofBusiness.SelectedValue);
                objApplicationFormSchema.ExtBusinessPeriod = Convert.ToInt32(TxtPeriod.Text);
                objApplicationFormSchema.AnnualSaleExt = Convert.ToDouble(TxtSalesExisting.Text);
                objApplicationFormSchema.AnnualSaleProp = Convert.ToDouble(TxtSalesProposed.Text);
                objApplicationFormSchema.BusinessExperience = TxtExperience.Text;
                objApplicationFormSchema.SocialCategoryID = Convert.ToInt32(ddlSocialCategory.SelectedValue);
                objApplicationFormSchema.MinorityCategory = Convert.ToInt32(ddlMinority.SelectedValue);
                objApplicationFormSchema.ISExistingAccount = chkExistingAcc.Checked;
                objApplicationFormSchema.ExtAccountType = Convert.ToInt32(ddlExistingAccType.SelectedValue);
                objApplicationFormSchema.ExtBankAccNo = TxtAccountNumber.Text;
                objApplicationFormSchema.ExtBankName = TxtExistingBankName.Text;
                objApplicationFormSchema.ExtLoanAmount = Convert.ToDouble(TxtExistingLoanAmount.Text);
                objApplicationFormSchema.BankloanId= Convert.ToInt32(ddlLoanAccountType.SelectedValue);
                objApplicationFormSchema.BusinessActivity = TxtBusinessActivity.Text;
                //string record = objApplicationFormBAL.InsertLoanApplicationDetails(objApplicationFormSchema);
                //string[] strArray = record.Split(';');
                //if (strArray.Length == 2 && Convert.ToString(strArray[1]) == "Success")
                //{
                //    string Applicationid = string.Empty;
                //    Applicationid = Convert.ToString(strArray[0]);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully. Your Application ID -'" + Applicationid + "');window.location.href='FrmPMMYLoanForm.aspx'", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                //}
                ds = objApplicationFormBAL.SaveAndGetApplicantID(objApplicationFormSchema);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string Applicationid = string.Empty;
                    dt = ds.Tables[0];
                    Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                    string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                    hiddenApplicationId.Value = Applicationid;
                    lblSuccessMsg.Text = sucessmsg;
                    resetcontrols();
                 
                    if (objApplicationFormSchema.LoanTypeID == 1)
                    {
                        string redirectScript = " window.location.href ='FrmShishu.aspx?ApplicationId=" + Applicationid + "'";
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('" + sucessmsg + "');" + redirectScript, true);
                    }
                    else
                    {
                        string redirectScript = " window.location.href ='FrmKishor.aspx?ApplicationId=" + Applicationid + "'";
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('" + sucessmsg + "');" + redirectScript, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                }
                    #endregion
                //}
                //else
                //{
                    
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + msg + "')", true);
                //}
            }

            catch (Exception ee)
            {
                throw ee;
            }
        }


        public void ShowMessage_Redirect(System.Web.UI.Page page, string Message, string Redirect_URL)
        {
            string alertMessage = "<script language=\"javascript\" type=\"text/javascript\">";

            alertMessage += "alert('" + Message + "');";
            alertMessage += "window.location.href=\"";
            alertMessage += Redirect_URL;
            alertMessage += "\";";
            alertMessage += "</script>";

            ClientScript.RegisterClientScriptBlock(GetType(), "alertMessage ", alertMessage);

        }
        public void resetcontrols()
        {
            ddlLoanType.SelectedIndex = 0;
            ddlLoanAccountType.SelectedIndex = 0;
            txtAmount.Text = "";
            ddldistrict.SelectedIndex = 0;
            ddlTaluka.SelectedIndex = 0;
            ddlBankName.SelectedIndex = 0;
            ddlBranchname.SelectedIndex = 0;
            hdnTaluka.Value = "";
            hdnBankId.Value = "";
            hdnBranchName.Value = "";
            TxtIFSC.Text = "";
            TxtBankAddress.Text="";
            TxtApplicantName1.Text = "";
            TxtApplicantName2.Text = "";
            TxtFatherName.Text = "";
            ddlConstitution.SelectedIndex = 0;
            TxtResidentialAdd.Text = "";
            ddlresidenttype.SelectedIndex = 0;
            TxtBusinessAddress.Text = "";
            ddlBusinessAddType.SelectedIndex = 0;
            TxtDOB.Text = "";
            TxtAge.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlQualification.SelectedIndex = 0;
            TxtIDproofVoterNo.Text = "";
            TxtIDProofAadharNo.Text = "";
            TxtIDproofDLN.Text = "";
            TxtIDProofNameAny.Text = "";
            TxtIdProofNumberAny.Text = "";
            TxtAddproofVoterNo.Text = "";
            TxtAddProofAadharNo.Text = "";
            TxtAddproofDLN.Text = "";
            TxtAddproofNameAny.Text = "";
            TxtAddproofNumberAny.Text = "";
            TxtTelephone.Text = "";
            TxtMobile.Text = "";
            TxtEmail.Text = "";
            ddlLineofBusiness.SelectedIndex = 0;
            TxtPeriod.Text = "";
            TxtSalesExisting.Text = "";
            TxtSalesProposed.Text = "";
            TxtExperience.Text = "";
            ddlSocialCategory.SelectedIndex = 0;
            ddlMinority.SelectedIndex = 0;
            chkExistingAcc.Checked = false;
            ddlExistingAccType.SelectedIndex = 0;
            TxtAccountNumber.Text = "";
            TxtExistingBankName.Text = "";
            TxtExistingBankName.Text = "";

        }

        #region BindDropdown Data

        public void BindLoanType()
        {
            objApplicationFormSchema.Type = "LoanType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetLoanTypeDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLoanType.DataSource = ds;
                ddlLoanType.DataTextField = "MudraLoanType";
                ddlLoanType.DataValueField = "ID";
                ddlLoanType.DataBind();
                ddlLoanType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanType.SelectedValue = "0";

            }
            else
            {
                ddlLoanType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanType.SelectedValue = "0";
            }
        }

        public void BindDistrict()
        {
            objFeedback_Schema.Langid = 1;
            ds = new DataSet();
            ds = objFeedback_BL.GetDistrict(objFeedback_Schema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = ds;
                ddldistrict.DataTextField = "Districtname";
                ddldistrict.DataValueField = "Districtcode";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";

            }
            else
            {
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";
            }
        }

        public void BindConstitution()
        {
            objApplicationFormSchema.Type = "Constitution";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetConstitutionDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlConstitution.DataSource = ds;
                ddlConstitution.DataTextField = "ConstitutionName";
                ddlConstitution.DataValueField = "ID";
                ddlConstitution.DataBind();
                ddlConstitution.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlConstitution.SelectedValue = "0";

            }
            else
            {
                ddlConstitution.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlConstitution.SelectedValue = "0";
            }
        }

        public void BindAddressType()
        {
            objApplicationFormSchema.Type = "Resident";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetAddressType(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlresidenttype.DataSource = ds;
                ddlresidenttype.DataTextField = "ResidentAddress";
                ddlresidenttype.DataValueField = "ID";
                ddlresidenttype.DataBind();
                ddlresidenttype.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlresidenttype.SelectedValue = "0";

                ddlBusinessAddType.DataSource = ds;
                ddlBusinessAddType.DataTextField = "ResidentAddress";
                ddlBusinessAddType.DataValueField = "ID";
                ddlBusinessAddType.DataBind();
                ddlBusinessAddType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBusinessAddType.SelectedValue = "0";
            }
            else
            {
                ddlresidenttype.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlresidenttype.SelectedValue = "0";

                ddlBusinessAddType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBusinessAddType.SelectedValue = "0";
            }
        }

        public void BindGender()
        {
            objApplicationFormSchema.Type = "Gender";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetGenderDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlGender.DataSource = ds;
                ddlGender.DataTextField = "Gender";
                ddlGender.DataValueField = "ID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlGender.SelectedValue = "0";

            }
            else
            {
                ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlGender.SelectedValue = "0";
            }
        }

        public void BindEducationQualification()
        {
            objApplicationFormSchema.Type = "Education";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetEducationDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlQualification.DataSource = ds;
                ddlQualification.DataTextField = "EduQualification";
                ddlQualification.DataValueField = "ID";
                ddlQualification.DataBind();
                ddlQualification.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlQualification.SelectedValue = "0";

            }
            else
            {
                ddlQualification.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlQualification.SelectedValue = "0";
            }
        }

        public void BindProofType()
        {
            objApplicationFormSchema.Type = "BankLaonType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetProofType(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLoanAccountType.DataSource = ds;
                ddlLoanAccountType.DataTextField = "LoanType";
                ddlLoanAccountType.DataValueField = "Id";
                ddlLoanAccountType.DataBind();
                ddlLoanAccountType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanAccountType.SelectedValue = "0";

            }
            else
            {
                ddlLoanAccountType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanAccountType.SelectedValue = "0";
            }
        }


        public void BindSocialCategory()
        {
            objApplicationFormSchema.Type = "SocialCategory";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetSocialCategoryDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSocialCategory.DataSource = ds;
                ddlSocialCategory.DataTextField = "SocialCategory";
                ddlSocialCategory.DataValueField = "ID";
                ddlSocialCategory.DataBind();
                ddlSocialCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSocialCategory.SelectedValue = "0";

            }
            else
            {
                ddlSocialCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSocialCategory.SelectedValue = "0";
            }
        }


        //public void BindKYCDocument()
        //{
        //    objApplicationFormSchema.Type = "KYCDoc";

        //    ds = new DataSet();
        //    ds = objApplicationFormBAL.GetKYCDocDetails(objApplicationFormSchema);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        ddlKYCDoc.DataSource = ds;
        //        ddlKYCDoc.DataTextField = "KYCDoc";
        //        ddlKYCDoc.DataValueField = "ID";
        //        ddlKYCDoc.DataBind();
        //        ddlKYCDoc.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlKYCDoc.SelectedValue = "0";

        //    }
        //    else
        //    {
        //        ddlKYCDoc.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlKYCDoc.SelectedValue = "0";
        //    }
        //}


        public void BindLineofBusiness()
        {
            objApplicationFormSchema.Type = "Business";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetBusinessDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLineofBusiness.DataSource = ds;
                ddlLineofBusiness.DataTextField = "BusinessType";
                ddlLineofBusiness.DataValueField = "ID";
                ddlLineofBusiness.DataBind();
                ddlLineofBusiness.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLineofBusiness.SelectedValue = "0";

            }
            else
            {
                ddlLineofBusiness.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLineofBusiness.SelectedValue = "0";
            }
        }

        public void BindTypeofExistingAccount()
        {
            objApplicationFormSchema.Type = "ExtAccType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetTypeofExistingAccount(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlExistingAccType.DataSource = ds;
                ddlExistingAccType.DataTextField = "AccountType";
                ddlExistingAccType.DataValueField = "ID";
                ddlExistingAccType.DataBind();
                ddlExistingAccType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlExistingAccType.SelectedValue = "0";

            }
            else
            {
                ddlExistingAccType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlExistingAccType.SelectedValue = "0";
            }
        }

        [System.Web.Services.WebMethod]
        public static ArrayList PopulateSubDistrict(int DistrictID)
        {

            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();


            objApplicationFormSchema.Districtid = DistrictID;

            ds = objApplicationFormBAL.GetTaluka(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];

                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["SubDistrictname"].ToString(),
                   dr["SubDistrictcode"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }


        [System.Web.Services.WebMethod]
        public static ArrayList BindBankList(int districtid, int talukaid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;

            ds = objApplicationFormBAL.GetBankName(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["BankName"].ToString(),
                   dr["BankID"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }

        [System.Web.Services.WebMethod]
        public static ArrayList BindBranchname(int districtid, int talukaid, int bankid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            FrmPMMYLoanForm objFrmPMMYLoanForm = new FrmPMMYLoanForm();
            ArrayList list = new ArrayList();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;
            objApplicationFormSchema.Bankid = bankid;
            ds = objApplicationFormBAL.GetBranchkName(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["BranchName"].ToString(),
                   dr["IFSCode"].ToString()
                    ));
                }


                return list;
            }
            return list;
        }

        [System.Web.Services.WebMethod]
        public static string BindBranchDetails(string IFSCCode)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            FrmPMMYLoanForm objFrmPMMYLoanForm = new FrmPMMYLoanForm();
            ArrayList list = new ArrayList();
            string result = string.Empty;
            objApplicationFormSchema.IFSCCode = IFSCCode;
            ds = objApplicationFormBAL.GetBranchkDetails(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                result = dt.Rows[0]["BranchAddress"].ToString() + "|" + dt.Rows[0]["IFSCode"].ToString();
            }
            return result;
        }



        [System.Web.Services.WebMethod]
        public static ArrayList BindMinority(int ID)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();
            objApplicationFormSchema.ID = ID;
            objApplicationFormSchema.Type = "MinorityCommunity";

            ds = objApplicationFormBAL.GetMinorityCommunityDetails(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["MinorityCommunityName"].ToString(),
                   dr["ID"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }
        #endregion
    }
}