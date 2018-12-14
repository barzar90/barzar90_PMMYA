<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterMenu.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.FooterMenu" %>
<%@ Register Src="~/Controls/WebSiteControls/LastReviewedDate.ascx" TagName="LastReviewedDate"
    TagPrefix="uc1" %>
<%@ Register Src="PlaceHolderControl.ascx" TagName="PlaceHolderControl" TagPrefix="uc4" %>
<%@ Register Src="VisitorCount.ascx" TagName="VisitorCount"
    TagPrefix="uc5" %>
<footer>

    


    <div class="agileinfo_copyright">
        <div class="container">
	<div class="col-md-6" style="margin-top:15px"> <div id="Footermenu1" runat="server">
                </div><br><p>© 2018 Mudra. All rights reserved | Developed by <a href="http://mahait.org/" target="_blank"><img src="../../images/MahaIT_Trans.png" alt=""></a></p></div>
    <div class="col-md-6"><p><uc5:VisitorCount ID="VisitorCount1" runat="server" /></div>
        <div class="clear"></div>
            </div>
	</div>
    

    <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 0;"></span>To Topyle="opacity: 0;">0;"></span>To Top</a>

</footer>
