<%@ Page Language="C#"  MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" AutoEventWireup="true" CodeBehind="BestTopDistrictPerformance.aspx.cs" Inherits="PMMYA.App.LdmForms.BestTopDistrictPerformance" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div class="container">
        <div class="col-xs-12">
            <div class="form-group">
                <h4 style="color: black; font-size: 25px; font-weight: bold; text-align: center !important;">Top 5 Best Performance District</h4>
            </div>
        </div>
        <%-- <asp:Chart ID="Chart1" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"
                    BorderlineWidth="0" Height="360px" Palette="None" PaletteCustomColors="Maroon"
                    Width="380px" BorderlineColor="64, 0, 64">
                    <Titles>
                        <asp:Title ShadowOffset="10" Name="Items" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>--%>
        <%--Add 10-12-18--%>
       <%-- <div>
            <asp:Chart ID="Chart1" runat="server">
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" Name="Dotnet Chart Example" />
                </Legends>
                <Series>
                    <asp:Series Name="Series1" />
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" />
                </ChartAreas>
            </asp:Chart>
        </div>--%>

         <asp:Chart ID="Chart1" runat="server" BackColor="#e9eaeb" 
         Height="360px" Width="380px" >  
        <Titles>  
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>  
        <Series>  
            <asp:Series Name="Default" />  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
        </ChartAreas>  
    </asp:Chart>  


    </div>
</asp:Content>