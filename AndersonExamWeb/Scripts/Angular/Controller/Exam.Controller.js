(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamController', ExamController);

    ExamController.$inject = ['$window', 'ExamService'];

    function ExamController($window, ExamService) {
        var vm = this;

        vm.Exams;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(examId) {
            $window.location.href = '../Exam/Update/' + examId;
        } 

        function Initialise() {
            Read();
        }

        function Read() {
            ExamService.Read()
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

                });
        }

        function Delete(exam) {
            ExamService.Delete(exam)
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