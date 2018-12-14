using BL;
using PMMYA.Site.Home;
using Schema;
using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Site.LDM
{
    public partial class LDMFunctionality : System.Web.UI.Page
    {
        #region Public variable declaration
        LDMFunctionalitySchema objLDMFunctionalitySchema = new LDMFunctionalitySchema();
        LDMFunctionalityBAL objLDMFunctionalityBAL = new LDMFunctionalityBAL();

        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        DataTable dt;
        DataSet ds;
        int result = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBankName();
                getGrdLDMFunctionality();


            }
        }

        public void BindBankName()
        {
            objLDMFunctionalitySchema.Type = "BankName";
            ds = new DataSet();
            ds = objLDMFunctionalityBAL.GetAllBankName(objLDMFunctionalitySchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBankName.DataSource = ds;
                ddlBankName.DataTextField = "BankName";
                ddlBankName.DataValueField = "BankID";
                ddlBankName.DataBind();
                ddlBankName.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBankName.SelectedValue = "0";

            }
            else
            {
                ddlBankName.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBankName.SelectedValue = "0";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objLDMFunctionalitySchema.BankId = Convert.ToInt32(ddlBankName.SelectedValue);
                objLDMFunctionalitySchema.NumOfAppReceive = Convert.ToInt32(txtNumOfAppReceive.Text);
                objLDMFunctionalitySchema.NumOfAppApprove = Convert.ToInt32(txtNumOfAppApprove.Text);
                objLDMFunctionalitySchema.NumOfAppReject = Convert.ToInt32(txtNumOfAppReject.Text);
                objLDMFunctionalitySchema.TotAmntApprove = Convert.ToInt32(txtTotAmntApprove.Text);
                objLDMFunctionalitySchema.TotAmntRejecte = Convert.ToInt32(txtTotAmntRejecte.Text);
                objLDMFunctionalitySchema.TotAmntOfRecovery = Convert.ToInt32(txtTotAmntOfRecovery.Text);

                //objLDMFunctionalitySchema.DistrictId = Convert.ToInt32(DistrictId.Text); //Get DisttId hdn input Number
                //objLDMFunctionalitySchema.InsertFrom = Convert.ToInt32(InsertFrom.Text);
                //objLDMFunctionalitySchema.InsertBy = Convert.ToInt32(InsertBy.Text);
                objLDMFunctionalitySchema.InsertOn = (System.DateTime.Now);

                if (Request.QueryString["action"] == "edit")
                {
                    if (FileUpload.HasFile)
                    {
                        string filenameExt = FileUpload.FileName;
                        string fileExt = System.IO.Path.GetExtension(FileUpload.FileName);
                        objLDMFunctionalitySchema.FileExt = fileExt;
                        if (fileExt == ".XLSX" || fileExt == ".XLS")
                        {
                            if (CommonFuntion.check_Extensions(filenameExt))
                            {
                                Stream fs = null;
                                fs = FileUpload.PostedFile.InputStream;
                                BinaryReader br1 = new BinaryReader(fs);
                                byte[] filebytes = FileUpload.FileBytes;
                                if (CommonFuntion.isValidFile(filebytes, CommonFuntion.FileType.Image, FileUpload.PostedFile.ContentType))
                                {
                                    String ext = FileUpload.FileName;
                                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                    if (extention.ToLower() == "XLSX" || extention.ToLower() == "XLS")
                                    {

                                        objLDMFunctionalitySchema.InsertFrom = "edit";
                                        //result = objLDMFunctionalityBAL.SaveLDMFFile(objLDMFunctionalitySchema);
                                        ds = objLDMFunctionalityBAL.SaveLDMFunctionality(objLDMFunctionalitySchema);

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            string Applicationid = string.Empty;
                                            dt = ds.Tables[0];
                                            Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');", true);
                                            string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                                            hiddenApplicationId.Value = Applicationid;
                                            lblSuccessMsg.Text = sucessmsg;
                                            resetcontrols();
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                                        }
                                    }
                                }
                                else
                                { lblerror.Text = "Please Upload Excel File only"; }
                            }
                            else
                            { lblerror.Text = "Please Upload Excel File only"; }
                        }
                        else
                        { lblerror.Text = "Please Upload Excel File only"; }
                    }
                    else
                    {
                        objLDMFunctionalitySchema.InsertFrom = "edit";
                        ds = objLDMFunctionalityBAL.SaveLDMFunctionality(objLDMFunctionalitySchema);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            resetcontrols();
                            lblerror.Text = "";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                        }
                    }
                }

                else
                {
                    if (FileUpload.HasFile)
                    {
                        Stream fs = null;
                        fs = FileUpload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        string filenameExt = FileUpload.FileName;

                        string fileExt = System.IO.Path.GetExtension(FileUpload.FileName);
                        objLDMFunctionalitySchema.FileExt = fileExt;
                        if (fileExt == ".xlsx" || fileExt == ".xls")
                        {
                            byte[] pdffile = FileUpload.FileBytes;
                            if (CommonFuntion.check_Extensions(filenameExt))
                            {
                                if (CommonFuntion.isValidFile(pdffile, CommonFuntion.FileType.XLSX, FileUpload.PostedFile.ContentType))
                                {
                                    String ext = FileUpload.FileName;
                                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                    if (extention.ToLower() == "xlsx" || extention.ToLower() == "xls")
                                    {
                                        objLDMFunctionalitySchema.InsertFrom = "Insert";
                                        ds = objLDMFunctionalityBAL.SaveLDMFunctionality(objLDMFunctionalitySchema);

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            string Applicationid = string.Empty;
                                            dt = ds.Tables[0];
                                            Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                                            string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');", true);
                                            hiddenApplicationId.Value = Applicationid;
                                            lblSuccessMsg.Text = sucessmsg;
                                            resetcontrols();
                                            lblerror.Text = "";
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                                        }
                                    }
                                }
                                else
                                {
                                    lblerror.Text = "Please Upload Excel File only";
                                }
                            }
                            else
                            {
                                lblerror.Text = "Please Upload Excel File only";
                            }
                        }
                        else
                        {
                            lblerror.Text = "Please Upload Excel File only";
                        }
                    }
                    else
                    {
                        objLDMFunctionalitySchema.InsertFrom = "Insert";
                        ds = objLDMFunctionalityBAL.SaveLDMFunctionality(objLDMFunctionalitySchema);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            string Applicationid = string.Empty;
                            dt = ds.Tables[0];
                            Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                            string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');", true);
                            hiddenApplicationId.Value = Applicationid;
                            lblSuccessMsg.Text = sucessmsg;
                            resetcontrols();
                            lblerror.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                        }
                    }
                }
                
                //ds = objLDMFunctionalityBAL.SaveLDMFunctionality(objLDMFunctionalitySchema);
                //    if (ds != null && ds.Tables[0].Rows.Count > 0)
                //    {
                //        string Applicationid = string.Empty;
                //        dt = ds.Tables[0];
                //        Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                //        string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                //        hiddenApplicationId.Value = Applicationid;
                //        lblSuccessMsg.Text = sucessmsg;
                //        resetcontrols();                   
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                //    }
            }

            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void resetcontrols()
        {
            ddlBankName.SelectedIndex = 0;
            txtNumOfAppReceive.Text = "";
            txtNumOfAppApprove.Text = "";
            txtNumOfAppReject.Text = "";
            txtTotAmntApprove.Text = "";
            txtTotAmntRejecte.Text = "";
            txtTotAmntOfRecovery.Text = "";
            lblerror.Text = "";
        }


        public void getGrdLDMFunctionality()
        {
            //objLDMFunctionalitySchema.Type = "BankName";
            ds = new DataSet();
            ds = objLDMFunctionalityBAL.getGrdLDMFunctionality(objLDMFunctionalitySchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ldmGridFunction.DataSource = ds.Tables[0];
                ldmGridFunction.DataBind();
            }
            else
            {
                grdMessage.Text = "No Record Found.";
            }
        }


        //protected void UploadFile(object sender, EventArgs e)
        //{
        //    string folderPath = Server.MapPath("~/Files/");

        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }

        //    //Save the File to the Directory (Folder).
        //    FileUpload.SaveAs(folderPath + Path.GetFileName(FileUpload.FileName));

        //    //Display the success message.
        //    lblMessage.Text = Path.GetFileName(FileUpload.FileName) + " has been uploaded.";
        //}

    }
}