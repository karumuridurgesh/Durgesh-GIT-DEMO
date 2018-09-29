require([
    'kendo',
    'domReady',
    'jquery',
    'text!templates/DashBoard.html',
    'GTKMaster',
    'toastr'
], function (kendo, domReady, $, lnks, mst, toast) {

    //    $(window).on('load', function () {
    $(document).ready(function () {
        setTimeout(function () {
            $('#lblParent').text("SIGN ON DASHBOARD");
                var DashBoardLinks = "";
                var DashBLinks = "";
                var DashBTLinks = "";
                loadDashBLinks = function (RowNumber, LinksType) {
                    $('#products').val('');
                    //$('#divSecDashBLinks').html('<div class="loadIcon"> <i class="fa fa-refresh fa-spin"></i></div>');
                    $("#SecDashBLinks").hide();
                    //if (LinksType == undefined || LinksType == "")
                    //    LinksType=DashSSOSubMenu[0].MENUFEATURE;
                    var UserValidation = [];
                    var UserCode = sUserCode;
                    UserValidation.push(UserCode);
                    if (LinksType == undefined || LinksType == "") {
                        UserValidation.push("");
                    }
                    else {
                        UserValidation.push(LinksType);
                    }

                    $.ajax({
                        type: "POST",
                        url: "../GTKSSOApi/api/DashBoard/getDashBDetails",
                        contentType: "application/json",
                        data: JSON.stringify(UserValidation),
                        cache: false,
                        success: function (data) {
                            DashBLinks = data[0].DashBoardList;
                            DashBTLinks = data[0].DBLinksList
                            $("#products").kendoComboBox({
                                dataTextField: "AppTag",
                                dataValueField: "AppTag",
                                dataSource: DashBTLinks,
                                filter: "contains",
                                placeholder: "Search Customer...",
                                //suggest: true,
                                //index: 2,
                                select: function (e) {
                                    var item = e.item;
                                    var text = item.text();
                                    var IntgParams = { "AppTag": text, "DBLinksList": DashBTLinks }
                                    $.ajax({
                                        type: "POST",
                                        url: "../GTKSSOApi/api/DashBoard/getSrchDashBDetails",
                                        contentType: "application/json",
                                        data: JSON.stringify(IntgParams),
                                        cache: false,
                                        success: function (Srchdata) {
                                            var SrchHfilter = "";
                                            //$("#panelbar").empty();
                                            $('#divSecDashBLinks').html(lnks);
                                            if (Srchdata[0].DashBoardList != null && Srchdata[0].DashBoardList.length > 0) {
                                                SrchHfilter = kendo.observable({
                                                    DashBoardLinks: Srchdata[0].DashBoardList
                                                });
                                                //$("#SecDashBLinks").show();
                                                kendo.bind($("#SecDashBLinks"), SrchHfilter);
                                            }
                                            else {
                                                //$("#SecDashBLinks").hide();
                                            }
                                            var panelBar = $("#panelbar").kendoPanelBar().data("kendoPanelBar");
                                        }
                                    });
                                }
                            });

                            $('#divClear').click(function () {
                                //if ($('#products').val() != '') {
                                debugger;
                                $('#products').data('kendoComboBox').value("");
                                //$('#products').val('');
                                //alert($('#products').val());
                                var SrchCfilter = "";
                                $('#divSecDashBLinks').html(lnks);
                                if (DashBLinks != null && DashBLinks.length > 0) {
                                    SrchCfilter = kendo.observable({
                                        DashBoardLinks: DashBLinks
                                    });
                                    kendo.bind($("#SecDashBLinks"), SrchCfilter);
                                }
                                else {
                                    //$("#SecDashBLinks").hide();
                                }
                                var panelBar = $("#panelbar").kendoPanelBar().data("kendoPanelBar");
                                //}
                            });
                            if (LinksType == undefined || LinksType == "") {
                                jQuery.when(BindMenu(sUserCode)).done(function () {
                                    var ParentMenuId = sessionStorage.getItem("ParentMenuId");
                                    $('#liMainMenu' + ParentMenuId).addClass('active');

                                    var SSODMenu = data[0].AppTypeList;
                                    var DashSSOSubMenu = SSODMenu.filter(function (item) { if (item.AppType != "") return item; });
                                    var item = DashSSOSubMenu.filter(function (item) { if (item.value != "") return item; });
                                    if (item != null && item.length > 0) {
                                        SrchDashSubMenu = kendo.observable({
                                            DashSSOSubMenu: item
                                        });
                                        //$('#divLDashSubMenu').html('<div class="SideloadIcon"> <i class="fa fa-refresh fa-spin"></i></div>');
                                        $("#SecDashSubMenu").show();
                                        kendo.bind($("#SecDashSubMenu"), SrchDashSubMenu);
                                        $('#liGTKSSOMainMenu').removeClass('active');
                                        $('#liGTKSSOSubMenu').addClass('active');
                                        $('#liGTKSSOFilters').removeClass('active');
                                        $('#liGTKSSOUserActions').removeClass('active');
                                        $('#liGTKSSOThemes').removeClass('active');

                                        $('#SecSubMenu').hide();
                                        $('#control-menu-tab').removeClass('active');
                                        $('#control-quick-tab').addClass('active');
                                    }
                                    else {
                                        $("#SecDashSubMenu").hide();
                                    }
                                });
                            }
                            setTimeout(function () {
                                $('#ulSSODashSubMenu li').each(function (i) {
                                    if (i == 0 && (LinksType == undefined || LinksType == ""))
                                        $(this).addClass('active');
                                    else
                                        $(this).removeClass('active');
                                });
                                //if (LinksType != undefined && LinksType != "") {
                                $('#liSSODashSubMenu' + RowNumber).addClass('active');
                                //}
                            }, 600);
                            var Srchfilter = "";
                            //$("#panelbar").empty();
                            $('#divSecDashBLinks').html(lnks);
                            if (DashBLinks != null && DashBLinks.length > 0) {
                                Srchfilter = kendo.observable({
                                    DashBoardLinks: DashBLinks
                                });
                                //$("#SecDashBLinks").show();
                                kendo.bind($("#SecDashBLinks"), Srchfilter);
                            }
                            else {
                                //$("#SecDashBLinks").hide();
                            }
                            var panelBar = $("#panelbar").kendoPanelBar().data("kendoPanelBar");

                        }
                    });
                };
                loadDashBLinks();
                Redirect = function (head, APID) {
                    var links = DashBLinks.filter(function (item2) {
                        if (item2.head == head) {
                            return item2;
                        }
                    });
                    var selectedLink = links[0].items.filter(function (item2) {
                        if (item2.APPId == APID) {
                            return item2;
                        }
                    });
                    var UserValidation = [];
                    var UserCode = sUserCode;
                    var DBName = selectedLink[0].DBName;
                    UserValidation.push(UserCode);
                    UserValidation.push(DBName);
                    $.ajax({
                        type: "POST",
                        url: "../GTKSSOApi/api/DashBoard/getURLDetails",
                        contentType: "application/json",
                        data: JSON.stringify(UserValidation),
                        success: function (data) {
                            if (data != null && data != undefined) {
                                if (data[0].DBName != null && data[0].DBName != "")
                                    window.open(selectedLink[0].URL + "?u=" + data[0].UserCode + "&DBName=" + data[0].DBName);
                                else
                                    window.open(selectedLink[0].URL + "?u=" + data[0].UserCode);
                            }
                        }
                    });
                }
            //});
        }, 500);
    });
});
//});