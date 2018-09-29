var requires = {
    // Base URL for the entire js files.
    baseUrl: '../../../../GTKSSO/app/',
    // Adding cache bust so that browsers dont cache the files.
    urlArgs: "",// + (new Date()).getTime(),
    //Removed bust=1 value in urlArgs to resolve Query Parameter in SSL Request vulnerability
    // This is the base paths for the common modules for the entire project
    paths: {
        'domReady': 'bower_components/domready/ready.min',
        'text': 'bower_components/text/text',
        'kendo': 'bower_components/kendo-ui-core/kendo.all.min',
        'jquery': 'bower_components/jquery-1.4.1',
        'jquery-ui': 'bower_components/jquery/jquery-ui-1.11.4',
        'bootstrap': 'bower_components/bootstrap/dist/js/bootstrap.min',
        'NProgress': 'bower_components/nprogress/nprogress',
        'jszip': 'bower_components/kendo-ui-core/jszip.min',
        'toastr': 'bower_components/toastr/toastr.min',
        'GTKMaster': 'master',
        'SSODashboard': 'Pages/SSODashboard',
        'appmin': '../dist/js/app.min'
    },
    //waitSeconds: 20,
    shim: {
        "kendo": {
            deps: ["jquery", "jszip"]
        },
        "jquery-ui": {
            exports: "$",
            deps: ['jquery']
        },
        "bootstrap": {
            deps: ['jquery']
        },
        "kendo": {
            deps: ["jquery"]
        },
        //,
        //        'kendoWeb': {
        //            deps: ['jquery']
        //        }
        'toastr':
        {
            deps: ['jquery']
        },
        //'tabs':
        //       {
        //           deps: ['jquery']

        //       },
        //'slimScroll': {
        //    deps:['jquery']
        //},
        'SSODashboard': {
            deps: ['GTKMaster']
        },
        'appmin': {
            deps: ['jquery', 'bootstrap']
        }
    }
};
requirejs.config(requires);