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
            var Menuid = sessionStorage.getItem("MENUID");
            var Checkeditems = '';

            jQuery.when(BindMenu(sUserCode)).done(function () {

                var UserParams = { "UserCode": "netwin" }
                $("#user").kendoGrid({
                    dataSource: {
                        page: 0,
                        pageSize: 10,
                        serverPaging: true,
                        serverFiltering: true,


                        transport: {
                            read: {

                                url: "../GTKSSOApi/api/User/GetAllUserInfo",
                                type: "POST",
                                contentType: "application/json",
                                data: UserParams,
                            },
                            parameterMap: function (options, operation) {
                                debugger;
                                if (operation === "read") {

                                    // convert the parameters to a json object
                                    return kendo.stringify(options)

                                }
                            },
                        },

                        schema: {
                            data: "Data", // records are returned in the "data" field of the response
                            total: "Count", // total number of records is in the "total" field of the response
                            fields: {
                                id: "UserID"
                            }
                        },
                    },
                    filterable: {
                        extra: false,
                        showOperators: false,
                        operators: {
                            string: {
                                startswith: "Starts with",
                                eq: "Is equal to",
                                neq: "Is not equal to",
                                contains: "Contains"
                            }
                        }
                    },
                    //change: onChange,
                    selectable: true,
                    scrollable: false,
                    persistSelection: true,
                    navigatable: true,

                    columns: [

                        {
                            title: "Select", template: "<input type='checkbox' id='#=UserCode#'  width = '2%' class='checkbox'  />", width: "2%",
                            headerTemplate: "<input id='checkAll' type='checkbox'  />",
                        },
                        //{
                        //    selectable: true

                        //},
                        {
                            field: "UserCode", title: "User Code", width: "12%",

                        },
                        {
                            field: "UserFirstName", title: "FIRST NAME", width: "10%",

                        },
                        {
                            field: "UserLastName", title: "LAST NAME", width: "10%",

                        },
                        {
                            field: "UserEmail", title: "EMAIL", width: "15%",

                        },
                        {
                            field: "CreatedDt", title: "Created Date", width: "12%",

                        },
                        {
                            field: "UserActive", title: "STATUS", width: "12%",

                        },

                    ],
                    dataBound: onDataBound, 
                    pageable: true,


                });

                var ParentMenuId = sessionStorage.getItem("ParentMenuId");

                $('#divUserSummaryprocess').html('');
                var ParentMenu = sessionStorage.getItem("ParentMenu");
                loadSelectedMenus(ParentMenu, ParentMenuId);
                $('#liSubMenu' + Menuid).addClass('active');


                var MenuFeature = sessionStorage.getItem("MenuFeature");
                $('#lblParent').text(ParentMenu);
                $('#lblMenu').text(MenuFeature);
                BindUserAction(Menuid);
            });
            Array.prototype.remove = function () {
                var what, a = arguments, L = a.length, ax;
                while (L && this.length) {
                    what = a[--L];
                    while ((ax = this.indexOf(what)) !== -1) {
                        this.splice(ax, 1);
                    }
                }
                return this;
            };
            //var checkedIds;
            $("#user").on("click", ".checkbox", function () {
                debugger;
                if ($(this)[0].checked) {
                    var grid = $("#user").data("kendoGrid")
                    var rows = grid.dataSource.data();
                    var count = 0;
                    checkedIds.push($(this)[0].id);
                    for (var i = 0; i < rows.length; i++) {

                        if (window.checkedIds.indexOf(rows[i].UserCode) > -1) { 
                            count = count + 1;
                        }

                    }
                    if (count == rows.length && count != 0) {
                        $('#checkAll')[0].checked = true;
                    }
                    else
                        $('#checkAll')[0].checked = false;
                }
                else {
                    checkedIds.remove($(this)[0].id);
                    $('#checkAll')[0].checked = false;
                }
            });
            $("#user").on("click", '#checkAll', function () {
                debugger;
                var flag = this.checked;
                $('.checkbox').each(function () {
                    debugger;
                    if (this.checked != flag) {
                        debugger;
                        this.click(".checkbox");

                    }
                });
            });
            console.log(checkedIds);
            function onDataBound(e) {
                debugger;
                
                var rows = this.dataSource.view();
                var count = 0;
                debugger;
                for (var i = 0; i < rows.length; i++) {
                    
                    if (window.checkedIds.indexOf(rows[i].UserCode) > -1) {
                        debugger;

                        $("#" + rows[i].UserCode)[0].checked = true;
                        count = count + 1;
                    }
                    
                }
                debugger;
                if (count == rows.length && count!=0) {
                    $('#checkAll')[0].checked = true;
                }
                else
                    $('#checkAll')[0].checked = false;
            };
           
           Checkeditems = window.checkedIds;
            console.log(Checkeditems);
            SSOUserActionEvent = function (ActionCode) {
                debugger;
                if (window.checkedIds.length > 0) {
                    var IntgParams = { "usercodes": window.checkedIds, "Usercode": sUserCode, "AxnCD": "UP" }
                    $.ajax({
                        type: "POST",
                        url: "../GTKSSOApi/api/User/ManageUser",
                        contentType: "application/json",
                        data: JSON.stringify(IntgParams),
                        cache: false,
                        success: function (result) {
                            if (result.Table[0]["result"] == "1") {
                                alert("Successfully Unlocked the accounts.");
                                window.location.href = "usersummary.aspx";
                            }
                        }
                    });

                }
                else {
                    alert('Please select atleat one user.');
                }
            }
            

        }, 500);
    });
});