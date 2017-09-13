(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamineeController', ExamineeController);

    ExamineeController.$inject = ['$window', 'ExamineeService'];

    function ExamineeController($window, ExamineeService) {
        var vm = this;
        //variables
        //objects
        //arrays
        vm.Examinees;
        //public create
        //public read
        vm.Initialise = Initialise;
        vm.Percentage = Percentage;
        vm.TakenExamsPage = TakenExamsPage;
        //public update
        //public delete
        //public create
        //public read
        function Initialise() {
            Read();
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

    }
})();