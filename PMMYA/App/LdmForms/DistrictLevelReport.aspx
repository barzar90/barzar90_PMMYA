<%@ Page Language="C#" MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" AutoEventWireup="true" CodeBehind="DistrictLevelReport.aspx.cs" Inherits="PMMYA.App.LdmForms.DistrictLevelReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">    
     <div class="container">
        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
            <div class="form-group">
                <asp:Button ID="btnExport" class="btn btn-primary" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
            </div>
        </div>
    </div>
  
    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
        <div class="form-group">
            <asp:Label ID="lblSearch" AssociatedControlID="txtSearch" runat="server" Text="Search District Name"></asp:Label>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" OnTextChanged="Search" MaxLength="30" AutoPostBack="true"></asp:TextBox>
        </div>
    </div>

     <asp:GridView ID="grdReport" CssClass="table table-bordered table-striped" runat="server"   
        AutoGenerateColumns="false" AllowPaging="true" EmptyDataText="There is no data to display"
        AllowSorting="true" OnPageIndexChanging="OnPaging">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="District" HeaderText="District Name" ItemStyle-HorizontalAlign="Left" />            
            <asp:BoundField DataField="AnnualTarget" HeaderText="Annual Target" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" /> <%-----------%>
            <asp:BoundField DataField="KisA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" /><%-----------%>
            <asp:BoundField DataField="TarA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" /><%-----------%>
            <asp:BoundField DataField="ShiACsTotalACs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisSanTotalACs" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarDisTotalACs" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" />            
            <asp:BoundField DataField="%ofAchievement" HeaderText="% of Achievement" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Rank" HeaderText="Rank" ItemStyle-HorizontalAlign="Left" />  

        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>

</asp:Content>