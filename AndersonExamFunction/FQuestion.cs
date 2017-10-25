using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FQuestion : IFQuestion
    {
        private IDQuestion _iDQuestion;

        public FQuestion(IDQuestion iDQuestion)
        {
            _iDQuestion = iDQuestion;
        }

        #region CREATE
        public Question Create(Question question)
        {
            EQuestion eQuestion = EQuestion(question);
            eQuestion = _iDQuestion.Create(eQuestion);
            return (Question(eQuestion));
        }
        #endregion

        #region READ
        public List<Question> Read(int examId)
        {
            List<EQuestion> eQuestions = _iDQuestion.List<EQuestion>(a => a.ExamId == examId);
            return Questions(eQuestions);
        }

        public List<Question> ReadQuestionForTakeExam(int examId)
        {
            List<EQuestion> eQuestions = _iDQuestion.List<EQuestion>(a => a.ExamId == examId);
            return Questions(eQuestions);
        }
        #endregion

        #region UPDATE
        public Question Update(Question question)
        {
            var eQuestion = _iDQuestion.Update(EQuestion(question));
            return (Question(eQuestion));
        }
        #endregion

        #region DELETE
        public void Delete(Question Question)
        {
            _iDQuestion.Delete<EChoiceImage>(a => a.Choice.QuestionId == Question.QuestionId);
            _iDQuestion.Delete<EChoice>(a => a.QuestionId == Question.QuestionId);
            _iDQuestion.Delete<EQuestionImage>(a => a.QuestionId == Question.QuestionId);
            _iDQuestion.Delete(EQuestion(Question));
        }
        #endregion

        #region OTHER FUNCTION
        private List<Question> Questions(List<EQuestion> eQuestions)
        {
            var returnQuestions = eQuestions.Select(a => new Question
            {
                ExamId = a.ExamId,
                QuestionId = a.QuestionId,

                Description = a.Description
            });

            return returnQuestions.ToList();
        }

        private EQuestion EQuestion(Question question)
        {
            EQuestion returnEQuestion = new EQuestion
            {
                ExamId = question.ExamId,
                QuestionId = question.QuestionId,

                Description = question.Description
            };
            return returnEQuestion;
        }

        private Question Question(EQuestion eQuestion)
        {
            Question returnQuestion = new Question
            {
                ExamId = eQuestion.ExamId,
                QuestionId = eQuestion.QuestionId,

                Description = eQuestion.Description
            };
            return returnQuestion;
        }
        #endregion
    }
}
