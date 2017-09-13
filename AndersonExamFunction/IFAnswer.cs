using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFAnswer
    {
        #region CREATE
        void Create(List<Answer> answers);
        #endregion

        #region READ
        List<Answer> Read(int examTakenId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
