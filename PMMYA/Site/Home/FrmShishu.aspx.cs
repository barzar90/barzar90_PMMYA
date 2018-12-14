using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
using System.Data;
using Schema;
using BL;
using System.Configuration;




namespace PMMYA.Site.Home
{

    public partial class FrmShishu : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["ApplicationId"]) != null && Convert.ToString(Request.QueryString["ApplicationId"]) != "")
                {
                    string Applicationid = string.Empty;
                    Applicationid = Request.QueryString["ApplicationId"];
                    GetApplicationDetails(Applicationid);
                    ConvertToPDF(Applicationid);                   
                }
                else
                {
                    Server.Transfer("FrmShishu.aspx");
                }
                   

            }
        }
        private void GetApplicationDetails(string ApplicationId)
        {
            objApplicationFormSchema.ApplicationID = ApplicationId;
            ds = objApplicationFormBAL.GetLoanApplicationDetail(objApplicationFormSchema);
            if  ( ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblApplicationId.Text= Convert.ToString(ApplicationId);
                lblCreatedDate.Text= Convert.ToString(ds.Tables[0].Rows[0]["createdDate"]);
                lblFirstHolderName.Text = Convert.ToString("1. "+ ds.Tables[0].Rows[0]["FirstHolderName"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SecondHolderName"]) != "" )
                {
                    lblSecondHolderName.Text = Convert.ToString("2. " + ds.Tables[0].Rows[0]["SecondHolderName"]);
                }                
                lblFirstHolderFatherName.Text = Convert.ToString("1. " + ds.Tables[0].Rows[0]["FaterOrHusbandName"]);
                LblConstitution.Text= Convert.ToString(ds.Tables[0].Rows[0]["ConstitutionName"]);
                LblResidentialAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResidentialAddress"]);
                LblResidentialAddType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResiAddrType"]);
                LblBusinessAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusinessAddress"]);
                LblBusinessAddType.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiAddrType"]);
                lblDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToShortDateString();
                lblAge.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]);
                LblGender.Text= Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                LblEducationQualification.Text = Convert.ToString(ds.Tables[0].Rows[0]["EduQualification"]);
                lblIdproofVoterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_VoterIDNo"]);
                lblIdproofAadharNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_AadharNo"]);
                lblIdproofDLN.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_DrivingLicNo"]);
                lblIdproofother.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_OtherIDNo"]);
                lblAddproofVoterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_VoterIDNo"]);
                LblAddAadharNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_AadharNo"]);
                LblAddproofDLN.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_DrivingLicNo"]);
                LblAddproofOther.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_OtherIDNo"]);
                LblTelephoneNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["TelPhNo"]);
                LblMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                LblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
                LblLineofBusiness.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusinessType"]);
                LblPeriod.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtBusinessPeriod"]);
                lblAnnualSalesExisting.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnnualSaleExt"]);
                lblAnnualSalesProposed.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnnualSaleProp"]);
                LblExperience.Text= Convert.ToString(ds.Tables[0].Rows[0]["BusinessExperience"]);
                LblSocialCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["SocialCategory"]);
                lblMinority.Text = Convert.ToString(ds.Tables[0].Rows[0]["MinorityCommunity"]);
                lblBankLoanType.Text= Convert.ToString(ds.Tables[0].Rows[0]["BankLoanType"]);
                lblLoanCCOD.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankLoanType"]);
                lblLoanAmountReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanAmount"]);
                LblMudraLoanType.Text = Convert.ToString(ds.Tables[0].Rows[0]["MudraLoanType"]);
                LblLoanccodtermAmmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanAmount"]);
                LblLoanAmountExisting.Text= Convert.ToString(ds.Tables[0].Rows[0]["ExtLoanAmount"]);
                LblExistingLoanType.Text= Convert.ToString(ds.Tables[0].Rows[0]["AccountType"]);
                LblExistingBankNameAdd.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtBankName"]); //+ "; Branch Name:-"+ Convert.ToString(ds.Tables[0].Rows[0]["ExtBankBranch"]);
                LblExistingAccountNo.Text= Convert.ToString(ds.Tables[0].Rows[0]["ExtBankAccNo"]);
                LblLoanAmountExisting.Text= Convert.ToString(ds.Tables[0].Rows[0]["ExtLoanAmount"]);
                lblBankName.Text= Convert.ToString(ds.Tables[0].Rows[0]["BankName"]);
                lblBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                lblBusinessActivity.Text= Convert.ToString(ds.Tables[0].Rows[0]["BusinessActivity"]);
            }
            

        }

        private void ConvertToPDF(string ApplicationId)

        {
            string imagepath = Server.MapPath("~/Images"); Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            string fromusername = ConfigurationManager.AppSettings["userNameEmail"];
            string Tousername = ConfigurationManager.AppSettings["TouserName"];
            string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            string cc1username = ConfigurationManager.AppSettings["NotificationtoDepartment1"];
            string cc2username = ConfigurationManager.AppSettings["NotificationtoDepartment2"];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                addLogo = iTextSharp.text.Image.GetInstance(imagepath + "/logo.png");

                iTextSharp.text.Image BankLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                BankLogo = iTextSharp.text.Image.GetInstance(imagepath + "/logo.png");
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);


                // addLogo.SetAbsolutePosition(0, docWorkingDocument.PageSize.Height - 100)

                pdfDoc.Open();
                addLogo.ScaleToFit(128, 37);
                addLogo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                pdfDoc.Add(addLogo);

                htmlparser.Parse(sr);

                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //MailMessage mm = new MailMessage("rechargeme2016@gmail.com", "manishshende.87@gmail.com");
                using (MailMessage mm = new MailMessage(fromusername, Convert.ToString(LblEmail.Text)))
                {
                    mm.CC.Add(cc1username);
                    mm.CC.Add(cc2username);
                    mm.Subject = "Acknowledgement Receipt PMMY";
                    mm.Body = "Dear Sir,Madam<br/> Your Mudra Loan Registration is done Successfully with Mundra Loan No :" + Convert.ToString(ApplicationId) + "<br/> Regards,<br/> PMMY committee ,Maharashtra";
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "" + Convert.ToString(ApplicationId) +".pdf"));
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = ConfigurationManager.AppSettings["host"];
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = fromusername;//"rechargeme2016@gmail.com ";
                        NetworkCred.Password = EmailPassword;//"Pass@123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                        smtp.TargetName = "STARTTLS/smtp.gmail.com";
                        smtp.Send(mm);

                        //Server.Transfer("FrmPMMYLoanForm.aspx");
                        Response.Redirect("FrmPMMYLoanForm.aspx");
                        
                    }
                }
            }



        }

    }
}