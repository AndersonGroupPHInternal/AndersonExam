(function () {
    'use strict';

    angular
        .module('App')
        .factory('ExamineeService', ExamineeService);

    ExamineeService.$inject = ['$http'];

    function ExamineeService($http) {
        return {
            Read: Read,
            Percentage: Percentage
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Examinee/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Percentage(examineeId) {
            return $http({
                method: 'POST',
                url: '/Examinee/Percentage/' + examineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();