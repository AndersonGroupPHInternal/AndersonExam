using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FTakenExam : IFTakenExam
    {
        private IDTakenExam _iDTakenExam;

        public FTakenExam(IDTakenExam iDTakenExam)
        {
            _iDTakenExam = iDTakenExam;
        }

        #region CREATE
        public TakenExam Create(TakenExam takenExam)
        {
            ETakenExam eTakenExam = ETakenExam(takenExam);
            eTakenExam = _iDTakenExam.Create(eTakenExam);
            return TakenExam(eTakenExam);
        }
        #endregion

        #region READ
        public List<TakenExam> Read(int examineeId)
        {
            List<ETakenExam> eTakenExams = _iDTakenExam.Read(examineeId);
            return TakenExams(eTakenExams);
        }
        public List<TakenExam> Read()
        {
            List<ETakenExam> eTakenExams = _iDTakenExam.List<ETakenExam>(a => true);
            return TakenExams(eTakenExams);
        }
        #endregion

        #region UPDATE
        public TakenExam Update(TakenExam takenExam)
        {
            var eTakenExam = _iDTakenExam.Update(ETakenExam(takenExam));
            return (TakenExam(eTakenExam));
        }
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        private List<TakenExam> TakenExams(List<ETakenExam> eTakenExams)
        {
            var returnTakenExams = eTakenExams.Select(a => new TakenExam
            {
                ExamId = a.ExamId,
                ExamineeId = a.ExamineeId,
                TakenExamId = a.TakenExamId,

                Exam = new Exam
                {
                    TimeLimit = a.Exam.TimeLimit,

                    Name = a.Exam.Name,
                    Description = a.Exam.Description,
                    Instructions = a.Exam.Instructions,
                    Copyright = a.Exam.Copyright,
                },

                Answers = a.Answers.Select(b =>
                new Answer
                {
                    AnswerId = b.AnswerId,
                    ChoiceId = b.ChoiceId,
                    QuestionId = b.QuestionId,
                    TakenExamId = b.TakenExamId,

                    Choice = new Choice
                    {
                        Correct = b.Choice.Correct,
                        ChoiceId = b.Choice.ChoiceId,
                        QuestionId = b.Choice.QuestionId,

                        Description = b.Choice.Description,
                        Question = new Question
                        {
                            Description = b.Choice.Question.Description,
                        }
                    }
                }).ToList()
            });

            return returnTakenExams.ToList();
        }

        private ETakenExam ETakenExam(TakenExam takenExam)
        {
            ETakenExam returnETakenExam = new ETakenExam
            {
                ExamId = takenExam.ExamId,
                ExamineeId = takenExam.ExamineeId,
                TakenExamId = takenExam.TakenExamId
            };
            return returnETakenExam;
        }

        private TakenExam TakenExam(ETakenExam eTakenExam)
        {
            TakenExam returnTakenExam = new TakenExam
            {
                ExamId = eTakenExam.ExamId,
                ExamineeId = eTakenExam.ExamineeId,
                TakenExamId = eTakenExam.TakenExamId,

                Exam = new Exam
                {
                    TimeLimit = eTakenExam.Exam.TimeLimit,

                    Name = eTakenExam.Exam.Name,
                    Description = eTakenExam.Exam.Description,
                    Instructions = eTakenExam.Exam.Instructions,
                    Copyright = eTakenExam.Exam.Copyright,
                },

                Answers = eTakenExam.Answers.Select(a =>
                new Answer
                {
                    AnswerId = a.AnswerId,
                    ChoiceId = a.ChoiceId,
                    QuestionId = a.QuestionId,
                    TakenExamId = a.TakenExamId,

                    Choice = new Choice
                    {
                        Correct = a.Choice.Correct,
                        ChoiceId = a.Choice.ChoiceId,
                        QuestionId = a.Choice.QuestionId,

                        Description = a.Choice.Description,
                        Question = new Question
                        {
                            Description = a.Choice.Question.Description,
                        }
                    }
                }).ToList()
            };
            return returnTakenExam;
        }
        #endregion
    }
}
