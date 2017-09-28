(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamService', ExamService);

    ExamService.$inject = ['$http'];

    function ExamService($http) {
        return {
            Read: Read
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Exam/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();