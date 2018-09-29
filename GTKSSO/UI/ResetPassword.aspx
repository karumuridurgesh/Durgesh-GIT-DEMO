<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="GTKSSO.UI.ResetPassword" %>

<!DOCTYPE html>
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>GTKonnect Login</title>
    <link rel="icon" type="image/png" href="../img/favicon-32x32.png" sizes="16x16">
    <link rel="stylesheet" href="../css/style.css">
    <script src="../ClientScrips/jquery-1.6.3.min.js"></script>
    <link href="../css/toastr.css" rel="stylesheet" />
    <script src="../ClientScrips/toastr.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="../ClientScrips/sweetalert.min.js"></script>
  
</head>
<body class="login_body_bg">
    <form id="form1" runat="server" autocomplete="off">
           <asp:ScriptManager ID="ScriptManager1" ScriptMode="Release" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <link href="../css/fonts/Roboto/Roboto-Regular.ttf" rel="stylesheet">

        <div class="container">
            <div class="login">

                <div class="login__form">
                    <a href="" class="logo">
                        <img src="../img/ORG_LOGO.png" alt="Gtkonnect logo" title="Organization logo" /></a>
                    <div class="login__fields">
                        <span class="cstmlabel">Email</span>
                        <div class="field">
                            <input type="text" id="txtEmail" class="input" runat="server" readonly required pattern=".*\S.*" />

                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtNewPassword" class="input" runat="server"  autocomplete="off" autocapitalize="off" />
                            <label for="txtNewPassword" class="label">New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtConfirmPassword" class="input" runat="server" autocomplete="off" />
                            <label for="txtConfirmPassword" class="label">Confirm New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="login__footer">
                            <asp:Button ID="btnSubmit" class="btn" Text="SUBMIT" runat="server" OnClientClick="return Validate();" OnClick="btnSubmit_Click"></asp:Button>
                            <asp:HiddenField ID="CSRFToken" runat="server" />

                        </div>

                    </div>
                    <div class="field forgot_pwd">
                        <a href="Login.aspx">Sign In</a>
                    </div>
                </div>
            </div>
        </div>


        <asp:HiddenField ID="hfCurrdate" runat="server" />
        <asp:HiddenField ID="hfresetToken" runat="server" />
        <asp:Button ID="btnCurrdate" runat="server" Style="display: none" OnClick="btnCurrdate_Click" />
        <script type="text/javascript" language="javascript"> 
            
    function GetDate() {
        document.getElementById('<%=hfCurrdate.ClientID%>').value = new Date();
          document.getElementById('<%=btnCurrdate.ClientID%>').click(); 
            //getEmail();
            }
            function GetAlert(strResult) {
                toastr.clear();
                if (strResult == 'EXP') {
                    toastr.error('Source URL has expired.Please reset your password again.');
                    return false;
                 }
                else if (strResult == 'INV')  {
                    toastr.error('Source URL is invalid.Please try again.');
                     return false;
                }
                else if (strResult == 'SUC') {
                    //alert('Your new password has been saved.');
                    swal({
                        title: "Your new password has been saved.",
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
                     
                }
                else if (strResult == 'ERR') {
                    toastr.error('Reset pasword has failed .Please contact GTKonnect.');
                    return false;
                }
                else if (strResult == 'Email') {
                    toastr.error('Email should not be empty.Source URL has expired.Please reset your password again.');
                    return false;
                }
                else if (strResult == 'URL') {
                    toastr.error('Source URL is invalid.Please try again.');
                    return false;
                }
            }
            function Validate()
            {
                toastr.clear();
                var NewPassword = document.getElementById('<%=txtNewPassword.ClientID%>');
                var ConfirmPassword = document.getElementById('<%=txtConfirmPassword.ClientID%>');
                var EmailId = document.getElementById('<%=txtEmail.ClientID%>');
                if (EmailId.value != '' )
                {
                if (NewPassword.value == '' || ConfirmPassword.value == '') {
                    toastr.warning('New password and confirm Password should not be blank');
                    NewPassword.focus();
                    return false;
                }
                else if (NewPassword.value != ConfirmPassword.value) {
                    toastr.warning('New password and confirm password does not match.');
                    NewPassword.focus();
                    return false;
                }
            }           
            else
{
 toastr.error('Email should not be empty.Source URL has expired.Please reset your password again.');
return false;
}

                 
            }
            <%--function getEmail() {
                alert($('#<%=hfCurrdate.ClientID%>').val());
                $.ajax({
                    type: "POST",
                    url: "ResetPassword.aspx/ValidateToken",
                    contentType: "application/json; charset=utf-8",
                    data: "{'clientDate':'" + $('#<%=hfCurrdate.ClientID%>').val() + "','clientDate':'" + $('#<%=hfresetToken.ClientID%>').val() + "' }",
                    dataType: "json",
                    success: function (mail) {
                        document.getElementById('<%=txtEmail.ClientID%>').value = mail.Email;
                    },
                    failure: function (error) {
                        toastr.error('Source URL has expired.Please reset your password again.');
                        return false;
                    }
                });
            }--%>


        </script>
    </form>
</body>
</html>
