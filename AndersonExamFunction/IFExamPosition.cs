using AndersonExamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonExamFunction
{
    public interface IFExamPosition
    {
        #region CREATE
        ExamPosition Create(ExamPosition ExamPosition);
        #endregion

        #region READ
        List<ExamPosition> Read(int positionId);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void Delete(ExamPosition ExamPosition);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
