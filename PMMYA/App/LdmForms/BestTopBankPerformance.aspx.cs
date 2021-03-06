﻿using BL;
using Newtonsoft.Json;
using Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace PMMYA.App.LdmForms
{
    public partial class BestTopBankPerformance : System.Web.UI.Page
    {
        #region Default
        DataSet ds;
        private string Role = string.Empty;
        DataTable dt;
        #endregion 

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"].Value != string.Empty)
                {
                    if ((Session["AuthToken"].ToString() != Request.Cookies["AuthToken"].Value))
                    {
                        Session.Abandon();
                        Session.Clear();
                        Session.RemoveAll();// Abandon the current session
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1); // Clear the ASP.NET_SessionId cookie
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(-1); // Clear the Auth token                      
                        ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "alert('Your login session has expired!-GC!');location.href=('Login.aspx')", true);
                        return;
                    }
                }
                string ddnm = Session["User"].ToString();
                Role = Convert.ToString(Session["UserRole"]);
                TopBestBank(ddnm);                
            }            
        }

        private void TopBestBank(string ddnm)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            LDMFunSchema objLDMFunSchema = new LDMFunSchema();
            LDMFunBAL objLDMFunBAL = new LDMFunBAL();
            objLDMFunSchema.DistrictType = ddnm;
            ds = objLDMFunBAL.GetTopBestBank(objLDMFunSchema);
        
            DataTable ChartData = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
            }


                string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];
            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["BankName"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Amount"]);
            }
            //binding chart control  
            Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);
            //Setting width of line  
            Chart1.Series[0].BorderWidth = 4;
            //setting Chart type   
            Chart1.Series[0].ChartType = SeriesChartType.Pie;            
            foreach (Series charts in Chart1.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Q1": point.Color = Color.Maroon; break;
                        case "Q2": point.Color = Color.OrangeRed; break;

                        case "Q3": point.Color = Color.RoyalBlue; break;
                        case "Q4": point.Color = Color.SaddleBrown; break;
                        case "Q5": point.Color = Color.SpringGreen; break;                        
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
                }
            }
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        }

        #region old
        //public class Data
        //{
        //    public string ColumnName = "";
        //    public int Value = 0;
        //    public Data(string columnName, int value)
        //    {
        //        ColumnName = columnName;
        //        Value = value;
        //    }
        //}

        //[System.Web.Services.WebMethod]
        //public List<Data> TopFiveBanks()
        //{
        //    //DataSet ds;
        //    //DataTable dt = new DataTable();
        //    //LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        //    //LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        //    //ds = objLDMFunBAL.GetBankName(objLDMFunSchema);            
        //    //string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
        //    //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
        //    //string bankdata = JsonConvert.DeserializeObject(str.ToString()).ToString();
        //    //return bankdata;

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        //    LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        //    ds = objLDMFunBAL.GetBankName(objLDMFunSchema);           
        //    dt = ds.Tables[0];
        //    List<Data> dataList = new List<Data>();
        //    //string cat = "";
        //    //int val = 0;
        //    //foreach (DataRow dr in dt.Rows)
        //    //{
        //    //    cat = dr[0].ToString();
        //    //    val = Convert.ToInt32(dr[2]);
        //    //    dataList.Add(new Data(cat, val));
        //    //}
        //    string[] x = new string[dt.Rows.Count];
        //    int[] y = new int[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][2]);
        //    }
        //    Chart1.Series[0].Points.DataBindXY(x, y);
        //    return dataList;
        //}
        #endregion
    }
}