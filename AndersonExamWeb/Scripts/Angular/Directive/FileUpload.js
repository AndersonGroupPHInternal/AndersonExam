(function () {
    'use strict';

    angular
        .module('App')
        .directive('fileModel', fileModel);

    fileModel.$inject = ['$parse', '$filter'];

    function fileModel($parse, $filter) {
        // Usage:
        //     <file-Model="angular model"></fileModel>
        // http://angularcode.com/simple-file-upload-example-using-angularjs/ 
        // 
        var directive = {
            link: link,
            restrict: 'A'
        };

        return directive;

        function link(fileModel, element, attrs, controller, $transclude) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            //we can put this as central variable if there are other upload function
            // other

            element.bind('change', function () {
                fileModel.$apply(function () {
                    var file = element[0]
                    modelSetter(fileModel, file);
                });
            });

            fileModel.$watch(function (newValue) {
                if (newValue.model.documentFile === undefined && newValue.model.documentFile === null) {
                    element.val(null);
                }
            });

        }
    }

})();