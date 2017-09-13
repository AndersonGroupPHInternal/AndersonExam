(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamExamSetService', ExamExamSetService);

    ExamExamSetService.$inject = ['$http'];

    function ExamExamSetService($http) {
        return {
            Create: Create,
            Read: Read,
            Delete: Delete
        }

        function Create(examExamSet) {
            return $http({
                method: 'PUT',
                url: '/ExamExamSet/Create',
                data: $.param(examExamSet),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(examSetId) {
            return $http({
                method: 'POST',
                url: '/ExamExamSet/Read/' + examSetId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(examExamSet) {
            return $http({
                method: 'DELETE',
                url: '/ExamExamSet/Delete',
                data: $.param(examExamSet),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();