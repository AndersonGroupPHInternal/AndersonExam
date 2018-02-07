(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamService', ExamService);

    ExamService.$inject = ['$http'];

    function ExamService($http) {
        return {
            Read: Read,
            ReadExamForExaminee: ReadExamForExaminee,
            ReadExamForPosition: ReadExamForPosition,
            ReadExamForTakeExam: ReadExamForTakeExam,
            FilteredRead: FilteredRead,
            Delete: Delete
        }

        function FilteredRead(examFilter) {
            return $http({
          method: 'POST',
          url: '/Exam/FilteredRead',
          data: $.param(examFilter),
          headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
          });
          } 

        function Read() {
            return $http({
                method: 'POST',
                url: '/Exam/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }); 
        }


        function ReadExamForExaminee() {
            return $http({
                method: 'POST',
                url: '/Exam/ReadExamForExaminee/',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadExamForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/Exam/ReadExamForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadExamForTakeExam(examId) {
            return $http({
                method: 'POST',
                url: '/Exam/ReadExamForTakeExam/' + examId,
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