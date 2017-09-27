(function () {
    'use strict';

    angular
        .module('App')
        .factory('QuestionService', QuestionService);

    QuestionService.$inject = ['$http'];

    function QuestionService($http) {
        return {
            Create: Create,
            Read: Read,
            Update: Update,
            Delete: Delete
        }

        function Create(question) {
            return $http({
                method: 'PUT',
                url: '/Question/Create',
                data: $.param(question),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(examId) {
            return $http({
                method: 'POST',
                url: '/Question/Read/' + examId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(question) {
            return $http({
                method: 'POST',
                url: '/Question/Update',
                data: $.param(question),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(question) {
            return $http({
                method: 'DELETE',
                url: '/Question/Delete',
                data: $.param(question),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();