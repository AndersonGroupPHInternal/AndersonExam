(function () {
    'use strict';

    angular
        .module('App')
        .factory('ChoiceService', ChoiceService);

    ChoiceService.$inject = ['$http'];

    function ChoiceService($http) {
        return {
            Create: Create,
            Read: Read,
            Update: Update,
            Delete: Delete
        }

        function Create(choice) {
            return $http({
                method: 'PUT',
                url: '/Choice/Create',
                data: $.param(choice),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(questionId) {
            return $http({
                method: 'POST',
                url: '/Choice/Read/' + questionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(choice) {
            return $http({
                method: 'POST',
                url: '/Choice/Update',
                data: $.param(choice),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(choice) {
            return $http({
                method: 'DELETE',
                url: '/Choice/Delete',
                data: $.param(choice),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();