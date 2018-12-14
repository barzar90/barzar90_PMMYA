using BL;
using Newtonsoft.Json;
using Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Site.Home
{   
    public partial class Financer : System.Web.UI.Page
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
            BindDistrict();
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
        public class BankData
        {
            public string BankName { get; set; }
            public string BranchName { get; set; }
            public string IFSCode { get; set; }
            public string BranchAddress { get; set; }
            public List<BankData> data { get; set; }
        }

        [System.Web.Services.WebMethod]
        public static List<BankData> BindBankList(int districtid, int talukaid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            //ArrayList list = new ArrayList();
            List<BankData> bankdata = new List<BankData>();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;

            ds = objApplicationFormBAL.GetBankData(objApplicationFormSchema);

            //if (ds != null)
            //{
            //    dt = ds.Tables[0];
            //    dr = dt.CreateDataReader();
            //    while (dr.Read())
            //    {
            //        bankdata.Add(new BankData()
            //        {
            //            BankName = dr["BankName"].ToString(),
            //            BranchName = dr["BranchName"].ToString(),
            //            BranchAddress = dr["BranchAddress"].ToString(),
            //            IFSCode = dr["IFSCode"].ToString()
            //        });
            //    }
            //    return bankdata;
            //}

            string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            bankdata = JsonConvert.DeserializeObject<List<BankData>>(str.ToString());

            return bankdata;
        }
    }
}