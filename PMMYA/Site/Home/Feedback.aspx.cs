using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Configuration;
using Schema;
using BL;
using System.Net;

namespace PMMYA.Site.Home
{
    public partial class Feedback : MAHAITPage
    {
        #region Public variable declaration
        Feedback_BL objFeedback_BL =new Feedback_BL();
        FeddbackSchema objFeedback_Schema =new FeddbackSchema ();
        int result=0;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        LoginBL loginBL = new LoginBL();
        DataTable dt;
        DataSet ds;
        #endregion

        #region PageEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
            {
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                {
                    BreadCrum.Visible = false;
                }
            } 
            if (!IsPostBack)
            {
               
                //For Numeric KeyPad in mobile, tablet
                if (MAHAITPage.isMobileBrowser() != string.Empty)
                {
                    txtMobile.Attributes.Add("type", "tel");
                }
                ViewState["IsRefresh"] = true;
            }
            
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            BindDistrict();
            lblDistrict.Text = _MahaITUC.GetResourceValue("FeedBack", "LblDistrict", "");
            lblFeedbackHeading.Text= _MahaITUC.GetResourceValue("FeedBack", "lblFeedbackHeading", "");
            lblName.Text = _MahaITUC.GetResourceValue("FeedBack", "lblName", "");
            lblEmail.Text = _MahaITUC.GetResourceValue("FeedBack", "lblEmail", "");
            lblMobile.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMobile", "");
            lblSub.Text = _MahaITUC.GetResourceValue("FeedBack", "lblSub", "");
            btnSubmit.Text = _MahaITUC.GetResourceValue("FeedBack", "btnSubmit", "");
            btnReset.Text = _MahaITUC.GetResourceValue("FeedBack", "btnReset", "");
            lblFeedback.Text= _MahaITUC.GetResourceValue("FeedBack", "lblDescription", "");
            lblMandatory.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMandatory", "");

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() != Convert.ToString(ViewState["PreviousCulture"]))
            {
                ResetControls(false);
                ShowData();
            }

