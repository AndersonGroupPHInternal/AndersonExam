using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFExamSet
    {
        #region CREATE
        ExamSet Create(ExamSet examSet);
        #endregion

        #region READ
        ExamSet Read(int examSetId);
        List<ExamSet> Read();
        List<ExamSet> ReadExamSetForPosition(int positionId);
        #endregion

        #region UPDATE
        ExamSet Update(ExamSet ExamSet);
        #endregion

        #region DELETE
        void Delete(ExamSet ExamSet);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
