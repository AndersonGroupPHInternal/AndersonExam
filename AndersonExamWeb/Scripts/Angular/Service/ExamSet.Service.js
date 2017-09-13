(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamSetService', ExamSetService);

    ExamSetService.$inject = ['$http'];

    function ExamSetService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/ExamSet/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(examSet) {
            return $http({
                method: 'DELETE',
                url: '/ExamSet/Delete',
                data: $.param(examSet),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();