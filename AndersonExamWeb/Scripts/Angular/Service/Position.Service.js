(function () {
    'use strict';

    angular
        .module('App')
        .factory('PositionService', PositionService);

    PositionService.$inject = ['$http'];

    function PositionService($http) {
        return {
            Read: Read,
            ReadNotInExamSet: ReadNotInExamSet,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Position/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadNotInExamSet(examSetId) {
            return $http({
                method: 'POST',
                url: '/Position/ReadNotInExamSet/' + examSetId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(position) {
            return $http({
                method: 'DELETE',
                url: '/Position/Delete',
                data: $.param(position),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();