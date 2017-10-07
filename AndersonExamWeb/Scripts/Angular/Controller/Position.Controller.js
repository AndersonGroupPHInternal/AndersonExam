(function () {
    'use strict';

    angular
        .module('App')
        .controller('PositionController', PositionController);

    PositionController.$inject = ['$window', 'PositionService', 'ExamPositionService'];

    function PositionController($window, PositionService, ExamPositionService) {
        var vm = this;
        vm.Position;
        vm.PositionId;
        vm.ExamPosition = []
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Read = Read;
        vm.ReadExamPosition = ReadExamPosition;
        vm.Delete = Delete;

        vm.DropDownItems = [];
        vm.MultipleSelected = [];

        function GoToUpdatePage(positionId) {
            $window.location.href = '../Position/Update/' + positionId;
        } 

        function Initialise(positionId) {
            vm.PositionId = positionId;
            Read();
            ReadExamPosition();
            vm.DropDownItems = [
                { DropDownItemId: 0, DropDownItemDescription: 'Description0' },
                { DropDownItemId: 1, DropDownItemDescription: 'Description1' },
                { DropDownItemId: 2, DropDownItemDescription: 'Description2' },
                { DropDownItemId: 3, DropDownItemDescription: 'Description3' },
                { DropDownItemId: 4, DropDownItemDescription: 'Description4' }
            ];
        }

        function Read() {
            PositionService.Read()
                .then(function (response) {
                    vm.Position = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: daata,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadExamPosition() {
            ExamPositionService.Read(vm.PositionId)
                .then(function (response) {
                    vm.ExamPositions = response.data;
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