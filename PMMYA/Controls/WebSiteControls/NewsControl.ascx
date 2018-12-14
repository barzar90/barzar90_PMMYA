<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.NewsControl" %>
<%--<div class="col-md-3 col-sm-12 col-xs-12">--%>


    <div class="ticker-container">
			  <div class="ticker-caption">
				<p>Latest News</p>
			  </div>

        <ul>
            <asp:Repeater ID="RptrWhatsNew" runat="server" OnItemCommand="RptrWhatsNew_ItemCommand">
                <ItemTemplate>
                    <div>
                    <li>                     
                      <span>
                            <asp:HyperLink ID="hypViewFile" runat="server" Target="_blank" CssClass="news-acolor" Text='<%# Eval("News") %>'
                                NavigateUrl='<%#  Eval("URL") %>'></asp:HyperLink>
                      <%--    <a href="../../NewsMore.aspx">read more</a>--%>
                         <asp:HyperLink ID="lnkmore" NavigateUrl="~/Site/Home/NewsMore.aspx" runat="server"> read more..</asp:HyperLink>

                        </span>
                    </li>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </ul>




		</div>
