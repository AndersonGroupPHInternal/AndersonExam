using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFQuestionImage
    {
        #region CREATE
        QuestionImage Create(QuestionImage QuestionImage);
        #endregion

        #region READ
        List<QuestionImage> Read(int questionId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void Delete(QuestionImage QuestionImage);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
