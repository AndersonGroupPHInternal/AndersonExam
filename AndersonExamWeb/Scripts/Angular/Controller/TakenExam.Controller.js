(function () {
    'use strict';

    angular
        .module('App')
        .controller('TakenExamController', TakenExamController);

    TakenExamController.$inject = ['$window', 'TakenExamService'];

    function TakenExamController($window, TakenExamService) {
        var vm = this;

        vm.TakenExams;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(examId) {
            $window.location.href = '../ TakenExam/Update/' + examId;
        }

        function Initialise(examineeId) {
            Read(examineeId);
        }

        function Read(examineeId) {
            TakenExamService.Read(examineeId)
                .then(function (response) {
                    vm.TakenExams = response.data;
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

        function Delete(TakenExam) {
            TakenExamService.Delete(TakenExam)
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