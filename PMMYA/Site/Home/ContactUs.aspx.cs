using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace PMMYA.Site.Home
{
    public partial class ContactUs : System.Web.UI.Page
    {
        #region Public variable declaration    

        int LangID = 0;

        ContactUsSchema objcontact = new ContactUsSchema();
        ContactUsBL objContactUsBL = new ContactUsBL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    GetDpoDetails(LangID);
            //}

        }

        [System.Web.Services.WebMethod]
        public static List<ContactUsSchema> BindDpoDetails(int langID)
        {
            List<ContactUsSchema> DPOData = new List<ContactUsSchema>();

            try
            {
                
                ContactUsSchema objcontact = new ContactUsSchema();
                ContactUsBL objContactUsBL = new ContactUsBL();
                DataSet ds = new DataSet();

                objcontact.Langid = langID;
                ds = objContactUsBL.GetDPODetails(objcontact);


                string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                DPOData = JsonConvert.DeserializeObject<List<ContactUsSchema>>(str.ToString());
                
            }
            catch (Exception EX)
            {

            }
            return DPOData;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                LangID = 2;
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                LangID = 1;
            else
                LangID = 3;
        }
    }
}