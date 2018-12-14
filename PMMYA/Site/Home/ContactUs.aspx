<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="PMMYA.Site.Home.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.jqueryui.min.js"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.jqueryui.min.css" rel="stylesheet">
     <script type="text/javascript">         
         $(document).ready(function () {
             var pageUrl = '<%=ResolveUrl("~/Site/Home/ContactUs.aspx")%>'
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/BindDpoDetails',                 
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",   
                 success: OnDPOPopulated,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         });

         function OnDPOPopulated(response) {
             PopulateTableControl(response.d, $("#example"));
         }

         function PopulateTableControl(list, control) {

             if (list.length > 0) {
                 control.empty();               

                 var trHTML = '';
                 trHTML += '<thead><tr><th>Srno</th><th>Districtname</th><th>DPO_Name</th><th>office_Address</th><th>Email_Id</th><th>office_Tel_No</th></tr></thead>'

                 $.each(list, function () {

                     trHTML += '<tbody><tr><td>' + this.Srno + '</td><td>' + this.Districtname + '</td><td>' + this.DPO_Name + '</td><td>' + this.office_Address + '</td><td>' + this.Email_Id + '</td><td>' + this.office_Tel_No + '</td></tr> </tbody>';
                 });

                 $('#example').append(trHTML);


             }
             else {
                 control.empty().append('No data found..!');
             }
         }

    </script>

    <script type="text/javascript">
       <%-- $(document).ready(function () {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/ContactUs.aspx")%>';

            $.ajax({
                type: "POST",
                url: pageUrl + '/BindDpoDetails',                
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(response.d);
                }
            });--%>

            //$.ajax({
            //    type: "POST",
            //    url: pageUrl + '/BindDpoDetails',
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (data) {
            //        $("#DpoData").dataTable({
            //            data: data,
            //            columns: [
            //                { "data": "Srno" },
            //                { "data": "Districtname" },
            //                { "data": "DPO_Name," },
            //                { "data": "office_Address" },
            //                { "data": "Email_Id" },
            //                { "data": "office_Tel_No" },
            //            ]
            //        });
            //    }

            //});
        //});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="col-md-12 box-container">
        <div class="box-heading">
            <h4 class="box-title">
                <asp:Label ID="lblContact" runat="server" Text="Contact Us"></asp:Label>
            </h4>
        </div>
        <div class="box-body">
            <div class="container">
                <div class="col-xs-12 col-sm-10">
                    <table id="example" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Sr.No.</th>
                                <th>District Name</th>
                                <th>Name Of District Planning Officer</th>
                                <th>Office Address</th>
                                <th>Email ID</th>
                                <th>Office Tel. No With STD Code</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>

            <div class="clearfix">
            </div>
        </div>

    </div>

   
</asp:Content>
