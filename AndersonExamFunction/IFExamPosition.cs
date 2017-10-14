using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFExamPosition
    {
        #region CREATE
        ExamPosition Create(ExamPosition ExamPosition);
        void Create(int positionId, List<ExamPosition> examPositions);
        #endregion

        #region READ
        List<ExamPosition> Read(int positionId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void Delete(int positionId);
        void Delete(ExamPosition ExamPosition);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
