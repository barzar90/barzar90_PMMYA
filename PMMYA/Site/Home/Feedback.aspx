<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="PMMYA.Site.Home.Feedback" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Captcha"
    TagPrefix="UCCaptcha" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .formLabel {
            width: 260px !important;
            height: 85px !important;
        }
    </style>


    

    <script type="text/javascript" language="javascript">
    function validatenumerics(key) {
        //getting key code of pressed key
        var keycode = (key.which) ? key.which : key.keyCode;
        //comparing pressed keycodes

        if (keycode > 31 && (keycode < 48 || keycode > 57)) {
            //alert(" You can enter only characters 0 to 9 ");
            return false;
        }
        else return true;


    }
</script>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">
        <h1>
            <%--<i class="fa fa-inr"></i>--%>
            <asp:Label ID="lblFeedbackHeading" runat="server" Text="Feedback"></asp:Label></h1>
        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>


    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
        <div class="searchMarg">
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Save" ShowMessageBox="true" ShowSummary="false" CssClass="failureNotification" />
        </div>
        <div class="searchInner searchMarg">
            <div class="form-group col-md-6 col-md-offset-3"><asp:Label ID="lblMandatory" runat="server" CssClass="errorMsg" Text="* denotes mandatory fields" Height="18px" style="color:red;
    font-weight: bolder;"></asp:Label></div>

            

            <div class="form-group col-md-6 col-md-offset-3">
                 <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Please Enter Name" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                 <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" ToolTip=""  CssClass="form-control" MaxLength="254"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Please Enter Email"  Display="None"  SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                       <%-- <asp:FilteredTextBoxExtender ID="fteEmail" runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers"
                            ValidChars="_@." TargetControlID="txtEmail">
                        </asp:FilteredTextBoxExtender>--%>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email-id"
                            ValidationGroup="Save" Display="None" ControlToValidate="txtEmail" ForeColor="Red"
                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" SetFocusOnError="true"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblMobile" AssociatedControlID="txtMobile" runat="server" Text="Mobile"></asp:Label>
                <asp:TextBox ID="txtMobile" runat="server" ToolTip="" CssClass="form-control" MaxLength="10" onkeypress="return validatenumerics(event);"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Mobile Number must be 10-digit number" ControlToValidate="txtMobile"
                            Display="None" ValidationGroup="Save" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                       <%-- <asp:FilteredTextBoxExtender ID="fteEngPhone" runat="server" FilterType="Numbers,Custom"
                            ValidChars="/- ," TargetControlID="txtMobile">
                        </asp:FilteredTextBoxExtender>--%>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                  <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
                  <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control">
                  </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddldistrict" runat="server" ControlToValidate="ddlDistrict"
                            ErrorMessage="Please Select District"  Display="None" InitialValue="0" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
           </div>
             <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblSub" AssociatedControlID="TxtSubject" runat="server" Text="Subject"></asp:Label>
                <asp:TextBox ID="TxtSubject" runat="server" ToolTip="" CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="TxtSubject"
                            ErrorMessage="Please Enter Subject" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblFeedback" AssociatedControlID="txtFeedback" runat="server" Text="Feedback"></asp:Label>
                <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" ToolTip=""></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFeedback" runat="server" ErrorMessage="Please Enter Feedback"
                            ControlToValidate="txtFeedback" Display="None" ValidationGroup="Save" ForeColor="Red"
                            CssClass="errorMsg" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <label>Captcha (पडताळणी संकेतांक कोड)</label>
               <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox>
                <label>
                         <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                                    id="sp_captcha" runat="server" style="color: Red">*</span>
                                <asp:Image ID="Image1" runat="server" Height="50px" Width="220px" ImageUrl="~/Site/Home/captcha.aspx" />

                                <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                                    alt="Refresh Captcha" style="width: 30px; height: 30px;" /></label>
            </div>

             <div class="form-group col-md-6 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="Save"
                            OnClick="btnSubmit_Click" />&nbsp;
                        <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Reset" OnClick="btnReset_Click" />
            </div>

            
        </div>
    </asp:Panel>


</asp:Content>
