(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamSetController', ExamSetController);

    ExamSetController.$inject = ['$window', 'ExamSetService'];

    function ExamSetController($window, ExamSetService) {
        var vm = this;

        vm.ExamSets;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(examSetId) {
            $window.location.href = '../ExamSet/Update/' + examSetId;
        } 

        function Initialise() {
            Read();
        }

        function Read() {
            ExamSetService.Read()
                .then(function (response) {
                    vm.ExamSets = response.data;
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

        function Delete(examSet) {
            ExamSetService.Delete(examSet)
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