            ViewState["PreviousCulture"] = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            if (ViewState["IsRefresh"] == null || Convert.ToBoolean(ViewState["IsRefresh"]))
            {
                ViewState["IsRefresh"] = false;
                //ucCaptcha.RefreshQuestion();
            }
        }
        #endregion

        #region Methods
        private void ShowData()
        {   
            
            rfvName.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
            RfvEmail.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "RfvEmail", "");
            revEmail.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revEmail", "");
            revMobile.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revMobile", "");
            rfvddldistrict.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvDistrict", "");
            rfvFeedback.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");          
            rfvSubject.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvSubject", "");
            this.Page.Title = _MahaITUC.GetResourceValue("FeedBack", "PageTitle", ""); ;
        }

        private void ResetControls(Boolean RefreshQuestion)
        {
            txtName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMobile.Text = String.Empty;
            TxtSubject.Text = String.Empty;
            txtFeedback.Text = String.Empty;
            txtimgcode.Text= String.Empty;
           
            
        }

        private Boolean validatedata()
        {
            Boolean isvalid = true;
            string txtcap = "";
            if (txtimgcode.Text ==null)
            {
                txtcap = _MahaITUC.GetResourceValue("FeedBack", "txtCaptcha", "");
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + txtcap + "');", true);
                isvalid = false; 
            }
            return isvalid;
        }
        #endregion

        #region ButtonEvents
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatedata() == true)
                {
                    string validate = "";

                    if (txtName.Text.Trim() == String.Empty)
                    {
                        validate=_MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('"+ validate + "');", true);
                        txtName.Focus();
                        return;
                    }

                    if (txtFeedback.Text.Trim() == String.Empty)
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        txtFeedback.Focus();
                        return;
                    }
                    
                   
                    if (txtimgcode.Text != Session["CaptchaImageText"].ToString())
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "txtCaptchavalid", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        return;
                    }

                    objFeedback_Schema.Name = txtName.Text.Trim();
                    objFeedback_Schema.Email = txtEmail.Text.Trim();
                    objFeedback_Schema.Contact = txtMobile.Text.Trim();
                    objFeedback_Schema.Subject = TxtSubject.Text.Trim();
                    objFeedback_Schema.Message = txtFeedback.Text.Trim();
                    objFeedback_Schema.Districtid = Convert.ToInt32(ddlDistrict.SelectedValue);


                    objFeedback_Schema.CreatedOn = DateTime.Now;
                    if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 2;
                    }
                    else if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 1;
                    }
                    else
                    {
                        objFeedback_Schema.Langid = 3;
                    }



                    result = objFeedback_BL.SaveFeedbackDeatails(objFeedback_Schema);         
                    if (result > 0)
                    {
                        string mailcc = string.Empty;
                        string mailto = string.Empty;
                        string mailfrom = string.Empty;
                        string mailSubject = string.Empty;
                        string mailBody = string.Empty;
                        string Hostname = string.Empty;
                        string Port = string.Empty;

                        mailfrom = "rechargeme2016@gmail.com";
                        mailto = txtEmail.Text.Trim();
                        mailSubject = TxtSubject.Text.Trim();
                        mailBody = txtFeedback.Text.Trim();
                        Port = ConfigurationManager.AppSettings["port"];
                        Hostname= ConfigurationManager.AppSettings["host"];
                        objFeedback_Schema.Districtid = Convert.ToInt32(ddlDistrict.SelectedValue);
                        ds = objFeedback_BL.GetDPOEmail(objFeedback_Schema);
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {                       
                            mailcc = dt.Rows[0]["Email_Id"].ToString();
                        }

                        SendEmail(mailfrom, mailto, mailSubject, mailBody, Hostname, Port, mailcc, "");

                        string savemsg = "";
                        savemsg = _MahaITUC.GetResourceValue("FeedBack", "Savemessage", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('"+ savemsg + "');", true);

                    }
                    ResetControls(true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('" + ex.Message + "')", true);
                return;
            }
            finally
            {
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls(true);
        }
        #endregion

        #region SendEmail
        private void SendEmail(string From, string To, string Subject, string Message, string hostAddress, string portaddress, string cc, string bcc)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(From, To, Subject, Message);

                if (cc != string.Empty)
                    message.CC.Add(cc);
                if (bcc != string.Empty)
                    message.Bcc.Add(bcc);
                SmtpClient client = new SmtpClient(hostAddress, Convert.ToInt32(portaddress));
                client.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "rechargeme2016@gmail.com"; //From;//"rechargeme2016@gmail.com ";
                NetworkCred.Password = ConfigurationManager.AppSettings["EmailPassword"];//"Pass@123";
                client.UseDefaultCredentials = true;
                client.Credentials = NetworkCred;
                client.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                client.TargetName = "STARTTLS/smtp.gmail.com";
                client.Send(message);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private String GetURL(String strURLPath)
        {
            String strOrgUrl = Request.Url.OriginalString;
            String strPathQuery = Request.Url.PathAndQuery;
            String strSiteUrl = String.Empty;

            strSiteUrl = strOrgUrl.Replace(HttpUtility.UrlDecode(strPathQuery), string.Empty);
            if (strOrgUrl == strSiteUrl)
            {
                strSiteUrl = strOrgUrl.Replace(strPathQuery, string.Empty);
            }

            strURLPath = strURLPath.Replace("~", strSiteUrl);

            return strURLPath;
        }

        public void BindDistrict()
        {

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                objFeedback_Schema.Langid = 1;
            }
            else
            {
                objFeedback_Schema.Langid = 2;
            }

            ds = new DataSet();
            ds = objFeedback_BL.GetDistrict(objFeedback_Schema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                ddlDistrict.DataSource = ds;
                ddlDistrict.DataTextField = "Districtname";
                ddlDistrict.DataValueField = "Districtcode";
                ddlDistrict.DataBind();
                if (objFeedback_Schema.Langid == 1)
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistrict.SelectedValue = "0";
                }
                else
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--निवडा--", "0"));
                    ddlDistrict.SelectedValue = "0";                   
                }
                
            }
            else
            {
                if (objFeedback_Schema.Langid == 1)
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistrict.SelectedValue = "0";
                }
                else
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--निवडा--", "0"));
                    ddlDistrict.SelectedValue = "0";
                }
            }
        }
    }
}