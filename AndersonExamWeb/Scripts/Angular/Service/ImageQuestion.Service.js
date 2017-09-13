(function () {
    'use strict';

    angular
        .module('App')
        .factory('ImageQuestionService', ImageQuestionService);

    ImageQuestionService.$inject = ['$http'];

    function ImageQuestionService($http) {
        return {
            Create: Create,
            Read: Read,
            Update: Update,
            Delete: Delete
        }
        
        function Create(questionImage) {
            return $http({
                method: 'PUT',
                url: '/QuestionImage/Create',
                data: $.param(questionImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(questionId) {
            return $http({
                method: 'POST',
                url: '/QuestionImage/Read/' + questionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(questionImage) {
            return $http({
                method: 'POST',
                url: '/QuestionImage/Update',
                data: $.param(questionImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(questionImage) {
            return $http({
                method: 'DELETE',
                url: '/QuestionImage/Delete',
                data: $.param(questionImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();