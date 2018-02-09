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

        List<Examinee> Read(int examineeId, string sortBy);

        List<Examinee> Read(ExamineeFilter examineeFilter);
        #endregion

        #region UPDATE
        Examinee Update(Examinee examinee);
        #endregion

        #region DELETE
        void Delete(int examineeId);
        object Read(object examineeFilter);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
