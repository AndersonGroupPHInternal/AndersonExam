using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonExamFunction
{
    public class FExamPosition : IFExamPosition
    {
        private IDExamPosition _iDExamPosition;

        public FExamPosition(IDExamPosition iDExamPosition)
        {
            _iDExamPosition = iDExamPosition;
        }

        #region Create
        public ExamPosition Create(ExamPosition position)
        {
            EExamPosition eExamPosition = EExamPosition(position);
            eExamPosition = _iDExamPosition.Create(eExamPosition);
            return (ExamPosition(eExamPosition));
        }
        #endregion

        #region Read
        public List<ExamPosition> Read(int positionId)
        {
            List<EExamPosition> eExamPosition = _iDExamPosition.Read(positionId);
            return ExamPositions(eExamPosition);
        }
        #endregion

        #region Delete
        public void Delete(ExamPosition examPosition)
        {
            _iDExamPosition.Delete(EExamPosition(examPosition));
        }
        #endregion

        #region OTHER FUNCTION
        private EExamPosition EExamPosition(ExamPosition examPosition)
        {
            EExamPosition returnEExamPosition = new EExamPosition
            {
                ExamPositionId = examPosition.ExamPositionId
            };
            return returnEExamPosition;
        }

        private ExamPosition ExamPosition(EExamPosition eExamposition)
        {
            ExamPosition returnExamPosition = new ExamPosition
            {
                ExamPositionId = eExamposition.ExamPositionId
            };
            return returnExamPosition;
        }

        private List<ExamPosition> ExamPositions(List<EExamPosition> eExamposition)
        {
            var returnExamPosition = eExamposition.Select(a => new ExamPosition
            {
                ExamId = a.ExamId,
                ExamPositionId = a.ExamPositionId,
                PositionId = a.PositionId,

                Exam = new Exam
                {
                    Name = a.Exam.Name,
                    Description = a.Exam.Description,
                    ExamId = a.Exam.ExamId,
                    TimeLimit = a.Exam.TimeLimit,
                }
            });
            return returnExamPosition.ToList();
        }
        #endregion

    }
}
