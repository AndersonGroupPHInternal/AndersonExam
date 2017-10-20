(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamineeController', ExamineeController);

    ExamineeController.$inject = ['$window', 'ExamineeService', 'PositionService', 'ExamService'];

    function ExamineeController($window, ExamineeService, PositionService, ExamService) {
        var vm = this;
        //variables
        vm.ExamineeId;
        //objects
        //arrays
        vm.Exams;
        vm.Examinees;
        vm.Positions;
        //public create
        //public read
        vm.Initialise = Initialise;
        vm.InitialiseForTakeExam = InitialiseForTakeExam;
        vm.ReadExamForExaminee = ReadExamForExaminee;
        vm.ReadForPosition = ReadForPosition;
        vm.Percentage = Percentage;
        vm.TakenExamsPage = TakenExamsPage;
        //public update
        //public delete
        vm.Delete = Delete;
        //public other
        vm.GoToTakeExam = GoToTakeExam;
        vm.SingleSelect;
        function Initialise() {
            Read();
            ReadForPosition();
        }

        function GoToTakeExam(examId) {
            $window.location.href = '../Examinee/TakeExam' + examId;
        }

        function InitialiseForTakeExam(examineeId) {
            vm.ExamineeId = examineeId;
            ReadExamForExaminee();
            Read();
        }

        function ReadExamForExaminee() {
            ExamService.ReadExamForExaminee(vm.ExamineeId)
                .then(function (response) {
                    vm.Exams = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                })
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