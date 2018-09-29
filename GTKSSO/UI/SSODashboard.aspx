<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/MasterPages/GTKMst.Master" CodeBehind="SSODashboard.aspx.cs" Inherits="GTKSSO.UI.SSODashboard" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .col-md-2.wdthFix{
                width: 10% !important;
        }
        .k-list-container {
            width: 394px !important;
            background-color: #fff !important;
                border: 1px solid #bfbfbf;
        }

        .k-list-container li{
                border: 0px solid transparent;
        }
        /*.k-list-container .k-list {
            padding-left: 12px !important;
            list-style: none;
            border: 1px solid #b3b3b3;
            margin-bottom: 0 !important;
                
        }*/

        .k-panelbar-expand, .k-panelbar-collapse{
            right: inherit;
        }
        
        #products {
            width: 400px !important;
        }
        .k-select {
            display: none !important;
        }
        .divClear{float: right;
    z-index: 9999999999;
    position: absolute;
    right: 0;
    top: 0;
        }
        .divClear:hover{cursor:pointer;}
        .divClear .fa{ font-size: 13px;
color: #333;
padding-top: 8px;
padding-right: 8px;
opacity: 0.3;}


        .prdSearch{    
    padding-left: 30px;
    margin-top: 20px;
    float: left;
    position: relative;}


        .prdSearch .k-dropdown-wrap.k-state-default{
        background: #fff;
    padding: 0;
    border-width: 0;
    height:auto;
    border: 1px solid #bfbfbf;
    
}



.prdSearch .k-dropdown-wrap .k-input{
   padding: 0;
   padding-top: 3px;
height: 24px !important;
}


    </style>
    <div class="demo-section k-content row">
        <div class="prdSearch">
            <div id="divClear" class="divClear"><i class="fa fa-refresh"></i></div>
                <input id="products" style="width: 400px;" />
    </div>
        </div>
    <div id="divSecDashBLinks"><div class="loadIcon"> <i class="fa fa-refresh fa-spin"></i></div></div>
         <script type="text/javascript">
            var sUserCode = '<%=UserCode%>';
         </script>
        <script type="text/javascript">
            //$('#divSecDashBLinks').html('<div class="loadIcon"> <i class="fa fa-refresh fa-spin"></i></div>');
            require(
                [
                    'GTKMaster',
                    'SSODashboard'
                ], function () {
                    
                });
        </script>
</asp:Content>
