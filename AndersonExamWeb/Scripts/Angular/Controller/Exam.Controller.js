(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamController', ExamController);

    ExamController.$inject = ['$window', 'ExamService'];

    function ExamController($window, ExamService) {
        var vm = this;

        vm.Exams;
        vm.SearchExam;
        vm.ExamFilter;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;

        vm.REfilter = REfilter;
       
        function REfilter() {
            console.log("gone");
           ExamService.FilteredRead(vm.ExamFilter)
             .then(function (response) {
              vm.Exams = response.data;
              })
             .catch(function (data, status) {
                 title: status,
                 text: data,
             new PNotify({
               type: 'error',
               hide: true,
               addclass: "stack-bottomright"
             });
                
             });
             } 
    

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