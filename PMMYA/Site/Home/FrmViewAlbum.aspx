<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="FrmViewAlbum.aspx.cs" Inherits="PMMYA.Site.Home.FrmViewAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
   
    
    <h1><asp:Label ID="lblAlbum" runat="server"></asp:Label></h1>
     <div class="photoalbum_index">
        <asp:ListView ID="LV_Events" runat="server">
            <ItemTemplate>
            </ItemTemplate>
            <ItemTemplate>
                <dl>
                    <dt><a href='<%# "/Site/Home/FrmViewSubAlbum.aspx?ID=" + Eval("PhotoAlbumID")%>'
                        title="">
                        <asp:Image CssClass="img-responsive motivational-img" ID="Image1" runat="server" alt="" ImageUrl='<%# Eval("FileName")%>' /></a></dt>
                    <dd>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Name")%>'></asp:Literal>
                    </dd>
                </dl>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
            </LayoutTemplate>
        </asp:ListView>
         <div class="clear">
                    </div>
    </div>
    <div class="clear"></div>
    

</asp:Content>
