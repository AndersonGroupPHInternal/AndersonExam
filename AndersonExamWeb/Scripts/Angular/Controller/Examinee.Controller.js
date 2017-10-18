(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamineeController', ExamineeController);

    ExamineeController.$inject = ['$window', 'ExamineeService', 'PositionService'];

    function ExamineeController($window, ExamineeService, PositionService) {
        var vm = this;
        //variables
        //objects
        //arrays
        vm.Examinees;
        //public create
        //public read
        vm.Initialise = Initialise;
        vm.ReadForPosition = ReadForPosition;
        vm.Percentage = Percentage;
        vm.TakenExamsPage = TakenExamsPage;
        //public update
        //public delete
        vm.Delete = Delete;
        //public other
        vm.SingleSelect;
        function Initialise() {
            Read();
            ReadForPosition();
        }
        function ReadForPosition() {
            PositionService.Read()
                .then(function (response) {
                    vm.Positions = response.data;
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

        function Percentage(examinee) {
            ExamineeService.Percentage(examinee.ExamineeId)
                .then(function (response) {
                    examinee.Percentage = response.data;
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

        function TakenExamsPage(examineeId) {
            $window.location.href = '../Examinee/TakenExam/' + examineeId;
        }
        //private read
        function Read() {
            ExamineeService.Read()
                .then(function (response) {
                    vm.Examinees = response.data;
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

        function Delete(examineeId) {
            ExamineeService.Delete(examineeId)
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