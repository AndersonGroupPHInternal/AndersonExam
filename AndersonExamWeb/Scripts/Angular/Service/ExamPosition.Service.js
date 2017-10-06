(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamPositionService', ExamPositionService);

    ExamPositionService.$inject = ['$http'];

    function ExamPositionService($http) {
        return {
            Create: Create,
            Read: Read,
            Delete: Delete
        }

        function Create(examPosition) {
            return $http({
                method: 'PUT',
                url: '/ExamPosition/Create',
                data: $.param(examPosition),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(positionId) {
            return $http({
                method: 'POST',
                url: '/ExamPosition/Read/' + positionId,
                hearders: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(examPosition) {
            return $http({
                method: 'DELETE',
                url: '/ExamPosition/Delete',
                data: $.param(examPosition),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();