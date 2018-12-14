﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" AutoEventWireup="true" CodeBehind="LDMHome.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.LDMHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div class="container">
        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Font-Bold="True">Please Select Excel File:</asp:Label>
                <asp:FileUpload ID="excelFile" runat="server" class="btn btn-primary" Style="width: 50% !important; display: initial !important" />
                <asp:Button ID="btnImport" runat="server" Text="Import Data" class="btn btn-primary" OnClick="btnImport_Click" />

                <asp:Button ID="btnExport" runat="server"  class="btn btn-primary" Text="Export To Excel" OnClick="btnExport_Click" />
                
                <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
                <asp:Label ID="lblMsgDownload" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
                <asp:Button ID="btnDownloadSpreadsheet" runat="server" Text="Download Spreadsheet" class="btn btn-primary" OnClick="btnDownloadSpreadsheet_Click" Visible="False" />
            </div>
        </div>
    </div>

    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5" style="float: right; margin-top: -73px;">
        <div class="form-group">
            <asp:Label ID="lblSearch" AssociatedControlID="txtSearch" runat="server" Text="Search Bank Name"></asp:Label>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" OnTextChanged="Search" MaxLength="30" AutoPostBack="true" Style="width: 50% !important; display: initial !important"></asp:TextBox>
        </div>     
    </div>

    <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped" runat="server"   
        AutoGenerateColumns="false" AllowPaging="true" EmptyDataText="There is no data to display"
        AllowSorting="true" OnPageIndexChanging="OnPaging">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BankName" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="BankBranch" HeaderText="Branch Name" ItemStyle-HorizontalAlign="Left" />           
            <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Left" />            
            <asp:BoundField DataField="Village" HeaderText="Village" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Gram" HeaderText="Gram" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Tehsil" HeaderText="Tehsil" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Block" HeaderText="Block" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="District" HeaderText="District" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ReqLoanAmnt" HeaderText="Request Loan Amount" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="SanctionAmnt" HeaderText="Sanction Amount" ItemStyle-HorizontalAlign="Left" />            
            <asp:TemplateField HeaderText="Sanction Date">
                <ItemTemplate>
                    <%#Eval("SanctionDate", "{0:dd-MM-yyyy}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Business_Activity" HeaderText="Business Activity" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Type_Loan" HeaderText="Loan Type" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DisbursedAmnt" HeaderText="Disbursed Amount" ItemStyle-HorizontalAlign="Left" />            
              <asp:TemplateField HeaderText="Disburse Date">
                <ItemTemplate>
                    <%#Eval("DisburseDate", "{0:dd-MM-yyyy}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LoanAmntOutStanding" HeaderText="Loan Amount Out Standing" ItemStyle-HorizontalAlign="Left" />            
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>
</asp:Content>
