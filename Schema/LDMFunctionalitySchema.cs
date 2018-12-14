using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class LDMFunctionalitySchema
    {
       // public LDMFunctionalitySchema();

        public int BankId { get; set; }        
        public int NumOfAppReceive { get; set; }
        public int NumOfAppApprove { get; set; }
        public int NumOfAppReject { get; set; }
        public int TotAmntApprove { get; set; }
        public int TotAmntRejecte { get; set; }
        public int TotAmntOfRecovery { get; set; }
        public int DistrictId { get; set; }
        public string InsertFrom { get; set; }  //Page and Form
        public string InsertBy { get; set; }
        public DateTime InsertOn { get; set; }

        public string Type { get; set; }

        private string fileExt;
        public string FileExt
        {
            get { return fileExt; }

            set { fileExt = value; }
        }

    }
}
