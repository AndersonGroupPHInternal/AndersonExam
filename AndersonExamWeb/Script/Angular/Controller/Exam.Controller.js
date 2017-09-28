(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamController', ExamController);

    ExamController.$inject = ['ExamService'];

    function ExamController(ExamService) {
        var vm = this;
        vm.Exams;

        vm.Initialise = Initialise;

        function Initialise(invoice) {
            Read();
        }

        function Read() {
            ExamService.Read()
                .then(function (response) {
                    vm.Exams = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: 'Error',
                        text: 'There was an error on loading the list',
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

    }
})();