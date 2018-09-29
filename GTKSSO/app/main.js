({
    appDir: '../../',
    baseUrl: '../../app/',
    dir: '../../dist',
    modules: [
        {
            name: 'main'
        }
    ],
    fileExclusionRegExp: /^(r|build)\.js$/,
    optimizeCss: 'standard',
    removeCombined: true,
    // This is the base paths for the common modules for the entire project
    paths: {
        'domReady': 'bower_components/domready/ready',
        'text': 'bower_components/text/text',
        'kendo': 'bower_components/kendo-ui-core/kendo.all.min',
        'jquery': 'bower_components/jquery-1.4.1',
        'jquery-ui': 'bower_components/jquery/jquery-ui-1.11.4',
        'bootstrap': 'bower_components/bootstrap/dist/js/bootstrap.min',
        'NProgress': 'bower_components/nprogress/nprogress',
        //'kendoWeb': 'bower_components/js/kendo.web.min',
        'jszip': 'bower_components/kendo-ui-core/jszip.min',
        'app': '../../js/app',
        'slimScroll': '../../plugins/slimScroll/jquery.slimscroll',
        'lodash': 'bower_components/lodash/lodash',
        'gtkSummary': 'UserControls/GTKSummary',
        'MasterScript': '../../MasterScript'


    },

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
        }
        //,
        //        'kendoWeb': {
        //            deps: ['jquery']
        //        }
    }

})