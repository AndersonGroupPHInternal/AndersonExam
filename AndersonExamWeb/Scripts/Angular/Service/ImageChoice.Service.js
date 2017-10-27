(function () {
    'use strict';

    angular
        .module('App')
        .factory('ImageChoiceService', ImageChoiceService);

    ImageChoiceService.$inject = ['$http'];

    function ImageChoiceService($http) {
        return {
            Create: Create,
            CreateImage: CreateImage,
            Read: Read,
            ReadForTakeExam: ReadForTakeExam,
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
        
        function CreateImage(choiceImage) {
            var data = {
                choiceId: choiceImage.ChoiceId,
                file: choiceImage.Attachment.files[0]
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
                url: '/ChoiceImage/ChoiceAddImage',
                data: getModelAsFormData(data),
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        }

        function Read(questionId) {
            return $http({
                method: 'POST',
                url: '/ChoiceImage/Read/' + questionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadForTakeExam(questionId) {
            return $http({
                method: 'POST',
                url: '/ChoiceImage/ReadForTakeExam/' + questionId,
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