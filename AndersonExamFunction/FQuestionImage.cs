using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AndersonExamFunction
{
    public class FQuestionImage : IFQuestionImage
    {
        private IDQuestionImage _iDQuestionImage;

        public FQuestionImage(IDQuestionImage iDQuestionImage)
        {
            _iDQuestionImage = iDQuestionImage;
        }

        #region CREATE
        public QuestionImage Create(QuestionImage questionImage)
        {
            
            EQuestionImage eQuestionImage = EQuestion(questionImage);
            eQuestionImage = _iDQuestionImage.Create(eQuestionImage);
            return Question(eQuestionImage);
        }
        #endregion

        #region READ
        public List<QuestionImage> Read(int questionId)
        {
            List<EQuestionImage> eQuestions = _iDQuestionImage.List<EQuestionImage>(a => a.QuestionId == questionId);
            return Questions(eQuestions);
        }

        public List<QuestionImage> ReadForTakeExam(int questionId)
        {
            List<EQuestionImage> eQuestions = _iDQuestionImage.List<EQuestionImage>(a => a.QuestionId == questionId);
            return Questions(eQuestions);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public void Delete(QuestionImage QuestionImage)
        {
            _iDQuestionImage.Delete(EQuestion(QuestionImage));
        }
        #endregion

        #region OTHER FUNCTION
        private List<QuestionImage> Questions(List<EQuestionImage> eQuestions)
        {
            var returnQuestions = eQuestions.Select(a => new QuestionImage
            {
                QuestionId = a.QuestionId,
                QuestionImageId = a.QuestionImageId,

                Url = a.Url
            });

            return returnQuestions.ToList();
        }

        private EQuestionImage EQuestion(QuestionImage question)
        {
            EQuestionImage returnEQuestionImage = new EQuestionImage
            {
                QuestionId = question.QuestionId,
                QuestionImageId = question.QuestionImageId,

                Url = question.Url
            };
            return returnEQuestionImage;
        }

        private QuestionImage Question(EQuestionImage eQuestion)
        {
            QuestionImage returnQuestionImage = new QuestionImage
            {
                QuestionId = eQuestion.QuestionId,
                QuestionImageId = eQuestion.QuestionImageId,

                Url = eQuestion.Url
            };
            return returnQuestionImage;
        }
        #endregion
    }
}
