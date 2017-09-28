(function () {
    'use strict';

    angular
        .module('App')
        .factory('ImageChoiceService', ImageChoiceService);

    ImageChoiceService.$inject = ['$http'];

    function ImageChoiceService($http) {
        return {
            Create: Create,
            Read: Read,
            Update: Update,
            Delete: Delete
        }

        function Create(choiceImage) {
            return $http({
                method: 'PUT',
                url: '/ChoiceImage/Create',
                data: $.param(choiceImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Read(questionId) {
            return $http({
                method: 'POST',
                url: '/ChoiceImage/Read/' + questionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(questionImage) {
            return $http({
                method: 'POST',
                url: '/ChoiceImage/Update',
                data: $.param(questionImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(choiceImage) {
            return $http({
                method: 'DELETE',
                url: '/ChoiceImage/Delete',
                data: $.param(choiceImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})(); 