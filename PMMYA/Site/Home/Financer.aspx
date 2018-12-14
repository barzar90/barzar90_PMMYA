<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true"EnableEventValidation="false"  ValidateRequest="false" CodeBehind="Financer.aspx.cs" Inherits="PMMYA.Site.Home.Financer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.jqueryui.min.js"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.jqueryui.min.css" rel="stylesheet">
    <script type="text/javascript">
        function PopulateControl(list, control) {
            
            if (list.length > 0) {
               
                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">--Select--</option>');
                $.each(list, function () {
                    control.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            else {
                control.empty().append('<option selected="selected" value="0">--Select--<option>');
            }
        }
        function PopulateSubDistrict() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/Financer.aspx")%>'
            if ($('#SitePH_ddldistrict').val() == "0") {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/PopulateSubDistrict',
                    data: '{DistrictID: ' + $('#SitePH_ddldistrict').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnCitiesPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }

        function OnCitiesPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlTaluka"));
        }
        function BindBankDetails() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/Financer.aspx")%>'

            $.ajax({
                type: "POST",
                url: pageUrl + '/BindBankList',
                data: "{'districtid':'" + $('#SitePH_ddldistrict').val() + "','talukaid':'" + $('#SitePH_ddlTaluka').val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnBankPopulated,
                failure: function (response) {
                    alert(response.d);
                }
            });

        }


        function OnBankPopulated(response) {
            PopulateTableControl(response.d, $("#example"));
        }

        function PopulateTableControl(list, control) {

            if (list.length > 0) {
                control.empty();
                //var table = $('#example');
                //table.html('<table id="example" class="display" style="width: 100%">');
                ////table.append('');
                //table.append('<thead><tr><th>Bank Name</th><th>Branch Name</th><th>Branch Address</th><th>IFSC Code</th></tr></thead>');

                //table.append('<tbody>');

                //for (var i = 0; i < list.length; i++) {
                //    //table.append('<tr><td>Vidarbha Konkan Gramin Bank</td><td>Dhanora</td><td>Main Road  A/p Dhanora Tal Dhanora Dist Gadchiroli 442606 </td><td>BKID0WAINGB</td></tr>');
                //    table.append('<tr><td>' + list[i].BankName + '</td><td>' + list[i].BranchName + '</td><td>' + list[i].BranchAddress + '</td><td>' + list[i].IFSCode + '</td></tr>');                
                //}

                //table.append('</tbody>');
                //table.append('</table>');

                var trHTML = '';
                trHTML+='<thead><tr><th>BankName</th><th>BranchName</th><th>BankAddress</th><th>IFSCCode</th></tr></thead>'

                $.each(list, function () {

                    trHTML += '<tbody><tr><td>' + this.BankName + '</td><td>' + this.BranchName + '</td><td>' + this.BranchAddress + '</td><td>' + this.IFSCode + '</td></tr> </tbody>';
                });

                $('#example').append(trHTML);


            }
            else {
                control.empty().append('No data found..!');
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">

    <div class="col-md-12 box-container">
        <div class="box-heading">
            <h4 class="box-title">
                <asp:Label ID="lblBankDetails" runat="server" Text="Know Your Financer"></asp:Label>
            </h4>
        </div>
        <div class="box-body">
            <div class="container">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                    <div class="form-group">
                        <asp:Label ID="lblDistrict" AssociatedControlID="ddlDistrict" runat="server" Text="District"></asp:Label>
                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" onchange="PopulateSubDistrict();">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                    <div class="form-group">
                        <asp:Label ID="lblTaluka" AssociatedControlID="ddlTaluka" runat="server" Text="Taluka"></asp:Label>
                        <asp:DropDownList ID="ddlTaluka" runat="server" class="form-control" onchange="BindBankDetails();">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="col-xs-12 col-sm-10">
                    <table id="example" class="display" style="width: 100%">
                       <%-- <thead>
                            <tr>
                                <th>BankName</th>
                                <th>BranchName</th>
                                <th>BankAddress</th>
                                <th>IFSCCode</th>
                            </tr>
                        </thead>   --%>                    
                    </table>
                </div>
            </div>

            <div class="clearfix">
            </div>
        </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>
</asp:Content>

