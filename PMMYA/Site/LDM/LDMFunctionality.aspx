<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="LDMFunctionality.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="PMMYA.Site.LDM.LDMFunctionality" %>

<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../css/msgBoxLight.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/ValidationScripts.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.msgBox.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#SitePH_btnSubmit").click(function () {

                var hdnBankId = document.getElementById('<%= hdnBankId.ClientID%>');
                hdnBankId.value = $('#SitePH_ddlBankName').val();
                <%--var hdnBranchName = document.getElementById('<%= hdnBranchName.ClientID%>');
                document.getElementById('<%=hdnBranchName.ClientID %>').value = " ";--%>              
                //hdnBranchName.value = $("#SitePH_ddlBranchname option:selected").text();

                return Validation();
            });

            function Validation() {
                var txt = "";
                var opMode = "";
                var ddlBankName_selectedIndex = $("#SitePH_ddlBankName").get(0).selectedIndex;
                if (ddlBankName_selectedIndex == 0) {
                    txt += "- Please Select Bank Name.";
                    var opt = 1;
                }

                var txtNumOfAppReceive = $("#SitePH_txtNumOfAppReceive");
                if (txtNumOfAppReceive != null && txtNumOfAppReceive.val() == '') {
                    txt += "<br />  - Please Enter Number of Application Received.";
                    var opt = 1;
                }

                var txtNumOfAppApprove = $("#SitePH_txtNumOfAppApprove");
                if (txtNumOfAppApprove != null && txtNumOfAppApprove.val() == '') {
                    txt += "<br />  - Please Enter Number of Application Approved.";
                    var opt = 1;
                }

                var txtNumOfAppReject = $("#SitePH_txtNumOfAppReject");
                if (txtNumOfAppReject != null && txtNumOfAppReject.val() == '') {
                    txt += "<br />  - Please Enter Number of Application Rejected.";
                    var opt = 1;
                }

                var txtTotAmntApprove = $("#SitePH_txtTotAmntApprove");
                if (txtTotAmntApprove != null && txtTotAmntApprove.val() == '') {
                    txt += "<br />  - Please Enter Total Amount Approved.";
                    var opt = 1;
                }

                var txtTotAmntRejecte = $("#SitePH_txtTotAmntRejecte");
                if (txtTotAmntRejecte != null && txtTotAmntRejecte.val() == '') {
                    txt += "<br />  - Please Enter Total Amount Rejected.";
                    var opt = 1;
                }

                var txtTotAmntOfRecovery = $("#SitePH_txtTotAmntOfRecovery");
                if (txtTotAmntOfRecovery != null && txtTotAmntOfRecovery.val() == '') {
                    txt += "<br />  - Please Enter Total Amount of Recovery.";
                    var opt = 1;
                }

                var broFileUpload = $("#SitePH_FileUpload");
                if (broFileUpload != null && broFileUpload.val() == '') {
                    txt += "<br />  - Please Choose File.";
                    var opt = 1;
                }

                if (opt == "1") {
                    alertPopup("Kindly enter data in below fields.", txt);
                    return false;
                }
            }
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $("#SitePH_txtNumOfAppReceive").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });
        $(function () {
            $("#SitePH_txtNumOfAppApprove").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });
        $(function () {
            $("#SitePH_txtNumOfAppReject").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });
        $(function () {
            $("#SitePH_txtTotAmntApprove").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });
        $(function () {
            $("#SitePH_txtTotAmntRejecte").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });
        $(function () {
            $("#SitePH_txtTotAmntOfRecovery").keyup(function () {
                if (this.value.match(/[^0-9]/g)) {
                    this.value = this.value.replace(/[^0-9]/g, '');
                }
            });
        });

        //function validate() {
        //    var array = ['pdf', 'doc', 'docx', 'txt', 'xlsx', 'ppt', 'zip'];
        //    var xyz = document.getElementById("FileUpload1");
        //    var Extension = xyz.value.substring(xyz.value.lastIndexOf('.') + 1).toLowerCase();
        //    if (array.indexOf(Extension) <= -1) {
        //        alert("Please Upload only pdf,doc,zip,txt.xlsx and ppt extension flle");
        //        return false;
        //    }
        //}

    </script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server" autocomplete="false">
    <asp:Panel ID="Panel1" runat="server">
        <div class="container">
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:HiddenField ID="hdnBankId" runat="server" Value="" />
                    <asp:Label ID="lblBankName" AssociatedControlID="ddlBankName" runat="server" Text="Bank Name"></asp:Label>
                    <asp:DropDownList ID="ddlBankName" runat="server" class="form-control">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtBankValue" runat="server" Visible="false"></asp:TextBox>
                </div>
            </div>

            <asp:HiddenField ID="hdnDistrictId" runat="server" Value="" />

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblNumOfAppReceive" AssociatedControlID="txtNumOfAppReceive" runat="server" Text="Number of Application Received">Number of Application Received
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtNumOfAppReceive" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator Style="color: red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Number of Application Received field is required." ControlToValidate="txtNumOfAppReceive" ValidationGroup="True"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblNumOfAppApprove" AssociatedControlID="txtNumOfAppApprove" runat="server" Text="Number of Application Approved:">Number of Application Approved:
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtNumOfAppApprove" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblNumOfAppReject" AssociatedControlID="txtNumOfAppReject" runat="server" Text="Number of Application Rejected">Number of Application Rejected
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtNumOfAppReject" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblTotAmntApprove" AssociatedControlID="txtTotAmntApprove" runat="server" Text="Total Amount Approved">Total Amount Approved
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtTotAmntApprove" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblTotAmntRejecte" AssociatedControlID="txtTotAmntRejecte" runat="server" Text="Total Amount Rejected">Total Amount Rejected
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtTotAmntRejecte" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <asp:Label ID="lblTotAmntOfRecovery" AssociatedControlID="txtTotAmntOfRecovery" runat="server" Text="Total Amount of Recovery">Total Amount of Recovery
                        <span style="color: red">*</span>
                    </asp:Label>
                    <asp:TextBox ID="txtTotAmntOfRecovery" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>

                    <%--<label for="totAmntOfRecovery">Total Amount of Recovery:<span style="color: red">*</span></label>
                    <input type="text" autocomplete="off" class="form-control" id="totAmntOfRecovery" maxlength="10" onkeypress="return onlyNumbers(event);">--%>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                <div class="form-group">
                    <label for="FileUpload">Upload excel file :<span style="color: red">*</span></label>
                    <asp:FileUpload ID="FileUpload" runat="server" ValidationGroup="True" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Style="color: red" ErrorMessage="Only .xlsx , .xls files are allowed."
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xlsx|.xls)$"
                        ControlToValidate="FileUpload">Only .xlsx , .xls files are allowed.</asp:RegularExpressionValidator>
                    <%--<asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />--%>
                    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
            <div class="container">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                    <div class="form-group">
                        <asp:HiddenField ID="hiddenApplicationId" runat="server" Value="" />
                        <asp:Label ID="lblSuccessMsg" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-sm btn-success" runat="server" ValidationGroup="True" Text="Submit" OnClick="btnSubmit_Click" />
                        <%--ValidationGroup="True"--%>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <h4>Grid Data </h4>
            <asp:GridView CssClass="table table-bordered table-striped" ID="ldmGridFunction" runat="server"
                AllowPaging="True" EmptyDataText="There is no data to display" AutoGenerateColumns="true">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%#  Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bank Name">
                        <ItemTemplate>
                            <%# Eval("BankID") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Number of Application Received">
                        <ItemTemplate>
                            <%# Eval("No_AppliReceived") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Number of Application Approved">
                        <ItemTemplate>
                            <%# Eval("No_AppliApproved") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Number of Application Rejected">
                        <ItemTemplate>
                            <%# Eval("No_AppliRejected") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                                                               <asp:TemplateField HeaderText="Total Amount Approved">
                        <ItemTemplate>
                            <%# Eval("Total_Amt_Approved") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Total Amount Rejected">
                        <ItemTemplate>
                            <%# Eval("Total_Amt_Rejected") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Amount of Recovery">
                        <ItemTemplate>
                            <%# Eval("Total_Amt_Recovery") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                <%--    <asp:TemplateField HeaderText="Upload excel file">
                        <ItemTemplate>
                            <%# Eval("Total_Amt_Approved") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>

                </Columns>
            </asp:GridView>
            <asp:Label ID="grdMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        </div>

    </asp:Panel>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>

