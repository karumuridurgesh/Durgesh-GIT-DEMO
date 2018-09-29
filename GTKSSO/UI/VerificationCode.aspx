<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationCode.aspx.cs" Inherits="GTKSSO.UI.VerificationCode" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <title>GTKonnect Login</title>
    <link rel="icon" type="image/png" href="../img/favicon-32x32.png" sizes="16x16">
    <link rel="stylesheet" href="../css/style.css">
</head>

<body class="login_body_bg">
    <form id="form1" runat="server">

        <!--Google Font - Work Sans-->
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab" rel="stylesheet">

        <div class="container">
            <div class="login">

                <div class="login__form">
                    <a href="" class="logo">
                        <img src="../img/ORG_LOGO.png" alt="Gtkonnect logo" title="Organization logo" /></a>
                    <div class="login__fields pt25">

                        <div class="field mb5">
                            <input type="text" id="fieldPassword" class="input" required pattern=".*\S.*" />
                            <label for="fieldPassword" class="label">Verification Code</label>
                            <span class="md-input-bar"></span>

                        </div>
                        <span class="textsmal">Enter two way verification code. </span>
                        <div class="field resend">
                            <a href="#">Resend</a>
                        </div>
                        <div class="login__footer">
                            <button class="btn">SUBMIT</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
