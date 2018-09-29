<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="GTKSSO.UI.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>GTKonnect Login</title>
    <link rel="icon" type="image/png" href="../img/favicon-32x32.png" sizes="16x16">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../dist/css/theme_yellow.css"><!--theme color yellow-->
    <script src="../ClientScrips/jquery-1.6.3.min.js"></script>
        <link href="../css/toastr.css" rel="stylesheet" />
    <script src="../ClientScrips/toastr.js"></script>
      <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="../ClientScrips/sweetalert.min.js"></script>
 
</head>
<body class="login_body_bg">
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <!--Google Font - Work Sans-->
        <link href="../css/fonts/Roboto/Roboto-Regular.ttf" rel="stylesheet">

        <div class="container">
            <div class="login">

                <div class="login__form">
                    <a href="" class="logo">
                        <img src="../img/ORG_LOGO.png" alt="Gtkonnect logo" title="Organization logo" /></a>
                    <h4 class="login_head">Forgot Password</h4>
                    <div class="login__fields">
                        <div class="field">
                            <input type="text" id="txtEmail" runat="server" class="input" />
                            <label for="txtEmail" class="label">Email</label>
                            <span class="md-input-bar"></span>

                        </div>

                        <div class="login__footer">
                            <asp:Button ID="btnNext" CssClass="btn" runat="server" OnClientClick="return Validate();" OnClick="btnNext_Click" Text="NEXT" />
                        </div>
                        
                        <div class="field forgot_pwd">
                            <a href="../UI/Login.aspx">Sign In</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="powerd_login_gtk"><span><span style="position: relative;top: 3px;">Powered by</span>   <a href="http://www.gtkonnect.com/" rel="noopener noreferrer" target="_blank"><img src="../img/GTK_FLAT_LOGO.png" alt="Gtkonnect logo" Title="Gtkonnect logo" width="110px" /></a></span></div>
        </div>
        <asp:HiddenField ID="hfCurrdate" runat="server" />
        <asp:button ID="btnCurrdate" runat="server" style ="display :none" OnClick="btnCurrdate_Click" />

<script type="text/javascript" language="javascript">
    function GetAlert(strResult) {
        toastr.clear();
        var txtEmailVal = document.getElementById('<%=txtEmail.ClientID%>');
        if (strResult == 'success')
        {
            swal({
                title: "A link to reset the password has been emailed to you.",
                type: "warning",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                closeOnConfirm: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        var url = "<%= ResolveUrl("~/UI/Login.aspx")%>";
                        window.location.href = url; 
                    }
                })
            //alert('A link to reset the password has been emailed to you.');
            
        }
        else if (strResult == 'Eval') {
            txtEmailVal.focus();
            toastr.error('Please enter valid email.'); 
            return false;
        }
        else if (strResult == 'Empty') {
            txtEmailVal.focus();
            toastr.error('Please enter an email.');
           
            return false;
        }
        else  
        {
            toastr.error('Please contact GTKonnect.');
            return false;
        }
    }
    function Validate() {
        toastr.clear();
        var txtEmailVal = document.getElementById('<%=txtEmail.ClientID%>');
        if (txtEmailVal.value == '') {
            toastr.error('Please enter an email');
            txtEmailVal.focus();
            return false;
        }
        return true;
    }
    function GetDate() {
        document.getElementById('<%=hfCurrdate.ClientID%>').value = new Date();
        document.getElementById('<%=btnCurrdate.ClientID%>').click();
    }

    </script>

    </form>
    
</body>
</html>
