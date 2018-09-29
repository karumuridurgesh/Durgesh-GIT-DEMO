//requirejs.config(requires);
require([
    'kendo', // Get Kendo Functionalities
    'domReady',
    'jquery',
    'jquery-ui',
    'bootstrap',
    'appmin'
], function (kendo, domReady, $) { 
    window.checkedIds = [];
    $(document).ready(function () {
        var SSOMainMenu = "";
        var SSOSubMenu = "";
        var SSOMenu = "";
        var SSOMenuID = "";
        var SSOURL = "";
        var SSOUserAction = "";
         
        BindMenu = function (UserCode) {
            var dfrd1 = $.Deferred();
            var UserValidation = [];
            //var UserCode = "";
            UserValidation.push(UserCode);
            $.ajax({
                type: "POST",
                url: "../GTKSSOApi/api/Home/getMenuDetails",
                contentType: "application/json",
                data: JSON.stringify(UserValidation),
                success: function (response) {
                    SSOMenu = response;
                    
                    SSOMainMenu = SSOMenu.filter(function (item) { if (item.HASCHILDS == 1900) return item; });
                    //alert(SSOMainMenu[0].MenuId);
                    var item = SSOMainMenu.filter(function (item) { if (item.value != "") return item; });
                    if (item != null && item.length > 0) {
                        Srchfilter = kendo.observable({
                            SSOMainMenu: item
                        });
                        
                        $("#SecMainMenu").show();
                        kendo.bind($("#SecMainMenu"), Srchfilter);
                        $('#liGTKSSOMainMenu').addClass('active');
                        $('#liGTKSSOSubMenu').removeClass('active');
                        $('#liGTKSSOFilters').removeClass('active');
                        $('#liGTKSSOUserActions').removeClass('active');
                        $('#liGTKSSOThemes').removeClass('active');

                        $('#control-menu-tab').addClass('active');
                        $('#control-quick-tab').removeClass('active');
                        //$('#divGTKMst_Filterslist').removeClass('active');
                    }
                    else {
                        $("#SecMainMenu").hide();
                    }
                    
                    dfrd1.resolve();
                }
            });

            return dfrd1.promise();
        };
        
        loadSelectedMenus = function (ParentMenu, ParentMenuId, URL) {
            sessionStorage.setItem("ParentMenuId", ParentMenuId);
            debugger;
            //alert(sessionStorage.getItem("ParentMenuId"));
            //if (ParentMenu == "DASHBOARD")
            //{
            //    window.location.href = "ssodashboard.aspx";
            //}
            if (URL != 'null' && URL != '' && URL != undefined) {

                window.location.href = ".." + URL;
            }
            $('#liMainMenu' + ParentMenuId).addClass('active');
            SSOSubMenu = SSOMenu.filter(function (item) { if (item.PARENTFEATURE == ParentMenu && item.MENUFEATURE != ParentMenu) return item; });
            var item = SSOSubMenu.filter(function (item) { if (item.value != "") return item; });
 
            if (item != null && item.length > 0) {
                SrchSubMenu = kendo.observable({
                    SSOSubMenu: item
                });
                $("#SecSubMenu").show();
                kendo.bind($("#SecSubMenu"), SrchSubMenu);
                $('#liGTKSSOMainMenu').removeClass('active');
                $('#liGTKSSOSubMenu').addClass('active');
                $('#liGTKSSOFilters').removeClass('active');
                $('#liGTKSSOUserActions').removeClass('active');
                $('#liGTKSSOThemes').removeClass('active');
                
                $('#SecDashSubMenu').hide();
                $('#control-menu-tab').removeClass('active');
                $('#control-quick-tab').addClass('active');
            }
            else {
                $("#SecSubMenu").hide();
            }
        }
        loadMenuFeature = function (ParentMenu, MenuFeature, MENUID, URL) {
            debugger;
            //SSOMenuID = MENUID;
            sessionStorage.setItem("MENUID", MENUID);
            sessionStorage.setItem("ParentMenu", ParentMenu);
            sessionStorage.setItem("MenuFeature", MenuFeature);
            if (URL != 'null' && URL != '')
            {
                
                window.location.href = ".." + URL;
            }
            
            //if (ParentMenu == "SECURITY") {
            //    if (MenuFeature == "USER MANAGEMENT") { 
            //        window.location.href = "usersummary.aspx";
            //    }
            //    if (MenuFeature == "Change Password") {
            //        window.location.href = "ChangePassword.aspx";
            //    }
            //}

        }
        BindUserAction = function (MenuId) {
            //alert(MenuId);
           
            //var UserValidation1 = [];
            //var UserCode = "";
            var IntgParams = { "MenuId": MenuId }
            //UserValidation1.push(MenuId);
            $.ajax({
                type: "POST",
                url: "../GTKSSOApi/api/User/getGTKSSOUserAxn",
                contentType: "application/json",
                data: JSON.stringify(IntgParams),
                success: function (response) {
                    SSOUserAction = response;
                    //console.log(response);
                     
                    var item = SSOUserAction.filter(function (item) { if (item.value != "") return item; });
                    if (item != null && item.length > 0) {
                         SSOUserActionfilter = kendo.observable({
                            SSOUserAction: item
                        });
                        //console.log(item);
                        //$("#SSOUserAction").show();
                         kendo.bind($("#SSOUserAction"), SSOUserActionfilter);
                         $("#SSOUserAction").show();
                        
                         $('#liGTKSSOMainMenu').removeClass('active');
                         $('#liGTKSSOSubMenu').removeClass('active');
                         $('#liGTKSSOFilters').removeClass('active');
                         $('#liGTKSSOUserActions').addClass('active');
                         $('#liGTKSSOThemes').removeClass('active');

                         $('#control-menu-tab').removeClass('active');
                         $('#control-quick-tab').removeClass('active');
                         $('#control-sidebar-home-tab').addClass('active');
                         
                    }
                     
                   
                }
            });

          
        };
   
        
        
    });
});