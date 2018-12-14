<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LDM_Fun.aspx.cs" Inherits="PMMYA.Site.LDM.LDM_Fun" %>

<link href="../../Content/bootstrapCopy.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Read and Display Data From an Excel File (.xsl or .xlsx) in ASP.NET</title>
</head>
<body>
    <hr />
    <form id="form1" runat="server">
        <div style="float: none; text-align: center;">
            <asp:Label ID="Label1" runat="server" Font-Bold="True">Please Select Excel File:</asp:Label>
            <asp:FileUpload ID="excelFile" runat="server" class="btn btn-primary" />
            <asp:Button ID="btnImport" runat="server" Text="Import Data" class="btn btn-primary" OnClick="btnImport_Click" />
            <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
            <asp:Label ID="lblMsgDownload" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
            <asp:Button ID="btnDownloadSpreadsheet" runat="server" Text="Download Spreadsheet" class="btn btn-primary" OnClick="btnDownloadSpreadsheet_Click" Visible="False" />
        </div>
        <br />
        <div>
            <div class="container">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                    <div class="form-group">
                        <asp:Label ID="lblSearch" AssociatedControlID="txtSearch" runat="server" Text="Search BankName">Search Bank Name</asp:Label>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" OnTextChanged="Search" MaxLength="30" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5"> 
                    <div class="form-group">
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary"  />
                    </div>
                </div>

            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="OnPaging">
                <HeaderStyle BackColor="#396e9c" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" ItemStyle-Width="100" />
                    <asp:BoundField DataField="BankBranch" HeaderText="Branch Name" ItemStyle-Width="100" />
                    <asp:BoundField DataField="IFSCCode" HeaderText="IFSC Code" ItemStyle-Width="100" />
                    <asp:BoundField DataField="App_Reg" HeaderText="App_Reg" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Loan_Category" HeaderText="Loan Category" ItemStyle-Width="100" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-Width="100" />
                    <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Dob" HeaderText="Date of birth" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Village" HeaderText="Village" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Gram" HeaderText="Gram" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Tehsil" HeaderText="Tehsil" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Block" HeaderText="Block" ItemStyle-Width="100" />
                    <asp:BoundField DataField="District" HeaderText="District" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Religion" HeaderText="Religion" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Minority_Comm" HeaderText="Minority Community" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Social_Category" HeaderText="Social Category" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Aadhar" HeaderText="Aadhar Card" ItemStyle-Width="100" />
                    <asp:BoundField DataField="PAN" HeaderText="PAN Card" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile Number" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Email" HeaderText="Email Id" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ReqLoanAmnt" HeaderText="Request Loan Amount" ItemStyle-Width="100" />
                    <asp:BoundField DataField="SanctionAmnt" HeaderText="Sanction Amount" ItemStyle-Width="100" />
                    <asp:BoundField DataField="SanctionDate" HeaderText="Sanction Date" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Business_Activity" HeaderText="Business Activity" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Type_Loan" HeaderText="Loan Type" ItemStyle-Width="100" />
                    <asp:BoundField DataField="DisbursedAmnt" HeaderText="Disbursed Amount" ItemStyle-Width="100" />
                    <asp:BoundField DataField="DisburseDate" HeaderText="Disburse Date" ItemStyle-Width="100" />
                    <asp:BoundField DataField="LoanAmntOutStanding" HeaderText="Loan Amount Out Standing" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

</body>
</html>
