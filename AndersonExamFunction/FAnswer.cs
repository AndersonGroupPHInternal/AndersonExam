using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FAnswer : IFAnswer
    {
        private IDAnswer _iDAnswer;

        public FAnswer(IDAnswer iDAnswer)
        {
            _iDAnswer = iDAnswer;
        }

        #region CREATE
        public void Create(List<Answer> answers)
        {
            List<EAnswer> eAnswers = EAnswers(answers);
            _iDAnswer.Create(eAnswers);
        }
        #endregion

        #region READ
        public List<Answer> Read(int examTakenId)
        {
            List<EAnswer> eAnswers = _iDAnswer.List<EAnswer>(a => a.TakenExamId == examTakenId);
            return Answers(eAnswers);
        }


        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        private List<Answer> Answers(List<EAnswer> eAnswers)
        {
            var returnAnswers = eAnswers.Select(a => new Answer
            {
                AnswerId = a.AnswerId,
                ChoiceId = a.ChoiceId,
                TakenExamId = a.TakenExamId,
                QuestionId = a.QuestionId
            });

            return returnAnswers.ToList();
        }

        private List<EAnswer> EAnswers(List<Answer> answers)
        {
            List<EAnswer> returnEAnswers = answers.Select(a => new EAnswer
            {
                AnswerId = a.AnswerId,
                ChoiceId = a.ChoiceId,
                TakenExamId = a.TakenExamId,
                QuestionId = a.QuestionId,
            }).ToList();
            return returnEAnswers;
        }
        #endregion
    }
}
