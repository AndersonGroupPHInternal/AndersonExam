using AndersonExamEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonExamData
{
    public interface IDTakenExam : IDBase
    {
        #region CREATE
        #endregion

        #region READ
        List<ETakenExam> Read(int examineeId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
