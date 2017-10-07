(function () {
    'use strict';

    angular
        .module('App')
        .factory('ImageQuestionService', ImageQuestionService);

    ImageQuestionService.$inject = ['$http'];

    function ImageQuestionService($http) {
        return {
            Create: Create,
            CreateImage: CreateImage,
            Read: Read,
            Update: Update,
            Delete: Delete
        }
        function Create(questionImage) {
            return $http({
                method: 'POST',
                url: '/QuestonImage/Create',
                data: $.param(questionImage),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function CreateImage(questionImage) {
            var data = {
                questionId: questionImage.QuestionId,
                file: questionImage.Attachment.files[0]
            };
            var getModelAsFormData = function (data) {
                var dataAsFormData = new FormData();
                angular.forEach(data, function (value, key) {
                    dataAsFormData.append(key, value);
                });
                return dataAsFormData;  
            };
            return $http({
                method: 'POST',
                url: '/QuestionImage/QuestionAddImage',
                data: getModelAsFormData(data),
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
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