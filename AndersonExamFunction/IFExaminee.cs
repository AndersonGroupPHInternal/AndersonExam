using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFExaminee
    {
        #region CREATE
        Examinee Create(Examinee examinee);
        #endregion

        #region READ
        decimal Percentage(int examineeId);
        List<Examinee> Read();
        #endregion

        #region UPDATE
        Examinee Update(Examinee examinee);
        #endregion

        #region DELETE
        void Delete(int examineeId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
