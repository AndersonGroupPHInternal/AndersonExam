(function () {
    'use strict';

    angular
        .module('App')
        .controller('ExamExamSetController', ExamExamSetController);

    ExamExamSetController.$inject = ['ChoiceService', 'ExamExamSetService'];

    function ExamExamSetController(ChoiceService, ExamExamSetService) {
        var vm = this;
        //variables
        vm.ExamId;
        //objects
        vm.ExamExamSet = {
            ExamId: 0,
            Description: '',
            Choices: [],
            ExamExamSetImages: []
        }
        //arrays
        vm.ExamExamSets;
        //public create
        vm.Create = Create;
        vm.CreateChoice = CreateChoice;
        //public read
        vm.Initialise = Initialise;
        vm.ReadChoices = ReadChoices;
        vm.ShowChoices = ShowChoices;
        //public update
        vm.Cancel = Cancel;
        vm.CancelChoice = CancelChoice;
        vm.Update = Update;
        vm.UpdateChoice = UpdateChoice;
        vm.UpdateRow = UpdateRow;
        vm.UpdateChoiceRow = UpdateChoiceRow;
        //public delete
        vm.Delete = Delete;
        //public create
        function Create() {
            ExamExamSetService.Create(vm.ExamExamSet)
                .then(function (response) {
                    new PNotify({
                        title: 'ExamExamSet',
                        text: 'ExamExamSet Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                    vm.ExamExamSet = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        ExamExamSetImages: []
                    };

                    Read();
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function CreateChoice(examExamSet) {
            examExamSet.NewChoice.ExamExamSetId = examExamSet.ExamExamSetId
            ChoiceService.Create(examExamSet.NewChoice)
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                    vm.ExamExamSet = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        ExamExamSetImages: []
                    };

                    ReadChoices(examExamSet);
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.CreateChoice',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        //public read
        function Initialise(examId) {
            vm.ExamId = examId;

            Read();

            vm.ExamExamSet = {
                ExamId: vm.ExamId,
                Description: '',
                Choices: [],
                ExamExamSetImages: []
            };
        }

        function ReadChoices(examExamSet) {
            ChoiceService.Read(examExamSet.ExamExamSetId)
                .then(function (response) {
                    examExamSet.Choices = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ShowChoices(examExamSet) {
            if (examExamSet.ShowChoices === undefined) {
                examExamSet.ShowChoices = true;
            }
            else {
                examExamSet.ShowChoices = !examExamSet.ShowChoices;
            }
        }
        //private read
        function Read() {
            ExamExamSetService.Read(vm.ExamId)
                .then(function (response) {
                    vm.ExamExamSets = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        //public update
        function Cancel(examExamSet) {
            examExamSet.UpdateMode = false;
        }

        function CancelChoice(choice) {
            choice.UpdateMode = false;
        }

        function Update(examExamSet) {
            ExamExamSetService.Update(examExamSetMinified(examExamSet))
                .then(function (response) {
                    new PNotify({
                        title: 'ExamExamSet',
                        text: 'ExamExamSet Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    Read();
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateChoice(examExamSet, choice) {
            ChoiceService.Update(choiceMinified(choice))
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    ReadChoices(examExamSet);
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateChoiceRow(choice) {
            choice.NewCorrect = angular.copy(choice.Correct);
            choice.NewDescription = angular.copy(choice.Description);
            choice.UpdateMode = true;
        }

        function UpdateRow(examExamSet) {
            examExamSet.NewDescription = angular.copy(examExamSet.Description);
            examExamSet.UpdateMode = true;
        }
        //public delete
        function Delete(examExamSet) {
            ExamExamSetService.Delete(examExamSetMinified(examExamSet))
                .then(function (response) {
                    new PNotify({
                        title: 'ExamExamSet',
                        text: 'ExamExamSet Deleted',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    Read();
                })
                .catch(function (data, status) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.Delete',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function DeleteChoice(choice, examExamSet) {
            ChoiceService.Delete(choiceMinified(choice))
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Deleted',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    ReadChoices(examExamSet);
                })
                .catch(function (data, status) {
                    console.log(result);
                    new PNotify({
                        title: 'ExamExamSetController.DeleteChoice',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
        //Other private function
        function examExamSetMinified(examExamSet) {
            //This will make sure we send only what we need
            return {
                ExamId: examExamSet.ExamId,
                ExamExamSetId: examExamSet.ExamExamSetId,
                Description: examExamSet.NewDescription
            }
        }

        function choiceMinified(choice) {
            return {
                Correct: choice.NewCorrect,
                ChoiceId: choice.ChoiceId,
                ExamExamSetId: choice.ExamExamSetId,
                Description: choice.NewDescription
            }
        }

    }
})();