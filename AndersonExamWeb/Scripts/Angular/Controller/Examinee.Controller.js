(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamineeController', ExamineeController);

    ExamineeController.$inject = ['$window', 'ExamineeService', 'PositionService', 'ExamService', 'QuestionService', 'ChoiceService', 'ImageQuestionService', 'ImageChoiceService'];

    function ExamineeController($window, ExamineeService, PositionService, ExamService, QuestionService, ChoiceService, ImageQuestionService, ImageChoiceService) {
        var vm = this;
        //variables
        vm.ExamineeId;
        vm.ExamId;
        //objects
        //arrays
        vm.Exams;
        vm.Examinees;
        vm.Positions;
        vm.Questions;
        vm.ExamineeFilter;
        vm.SearchExaminee;
        //public create
        //public read
        vm.Initialise = Initialise;
        vm.InitialiseForTakeExam = InitialiseForTakeExam;
        vm.InitialiseForSelectExam = InitialiseForSelectExam;
        vm.ReadExamForExaminee = ReadExamForExaminee;
        vm.ReadForChoice = ReadForChoice;
        vm.ReadForChoiceImage = ReadForChoiceImage;
        vm.ReadForPosition = ReadForPosition;
        vm.ReadForQuestion = ReadForQuestion;
        vm.ReadForQuestionImage = ReadForQuestionImage;
        vm.ReadExamForTakeExam = ReadExamForTakeExam;
        vm.Percentage = Percentage;
        vm.TakenExamsPage = TakenExamsPage;
        //public update
        //public delete
        vm.Delete = Delete;
        //public other
        vm.GoToTakeExam = GoToTakeExam;
        vm.SingleSelect;

        vm.Rfilter = Rfilter;
        
        function Rfilter() {
            console.log("gasd");
                  ExamineeService.FilteredRead(vm.ExamineeFilter)
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
        

        function Initialise() {
            Read();
            ReadForPosition();
        }

        function GoToTakeExam(ExamId) {
            $window.location.href = '../Examinee/TakeExam/' + ExamId;
        }

        function InitialiseForSelectExam() {
            Read();
        }
        
        function InitialiseForTakeExam(ExamId) {
            vm.ExamId = ExamId;
            Read();
            ReadExamForTakeExam();
            ReadForQuestion();
        }

        //READ
        function ReadExamForTakeExam() {
            ExamService.ReadExamForTakeExam(vm.ExamId)
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

        function ReadExamForExaminee() {
            ExamService.ReadExamForExaminee()
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

        function ReadForChoice(question) {
            ChoiceService.ReadForTakeExam(question.QuestionId)
                .then(function (response) {
                    question.Choices = response.data;
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

        function ReadForChoiceImage(choice) {
            ImageChoiceService.ReadForTakeExam(choice.ChoiceId)
                .then(function (response) {
                    choice.ChoiceImages = response.data;
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

        function ReadForQuestion() {
            QuestionService.ReadQuestionForTakeExam(vm.ExamId)
                .then(function (response){
                    vm.Questions = response.data;
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

        function ReadForQuestionImage(question) {
            ImageQuestionService.ReadForTakeExam(question.QuestionId)
                .then(function (response) {
                    question.QuestionImages = response.data;
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

        //end Read
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