
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/MasterPages/GTKMst.Master" CodeBehind="UserSummary.aspx.cs" Inherits="GTKSSO.UI.UserSummary" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="../css/kendo.silver.min.css" />
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divUserSummaryprocess"><div class="loadIcon"> <i class="fa fa-refresh fa-spin"></i></div></div>
    <div class="integMgrDiv" style="margin-top: 50px;min-height:550px;">
           
            <div class="row">
                <div class="col-md-12" style="margin-top: 15px;">
                    <div class="col-md-12">
            
                        
                        <div id="dvFltrSummry"></div>
                         <div>
            <div id="user"></div>
        </div>
                        </div>
                    
<script type="text/x-kendo-template" id="template2">
 
       
         
       
         
</script>
 
                   
                </div>
            </div>
            <br />
        </div>
 
 <script type="text/javascript">
     var sUserCode = '<%=UserCode%>';
         </script>
    <script type="text/javascript">
    
    require(
        [
            'GTKMaster',
            '../app/Pages/GTKSSOUsers.js'
        ], function () {
        });

    </script>
</asp:Content>
 