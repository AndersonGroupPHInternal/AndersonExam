(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamService', ExamService);

    ExamService.$inject = ['$http'];

    function ExamService($http) {
        return {
            Read: Read,
            ReadNotInExamSet: ReadNotInExamSet,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Exam/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadNotInExamSet(examSetId) {
            return $http({
                method: 'POST',
                url: '/Exam/ReadNotInExamSet/' + examSetId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(exam) {
            return $http({
                method: 'DELETE',
                url: '/Exam/Delete',
                data: $.param(exam),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();