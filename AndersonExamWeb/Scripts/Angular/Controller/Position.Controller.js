(function () {
    'use strict';

    angular
        .module('App')
        .controller('PositionController', PositionController);

    PositionController.$inject = ['$window', 'PositionService', 'ExamPositionService', 'ExamService'];

    function PositionController($window, PositionService, ExamPositionService, ExamService) {
        var vm = this;
        vm.NewExamPosition = {
            PositionId: 0,
            ExamId: 0
        }
        vm.Exams = [];
        vm.Position;
        vm.PositionId;
        vm.SelectedExam = []
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.CreateExamPosition = CreateExamPosition;

        vm.Read = Read;
        vm.ReadExamPosition = ReadExamPosition;
        vm.ReadExamForPosition = ReadExamForPosition

        vm.Delete = Delete;
        vm.DeleteExamPosition = DeleteExamPosition;

        vm.DropDownItems = [];
        vm.MultipleSelected = [];

        function GoToUpdatePage(positionId) {
            $window.location.href = '../Position/Update/' + positionId;
        } 

        function Initialise(positionId) {
            vm.PositionId = positionId;
            Read();
            if (vm.PositionId != undefined) {
            ReadExamPosition();
                ReadExamForPosition();
            }
        }

        function CreateExamPosition() {
            ExamPositionService.Create(vm.MultipleSelected)
                .then(function (response) {
                    vm.ExamPosition = response.data;
                    ReadExamPosition();
                    ReadExamForPosition();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: 'PositionController.Create',
                        text: data,
                        type: 'Error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function Read() {
            PositionService.Read()
                .then(function (response) {
                    vm.Position = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadExamPosition() {
            ExamService.ReadExamForPosition(vm.PositionId)
                .then(function (response) {
                    vm.SelectedExam = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'PositionController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadExamForPosition() {
            ExamService.Read(vm.PositionId)
                .then(function (response) {
                    vm.Exams = response.data;
                })
            .catch(function (result) {
                console.log(result);
                new PNotify({
                    title: 'PositionController.Read',
                    text: result.status + ' ' + result.statusText,
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });
            });
        }

        function Delete(position) {
            PositionService.Delete(position)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function DeleteExamPosition(examPosition) {
            ExamPositionService.Delete(examPosition)
                .then(function (response) {
                    Read();
                    ReadExamPosition();
                    ReadExamForPosition();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
    }
})();