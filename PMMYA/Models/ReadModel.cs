using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMMYA.Models
{
    public class ReadModel
    {
        public int Ph_Sec_Id { get; set; }
        public int Sr_No { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string IFSCCode { get; set; }
        public string App_Reg { get; set; }
        public string Loan_Category { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime Dob { get; set; }
        public string Village { get; set; }
        public string Gram { get; set; }
        public string Tehsil { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string Religion { get; set; }
        public string Minority_Comm { get; set; }
        public string Social_Category { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int ReqLoanAmnt { get; set; }
        public int SanctionAmnt { get; set; }
        public DateTime SanctionDate { get; set; }
        public string Business_Activity { get; set; }
        public string Type_Loan { get; set; }
        public int DisbursedAmnt { get; set; }
        public DateTime DisburseDate { get; set; }
        public int LoanAmntOutStanding { get; set; }
        public string Status { get; set; }

    }
}