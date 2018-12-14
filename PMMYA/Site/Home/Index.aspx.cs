using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using BL;
using Schema;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Collections;
using Helper;

namespace PMMYA.Site.Home
{
    public partial class Index : System.Web.UI.Page
    {
        UserShema objUserShema = new UserShema();
        UserDataBL objUserDataBL = new UserDataBL();
        int LangID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

           
        }


        //public JsonResult VerifyBarcode(string Sel_Barcode)
        //{
        //}
        //[System.Web.Services.WebMethod]
        //public int saveData(string name, string mobile, string description, string loantype, string amount)

        //{

        //    try

        //    {
        //        int result = 1;
        //        //UserShema userShema = new UserShema();
        //        //UserDataBL objUserDataBL = new UserDataBL();
        //        //userShema.Name = name;
        //        //userShema.Mobile = mobile;
        //        //userShema.Description = description;
        //        //userShema.Loantype = loantype;
        //        //userShema.Amount = amount;
        //        //result = objUserDataBL.insertUserData(userShema);


        //        return result;

        //    }


        //    catch

        //    {
        //        return 0;


        //    }

        //}
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            if (LangID == 1)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                
            }
            //Added By K.p
            else if (LangID == 3)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
                           }
            else
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
               
            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            lblWelcomeMsg.Text = _MahaITUC.GetResourceValue("Common", "WelcomeMsg", "");
            Session["WelcomeMsg"] = lblWelcomeMsg.Text;
        }



        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = HttpContext.GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        [System.Web.Services.WebMethod()]
        public static string MudraUserDetails(string name, string mobile, string BusinessPurpose, string loantype, string amount)        
        {
            UserShema objUserShema = new UserShema();
            UserDataBL objUserDataBL = new UserDataBL();
            string mudraresult = string.Empty;
            int result = 0;
            SendSMS objSendSMS = new SendSMS();
            int LangID = 0;


          

            /* Added by Anand For SMS Send Dated on 02-08-2018*/
            string SmsUserName = string.Empty;
            string SmsPwd = string.Empty;
            string SmsSender = string.Empty;
            string SmsMessage = string.Empty;
            string SmsKey = string.Empty;

            SmsUserName = System.Configuration.ConfigurationManager.AppSettings["UserName"].ToString();
            SmsPwd = System.Configuration.ConfigurationManager.AppSettings["Pwd"].ToString();
            SmsSender = System.Configuration.ConfigurationManager.AppSettings["Sender"].ToString();
            SmsKey = System.Configuration.ConfigurationManager.AppSettings["Key"].ToString();
            Index objIndex = new Index();
            // MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            //SmsMessage = HttpContext.Current.Session["WelcomeMsg"].ToString();
            //SmsMessage = objIndex.lblWelcomeMsg.Text;
            //string msg = Convert.ToInt32(Session["WelcomeMsg"]);
            SmsMessage = "Thank you for visiting Pradhan Mantri Mudra Yojana Maharashtra State Website.";
            // End 02-08-2018


            objUserShema.Name = name;
            objUserShema.Mobile = mobile;
            objUserShema.Amount = Convert.ToDecimal(amount);
            objUserShema.Loantype = Convert.ToInt32(loantype);
            objUserShema.Buspurpose = Convert.ToInt32(BusinessPurpose); 
            objUserShema.Applicant_SessionId = System.Web.HttpContext.Current.Session.SessionID; 
            result = objUserDataBL.insertUserData(objUserShema);
            if (result == 1)
            {
                mudraresult = "success";
                objSendSMS.SMSSend(SmsUserName, SmsPwd, SmsSender, objUserShema.Mobile, SmsMessage, SmsKey);
            }
            else
            {
                mudraresult = "Failed";
            }
            return mudraresult;
        }

        // Added by Manish


        [System.Web.Services.WebMethod]
        public static ArrayList PopulateDistrict(int StateID)
        {
            string Langid;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                Langid = "1";

            }
            else { Langid = "2"; }
            ArrayList list = new ArrayList();
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {





                //String strConnString = ConfigurationManager
                //    .ConnectionStrings["conString"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LangID", Langid);
                    cmd.Parameters.AddWithValue("@StateID", StateID);
                    cmd.CommandText = "[Sp_BindDistrictDropDown]";
                    cmd.Connection = objConn;
                    //objConn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["Districtname"].ToString(),
                       sdr["Districtcode"].ToString()
                        ));
                    }
                    objConn.Close();
                    return list;
                }

            }

            catch (Exception ex)
            { }
            return list;
        }

        [System.Web.Services.WebMethod]
        public static ArrayList PopulateSubDistrict(int DistrictID)
        {
            string Langid;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                Langid = "1";

            }
            else { Langid = "2"; }
            ArrayList list = new ArrayList();
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {





                //String strConnString = ConfigurationManager
                //    .ConnectionStrings["conString"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LangID", Langid);
                    cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
                    cmd.CommandText = "[Sp_BindSubDistrictDropDown]";
                    cmd.Connection = objConn;
                    //objConn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["SubDistrictname"].ToString(),
                       sdr["SubDistrictcode"].ToString()
                        ));
                    }
                    objConn.Close();
                    return list;
                }

            }

            catch (Exception ex)
            { }
            return list;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static DropDownnSchema[] PopulateBank(int TalukaID)
        {
            string conn = ConfigurationManager.ConnectionStrings["Local"].ToString();
            DataTable dt = new DataTable();
            List<DropDownnSchema> custList = new List<DropDownnSchema>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SP_PopulateBankDetails", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TalukaID", TalukaID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        DropDownnSchema cust = new DropDownnSchema();
                        cust.BankName = dtrow["BankName"].ToString();
                        cust.BranchAddress = dtrow["BranchAddress"].ToString();
                        cust.BranchManagerName = dtrow["BranchManagerName"].ToString();
                        cust.BranchTelNowithSTDcode = dtrow["BranchTelNowithSTDcode"].ToString();
                        custList.Add(cust);
                    }
                }
            }
            return custList.ToArray();
        }


        [WebMethod]
        public static string GetCustomers(string TalukaID)
        {
            //DataTable dt = new DataTable();
            //dt.TableName = "Customers";
            //dt.Columns.Add("CustomerID", typeof(string));
            //dt.Columns.Add("ContactName", typeof(string));
            //dt.Columns.Add("City", typeof(string));
            //DataRow dr1 = dt.NewRow();
            //dr1["CustomerID"] = 1;
            //dr1["ContactName"] = "Customer1";
            //dr1["City"] = "City1";
            //dt.Rows.Add(dr1);
            //DataRow dr2 = dt.NewRow();
            //dr2["CustomerID"] = 2;
            //dr2["ContactName"] = "Customer2";
            //dr2["City"] = "City2";
            //dt.Rows.Add(dr2);
            //DataRow dr3 = dt.NewRow();
            //dr3["CustomerID"] = 3;
            //dr3["ContactName"] = "Customer3";
            //dr3["City"] = "City3";
            //dt.Rows.Add(dr3);
            //DataRow dr4 = dt.NewRow();
            //dr4["CustomerID"] = 4;
            //dr4["ContactName"] = "Customer4";
            //dr4["City"] = "City4";
            //dt.Rows.Add(dr4);
            //DataRow dr5 = dt.NewRow();
            //dr5["CustomerID"] = 5;
            //dr5["ContactName"] = "Customer5";
            //dr5["City"] = "City5";
            //dt.Rows.Add(dr5);


            string conn = ConfigurationManager.ConnectionStrings["Local"].ToString();
            DataTable dt = new DataTable();
            //List<DropDownnSchema> custList = new List<DropDownnSchema>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SP_PopulateBankDetails", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TalukaID", TalukaID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds.GetXml();
        }
    }
}