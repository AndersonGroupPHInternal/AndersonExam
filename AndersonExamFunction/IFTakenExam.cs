using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFTakenExam
    {
        #region CREATE
        TakenExam Create(TakenExam takenExam);
        #endregion

        #region READ
        List<TakenExam> Read(int examineeId);
        List<TakenExam> Read();
        #endregion

        #region UPDATE
        TakenExam Update(TakenExam takenExam);
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
