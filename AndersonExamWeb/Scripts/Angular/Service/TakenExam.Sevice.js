(function () {
    'use strict';

    angular
        .module('App')
        .factory('TakenExamService', TakenExamService);

    TakenExamService.$inject = ['$http'];

    function TakenExamService($http) {
        return {
            Read: Read,
        }

        function Read(examineeId) {
            return $http({
                method: 'POST',
                url: '/TakenExam/Read/' + examineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();