using BL;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LinqToExcel;
using Newtonsoft.Json;
using PMMYA.Models;
using PMMYA.SLExcelUtility;
using Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;
using Row = DocumentFormat.OpenXml.Spreadsheet.Row;

namespace PMMYA.Site.LDM
{
    public partial class LDM_Fun : System.Web.UI.Page
    {
        #region Public variable declaration
        private LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        private LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        private Feedback_BL objFeedback_BL = new Feedback_BL();
        private FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        private DataTable dt;
        private DataSet ds;
        private int result = 0;
        public const string SessionExcelData = "SessionExcelData";
        public Excel_ReadEntities db = new Excel_ReadEntities();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GetViewData();
                this.SearchCustomers();
                BindBankList(521);
                GetAllBankDetails();
            }
        }

        public void GetViewData()
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetGridViewData(objLDMFunSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = false;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Empty Does Not Exists";
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //HttpPostedFileBase filebase1 = new HttpPostedFileWrapper(HttpContext.Current.Request.Files["excelFile"]);
            HttpPostedFile filebase = excelFile.PostedFile;
            List<string> data1 = new List<string>();
            if (excelFile != null)
            {
                if (excelFile.PostedFile.ContentType == "application/vnd.ms-excel" || excelFile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = excelFile.FileName;
                    string targetpath = Server.MapPath("~/Files/");
                    excelFile.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    string connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];

                    ExcelQueryFactory excelFiledata = new ExcelQueryFactory(pathToExcelFile);
                    SLExcelData datar = (new SLExcelReader()).ReadExcel(filebase);
                    Session[SessionExcelData] = datar;

                    foreach (List<string> d in datar.DataRows)
                    {
                        objLDMFunSchema.Sr_No = int.Parse(d[0]);
                        objLDMFunSchema.BankName = d[1];
                        objLDMFunSchema.BankBranch = d[2];
                        objLDMFunSchema.IFSCCode = d[3];
                        objLDMFunSchema.App_Reg = d[4];
                        objLDMFunSchema.Loan_Category = d[5];
                        objLDMFunSchema.FirstName = d[6];
                        objLDMFunSchema.MiddleName = d[7];
                        objLDMFunSchema.LastName = d[8];
                        objLDMFunSchema.Gender = d[9];
                        objLDMFunSchema.MaritalStatus = d[10];
                        //objLDMFunSchema.Dob = DateTime.Parse(d[11]);
                        objLDMFunSchema.Dob = DateTime.FromOADate(double.Parse(d[11]));
                        objLDMFunSchema.Village = d[12];
                        objLDMFunSchema.Gram = d[13];
                        objLDMFunSchema.Tehsil = d[14];
                        objLDMFunSchema.Block = d[15];
                        objLDMFunSchema.District = d[16];
                        objLDMFunSchema.Religion = d[17];
                        objLDMFunSchema.Minority_Comm = d[18];
                        objLDMFunSchema.Social_Category = d[19];
                        objLDMFunSchema.Aadhar = d[20];
                        objLDMFunSchema.PAN = d[21];
                        objLDMFunSchema.Mobile = d[22];
                        objLDMFunSchema.Email = d[23];
                        objLDMFunSchema.ReqLoanAmnt = int.Parse(d[24]);
                        objLDMFunSchema.SanctionAmnt = int.Parse(d[25]);
                        //objLDMFunSchema.SanctionDate = DateTime.Parse(d[26]);
                        objLDMFunSchema.SanctionDate = DateTime.FromOADate(double.Parse(d[26]));
                        objLDMFunSchema.Business_Activity = d[27];
                        objLDMFunSchema.Type_Loan = d[28];
                        objLDMFunSchema.DisbursedAmnt = int.Parse(d[29]);
                        //objLDMFunSchema.DisburseDate = DateTime.Parse(d[30]);
                        objLDMFunSchema.DisburseDate = DateTime.FromOADate(double.Parse(d[30]));
                        objLDMFunSchema.LoanAmntOutStanding = int.Parse(d[31]);
                        objLDMFunSchema.Status = d[32];
                        ds = objLDMFunBAL.LDMInsert(objLDMFunSchema);

                    }
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GetViewData();
                btnDownloadSpreadsheet.Visible = true;
            }
        }

        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            //if (cell.CellValue.InnerText == "")
            //{
            //    string emptymsg = "Required";
            //    var text = doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            //}
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }

        public string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public int ConvertColumnNameToNumber(string columnName)
        {
            Regex alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName))
            {
                throw new ArgumentException();
            }

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);
            int convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }
            return convertedValue;
        }

        public IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);
                int currentColumnIndex = ConvertColumnNameToNumber(columnName);
                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    Cell emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }
                yield return cell;
                currentCount++;
            }
        }

        public string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            CellValue cellValue = cell.CellValue;
            string text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            string textEmail = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }
            return (text ?? string.Empty).Trim();
        }

        protected void btnDownloadSpreadsheet_Click(object sender, EventArgs e)
        {
            SLExcelData data = (SLExcelData)Session[SessionExcelData];
            if (data == null)
            {
                lblMsgDownload.Text = "File record does not exists.";
            }
            string path = Server.MapPath("~/Files");
            string fileName = "Spreadsheet.xlsx";
            string fullPath = Path.Combine(path, fileName);
            byte[] file = (new SLExcelWriter()).GenerateExcel(data);

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("Content-Disposition",
                "attachment; filename=ExcelFile.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(file);
            Response.Flush();
            Response.Close();
            Response.End();

            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.ContentType = "application/text";
            //Response.Output.Write(file);
            //Response.Flush();
            //Response.End();

            //Convert.ToBase64String(file);
            //(fullPath, "application/vnd.ms-excel", file);
            //            Response.ContentType(;
            //return new FileContentResult(file,
            //    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            SearchCustomers();
        }

        protected void Search(object sender, EventArgs e)
        {
            SearchCustomers();
        }

        private void SearchCustomers()
        {
            ds = new DataSet();
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                ds = objLDMFunBAL.SearchGridData(txtSearch.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            ds = objLDMFunBAL.SearchGridData(txtSearch.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = false;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        
        public class BankData
        {
            public int BankId { get; set; }
            public string BankName { get; set; }
            public string BranchName { get; set; }
            public string IFSCode { get; set; }
            public string BranchAddress { get; set; }
            public List<BankData> data { get; set; }
        }

        [System.Web.Services.WebMethod]
        public List<BankData> BindBankList(int districtid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            LDMFunSchema objLDMFunSchema = new LDMFunSchema();
            LDMFunBAL objLDMFunBAL = new LDMFunBAL();
            DataTableReader dr;
            //ArrayList list = new ArrayList();
            List<BankData> bankdata = new List<BankData>();
            objLDMFunSchema.Districtid = districtid;            
            ds = objLDMFunBAL.GetBankName(objLDMFunSchema);
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            bankdata = JsonConvert.DeserializeObject<List<BankData>>(str.ToString());
            return bankdata;
        }

        public void GetAllBankDetails()
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllBank(objLDMFunSchema);
            
        }

    }
}