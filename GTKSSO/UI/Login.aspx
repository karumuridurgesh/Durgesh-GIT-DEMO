<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GTKSSO.UI.Login" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>GTKonnect Login</title>
    <link rel="icon" type="image/png" href="../img/favicon-32x32.png" sizes="16x16">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../dist/css/theme_yellow.css"><!--theme color yellow-->
    <script src="../ClientScrips/jquery-1.6.3.min.js"></script>
    <link href="../css/toastr.css" rel="stylesheet" />
    <script src="../ClientScrips/toastr.js"></script>
    <script src="../ClientScrips/FrameBuster.js"></script>
    <style id="antiClickjack">body{display:none !important;}</style>
</head>
        <body class="login_body_bg" onload="FrameBuster()">
<form id="form1" runat="server" autocomplete="off">

        <script type="text/javascript">
</script>

        <!--Google Font - Work Sans-->
        <link href="../css/fonts/Roboto/Roboto-Regular.ttf" rel="stylesheet">

        <div class="container">
            <div class="login">

                <div class="login__form">
                    <a href="Login.aspx" class="logo">
                        <img src="../img/ORG_LOGO.png" alt="client logo" title="Organization logo" /></a>
                    <div class="login__fields">
                        <div class="field">
                            <input type="text" id="txtUser" class="input" runat="server" />
                            <label for="txtUser" class="label">Username</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtPassword" class="input" runat="server" autocomplete="off" />
                            <label for="txtPassword" class="label">Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="login__footer">
                            <asp:Button ID="btnLogin" CssClass="btn" runat="server" OnClientClick="return Validate();" OnClick="btnLogin_Click" Text="SIGN IN" />
                            <asp:HiddenField ID="CSRFToken" runat="server" />

                        </div>
                        <div class="field forgot_pwd">
                            <a href="ForgotPassword.aspx">Forgot password?</a>
                        </div>

                    </div>
                </div>
            </div>
            <div class="powerd_login_gtk"><span><span style="position: relative;top: 3px;">Powered by</span>   <a href="http://www.gtkonnect.com/" rel="noopener noreferrer" target="_blank"><img src="../img/GTK_FLAT_LOGO.png" alt="Gtkonnect logo" Title="Gtkonnect logo" width="110px" /></a></span></div>
        </div>

        <script type="text/javascript" language="javascript">
            
         
            function Validate() {
                toastr.clear();
                var txtUserCode = document.getElementById('<%=txtUser.ClientID%>');
                var txtPassword = document.getElementById('<%=txtPassword.ClientID%>');

                if (txtUserCode.value == '' || txtPassword.value == '') {
                    toastr.warning('User code and Password should not be blank');
                    //txtUserCode.focus();
                    return false;
                }
                else {
                    document.getElementById('<%=btnLogin.ClientID%>').click();
                 }
                 return true;
            }
            function GetAlert(ErrMsg) {
                toastr.clear();
                toastr.warning(ErrMsg);
                return false;
            }

        </script>
    </form>
    </body>

</html>


