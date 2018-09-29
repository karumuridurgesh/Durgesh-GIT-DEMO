<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/MasterPages/GTKMst.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="GTKSSO.UI.ChangePassword" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="../css/style.css">
    <script src="../ClientScrips/jquery-1.6.3.min.js"></script>
    <link href="../css/toastr.css" rel="stylesheet" />
 <%--   <script src="../ClientScrips/toastr.js"></script>
 --%>

    <section class="content">
                            <asp:HiddenField ID="CSRFToken" runat="server" />

         <div id="divChangePasswordprocess"><div class="loadIcon"> <i class="fa fa-refresh fa-spin"></i></div></div>
    <div id ="divchangepasswordload" style="display : none">
               <div class="login">

                <div class="login__form col-sm-12">
                     <h3 class="change_pwd">Change Password</h3>
                    <input style="display:none" type="password" name="fakepasswordremembered"/>
                    <div class="login__fields pt-15 col-sm-6"> 
                        <div class="field">
                            <input type="password" id="txtOldPassword" class="input"   autocomplete="off"/>
                            <label for="txtOldPassword" class="label">Old Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtNewPassword" class="input"    autocomplete="off"   />
                            <label for="txtNewPassword" class="label">New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtConfirmPassword" class="input"  autocomplete="off" />
                            <label for="txtConfirmPassword" class="label">Confirm New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="login__footer">
                            <div class="col-sm-6 pl-0">
                            <%--<asp:Button ID="btnSubmit" class="btn" Text="SUBMIT" runat="server"  ></asp:Button>--%>
                            <input type="button" id="btnSubmit" class="btn" value="Submit" />
                                </div>
                            <span class="cancel_btn"> or <a href="#">Clear</a></></span>
                        </div>

                    </div>
                    
                </div>
            </div>
             
     </div>   

   </section>








   <%-- <div class="container"> 
    <div class="demo-section k-content row">
            <div class="panel">--%>

           <%-- <div class="login">

                <div class="login__form">
                     
                    <div class="login__fields"> 
                        <div class="field">
                            <input type="password" id="txtOldPassword" class="input"   autocomplete="off"/>
                            <label for="txtOldPassword" class="label">Old Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtNewPassword" class="input"    autocomplete="off"   />
                            <label for="txtNewPassword" class="label">New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="field">
                            <input type="password" id="txtConfirmPassword" class="input"  autocomplete="off" />
                            <label for="txtConfirmPassword" class="label">Confirm New Password</label>
                            <span class="md-input-bar"></span>
                        </div>
                        <div class="login__footer">
                            <%--<asp:Button ID="btnSubmit" class="btn" Text="SUBMIT" runat="server"  ></asp:Button>--%>
                            <%--<input type="button" id="btnSubmit" class="btn" value="Submit" />
                        </div>

                    </div>
                    
                </div>
            </div>--%>
        <%--</div>
           
        </div>
        </div>   --%>
    <script type="text/javascript">
        var sUserCode = '<%=UserCode%>';
         </script>
    <script type="text/javascript">
            
            require(
                [
                    'GTKMaster',
                    '../app/Pages/ChangePassword.js'
                ], function () {
                    
                });
    </script>
</asp:Content>