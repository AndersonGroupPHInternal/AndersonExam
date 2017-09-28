(function () {
    'use strict';

    angular
        .module('App')
        .controller('QuestionController', QuestionController);

    QuestionController.$inject = ['ChoiceService', 'QuestionService', 'ImageQuestionService', 'ImageChoiceService'];

    function QuestionController(ChoiceService, QuestionService, ImageQuestionService, ImageChoiceService) {
        var vm = this;
        //variables
        vm.ExamId;
        //objects
        vm.NewQuestionImages = {
            QuestionId: 0,
            Url: ''
        }
        vm.NewChoice = {
            Correct: false,
            QuestionId: 0,
            Description: ''
        }

        vm.Question = {
            ExamId: 0,
            Description: '',
            Choices: [],
            QuestionImages: []
        }
        //arrays
        vm.Questions;
        //public create
        vm.Create = Create;
        vm.CreateChoice = CreateChoice;
        vm.CreateChoiceImage = CreateChoiceImage;
        vm.CreateQuestionImage = CreateQuestionImage;
        //public read
        vm.Initialise = Initialise;
        vm.ReadChoices = ReadChoices;
        vm.ShowChoices = ShowChoices;
        vm.ReadQuestionImage = ReadQuestionImage;
        vm.ShowQuestionImage = ShowQuestionImage;
        vm.ReadChoiceImage = ReadChoiceImage;
        vm.ShowChoiceImage = ShowChoiceImage;
        //public update
        vm.Cancel = Cancel;
        vm.CancelChoice = CancelChoice;
        vm.Update = Update;
        vm.UpdateChoice = UpdateChoice;
        vm.UpdateRow = UpdateRow;
        vm.UpdateChoiceRow = UpdateChoiceRow;
        //public delete
        vm.Delete = Delete;
        //public other
        vm.Attachment;
        vm.UploadChoiceImageAttachment = UploadChoiceImageAttachment;
        //public create
        function Create() {
            QuestionService.Create(vm.Question)
                .then(function (response) {
                    new PNotify({
                        title: 'Question',
                        text: 'Question Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    vm.Question = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        QuestionImages: []
                    };
                    Read();
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        function CreateQuestionImage(question) {
            question.NewQuestionImages.QuestionId = question.QuestionId
            ImageQuestionService.CreateImage(question.NewQuestionImages)
                .then(function (response) {
                    new PNotify({
                        title: 'QuestionImage',
                        text: 'QuestionImage Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    vm.Question = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        QuestionImages: []
                    };
                    ReadQuestionImage(question);
                })
            .catch(function (result) {
                console.log(result);
                new PNotify({
                    title: 'QuestionController.CreateQuestionImage',
                    text: result.status + ' ' + result.statusText,
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });
            });
        }

        function UploadChoiceImageAttachment() {
            ImageChoiceService.CreateImage(vm.Attachment)
                .then(function (response) {
                    new PNotify({
                        title: 'QuestionImage',
                        text: 'QuestionImage Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                })
            .catch(function (result) {
                console.log(result);
                new PNotify({
                    title: 'QuestionImageController.CreateQuestionImage',
                    text: result.status + ' ' + result.statusText,
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });
            });
        }

        function CreateChoice(question) {
            vm.NewChoice.QuestionId = question.QuestionId
            ChoiceService.Create(vm.NewChoice)
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    vm.Question = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        QuestionImages: []
                    };
                    ReadChoices(question);
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.CreateChoice',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function CreateChoiceImage(choice) {
            choice.NewChoiceImages.ChoiceId = choice.ChoiceId
            ImageChoiceService.CreateImage(choice.NewChoiceImages)
                .then(function (response) {
                    new PNotify({
                        title: 'ChoiceImage',
                        text: 'ChoiceImage Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    vm.Question = {
                        ExamId: vm.ExamId,
                        Description: '',
                        Choices: [],
                        QuestionImages: []
                    };
                    ReadChoiceImage(choice);
                })
            .catch(function (result) {
                console.log(result);
                new PNotify({
                    title: 'QuestionController.CreateChoiceImage',
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

            vm.Question = {
                ExamId: vm.ExamId,
                Description: '',
                Choices: [],
                QuestionImages: []
            };
        }

        function ReadChoices(question) {
            ChoiceService.Read(question.QuestionId)
                .then(function (response) {
                    question.Choices = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ShowChoices(question) {
            if (question.ShowChoices == undefined) {
                question.ShowChoices = true;
            }
            else {
                question.ShowChoices = !question.ShowChoices;
            }
        }

        function ReadChoiceImage(choice) {
            ImageChoiceService.Read(choice.ChoiceId)
                .then(function (response) {
                    choice.Choice = response.data;
                })
            .catch(function (result) {
                console.log(result);
                new PNotify({
                    title: 'ChoiceImageController.Read',
                    text: result.status + ' ' + result.statusText,
                    type: 'error',
                    hide: true,
                    addclass: "stack-bottomright"
                });
            });
        }

        function ShowChoiceImage(choice) {
            if (choice.ShowChoiceImage == undefined) {
                choice.ShowChoiceImage = true;
            }
            else {
                choice.ShowChoiceImage = !choice.ShowChoiceImage;
            }
        }

        function ReadQuestionImage(question) {
            ImageQuestionService.Read(question.QuestionId)
                .then(function (response) {
                    question.QuestionImages = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionImageController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ShowQuestionImage(question) {
            if (question.ShowQuestionImage == undefined) {
                question.ShowQuestionImage = true;
            }
            else {
                question.ShowQuestionImage = !question.ShowQuestionImage;
            }
        }

        //private read
        function Read() {
            QuestionService.Read(vm.ExamId)
                .then(function (response) {
                    vm.Questions = response.data;
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        //public update
        function Cancel(question) {
            question.UpdateMode = false;
        }

        function CancelChoice(choice) {
            choice.UpdateMode = false;
        }

        function Update(question) {
            QuestionService.Update(questionMinified(question))
                .then(function (response) {
                    new PNotify({
                        title: 'Question',
                        text: 'Question Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    Read();
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Read',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateChoice(question, choice) {
            ChoiceService.Update(choiceMinified(choice))
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Saved',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    ReadChoices(question);
                })
                .catch(function (result) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Read',
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

        function UpdateRow(question) {
            question.NewDescription = angular.copy(question.Description);
            question.UpdateMode = true;
        }
        //public delete
        function Delete(question) {
            QuestionService.Delete(questionMinified(question))
                .then(function (response) {
                    new PNotify({
                        title: 'Question',
                        text: 'Question Deleted',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    Read();
                })
                .catch(function (data, status) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.Delete',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function DeleteQuestionImage(questionImage, question) {
            ImageQuestionService.Delete(questionimageMinified(questionImage))
                .then(function (response) {
                    new PNotify({
                        title: 'Question Image',
                        text: 'Question Image Deleted',
                        type: 'Success',
                        addclass: "stach-bottomright"
                    });
                    ReadImageQuestion(question);
                })
                .catch(function (data, status) {
                    console.log(result);
                    new PNotify({
                        title: 'ImageQuestionService.Delete',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function DeleteChoice(choice, question) {
            ChoiceService.Delete(choiceMinified(choice))
                .then(function (response) {
                    new PNotify({
                        title: 'Choice',
                        text: 'Choice Deleted',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    ReadChoices(question);
                })
                .catch(function (data, status) {
                    console.log(result);
                    new PNotify({
                        title: 'QuestionController.DeleteChoice',
                        text: result.status + ' ' + result.statusText,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
        //Other private function
        function questionMinified(question) {
            //This will make sure we send only what we need
            return {
                ExamId: question.ExamId,
                QuestionId: question.QuestionId,
                Description: question.NewDescription
            }
        }

        function choiceMinified(choice) {
            return {
                Correct: choice.NewCorrect,
                ChoiceId: choice.ChoiceId,
                QuestionId: choice.QuestionId,
                Description: choice.NewDescription
            }
        }

        function questionimageMinified(questionImage) {
            return {
                QuestionImageId: questionImage.QuestionImageId,
                QuestionId: questionImage.QuestionId,
                Url: questionImage.Url
            }
        }
    }
})();