using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFChoice
    {
        #region CREATE
        Choice Create(Choice Choice);
        #endregion

        #region READ
        List<Choice> Read(int questionId);
        #endregion

        #region UPDATE
        Choice Update(Choice Choice);
        #endregion

        #region DELETE
        void Delete(Choice Choice);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
