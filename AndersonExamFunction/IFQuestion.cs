using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFQuestion
    {
        #region CREATE
        Question Create(Question question);
        #endregion

        #region READ
        List<Question> Read(int examId);
        #endregion

        #region UPDATE
        Question Update(Question question);
        #endregion

        #region DELETE
        void Delete(Question question);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
