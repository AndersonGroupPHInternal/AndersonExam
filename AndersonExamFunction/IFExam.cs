using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFExam
    {
        #region CREATE
        Exam Create(Exam exam);
        #endregion

        #region READ
        Exam Read(int examId);
        List<Exam> Read();
        List<Exam> ReadExamForPosition(int positionId);
        #endregion

        #region UPDATE
        Exam Update(Exam Exam);
        #endregion

        #region DELETE
        void Delete(Exam Exam);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
