require([
    'kendo', // Get Kendo Functionalities
    'domReady',
    'jquery',
    'GTKMaster',
    'toastr',
    // Get the user Control

], function (kendo, domReady, $, mstr, toastr) {
    $(document).ready(function () {
        setTimeout(function () {
            jQuery.when(BindMenu(sUserCode)).done(function () {
                $('#divChangePasswordprocess').html('');
                $("#divchangepasswordload").show();
                var ParentMenu = sessionStorage.getItem("ParentMenu");
                var ParentMenuId = sessionStorage.getItem("ParentMenuId");
                loadSelectedMenus(ParentMenu, ParentMenuId);
                var Menuid = sessionStorage.getItem("MENUID");
                var MenuFeature = sessionStorage.getItem("MenuFeature");
                $('#liSubMenu' + Menuid).addClass('active');
                $('#lblParent').text(ParentMenu);
                $('#lblMenu').text(MenuFeature);
            $(document).on('click', '.btn', function () {
                var txtOldPwd = document.getElementById('txtOldPassword');
                var txtNewPwd = document.getElementById('txtNewPassword');
                var txtRetype = document.getElementById('txtConfirmPassword');

                var msg = '';

                debugger;

                if (txtOldPwd.value == '') {
                    msg += 'Old password cannot be empty';
                    if (msg != '') {
                        alert(msg);
                        txtOldPwd.focus();
                        return false;

                    }

                }
                else if (txtNewPwd.value == '') {
                    msg += '\n New password cannot be empty';
                    if (msg != '') {
                        alert(msg);
                        txtNewPwd.focus();
                        return false;


                    }

                }

                else if (txtRetype.value == '') {
                    msg += '\n Confirm password cannot be empty';
                    if (msg != '') {
                        alert(msg);
                        txtRetype.focus();
                        return false;


                    }

                }
                else if (txtNewPwd.value != txtRetype.value) {
                    txtNewPwd.value = '';
                    txtRetype.value = '';
                    msg += '\n Passwords don’t match';
                    if (msg != '') {
                        alert(msg);
                        txtNewPwd.focus();
                        return false;

                    }

                }

                else {
                    var ChgPwdParams = { "Usercode": sUserCode, "OldPassword": txtOldPwd.value, "NewPassword": txtNewPwd.value, "ConfirmPassword": txtRetype.value }
                    debugger;
                    $.ajax({

                        type: "POST",
                        url: "../GTKSSOApi/api/User/ChangePassword",
                        contentType: "application/json",
                        data: JSON.stringify(ChgPwdParams),
                        cache: false,
                        success: function (result) {
                            debugger;
                            if (result.Table[0]["result"] == "1") {
                                alert("Password saved successfully");
                                window.location.href = "Login.aspx";
                            }
                            else if (result.Table[0]["result"] == "0") {
                                debugger;

                                alert("Wrong Password, Try again or select reset password");
                                txtOldPwd.value = '';
                                txtNewPwd.value = '';
                                txtRetype.value = '';
                                txtOldPwd.focus();
                                return false;

                            }
                        }
                    });

                }


            });

            $(document).on('click', '.cancel_btn', function () {
                var txtOldPwd = document.getElementById('txtOldPassword');
                var txtNewPwd = document.getElementById('txtNewPassword');
                var txtRetype = document.getElementById('txtConfirmPassword');
                txtOldPwd.value = '';
                txtNewPwd.value = '';
                txtRetype.value = '';
                txtOldPwd.focus();
            });
        });
        }, 500);
    });
});