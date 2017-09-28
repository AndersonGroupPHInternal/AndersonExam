using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonExamFunction
{
    public class FExamSet : IFExamSet
    {
        private IDExamSet _iDExamSet;

        public FExamSet(IDExamSet iDExamSet)
        {
            _iDExamSet = iDExamSet;
        }

        #region CREATE
        public ExamSet Create(ExamSet examSet)
        {
            EExamSet eExamSet = EExamSet(examSet);
            eExamSet = _iDExamSet.Create(eExamSet);
            return (ExamSet(eExamSet));
        }
        #endregion

        #region READ
        public ExamSet Read(int examSetId)
        {
            EExamSet eExamSet = _iDExamSet.Read<EExamSet>(a => a.ExamSetId == examSetId);
            return ExamSet(eExamSet);
        }     

        //public List<ExamSet> ReadExamSetForPosition(int positionId)
        //{
        //    List<EExamSet> eExamSets = _iDExamSet.List<EExamSet>(a => a.ExamPositions.Any(b => b.PositionId == positionId));
        //    return ExamSets(eExamSets);
        //}

        #endregion

        #region UPDATE
        public ExamSet Update(ExamSet examSet)
        {
            var eExamSet = _iDExamSet.Update(EExamSet(examSet));
            return (ExamSet(eExamSet));
        }
        #endregion

        #region DELETE
        public void Delete(ExamSet ExamSet)
        {
            _iDExamSet.Delete(EExamSet(ExamSet));
        }
        #endregion

        #region OTHER FUNCTION
        private EExamSet EExamSet(ExamSet ExamSet)
        {
            EExamSet returnEExamSet = new EExamSet
            {
                ExamSetId = ExamSet.ExamSetId,
                PositionId = ExamSet.PositionId,

                Description = ExamSet.Description,

            };
            return returnEExamSet;
        }

        private ExamSet ExamSet(EExamSet eExamSet)
        {
            ExamSet returnExamSet = new ExamSet
            {
                ExamSetId = eExamSet.ExamSetId,
                PositionId = eExamSet.PositionId,

                Description = eExamSet.Description,
              
            };
            return returnExamSet;
        }

        private List<ExamSet> Exams(List<EExamSet> eExams)
        {
            var returnExamSet = eExams.Select(a => new ExamSet
            {
                ExamSetId = a.PositionId,
                PositionId = a.PositionId,
  
                Description = a.Description,              
            });

            return returnExamSet.ToList();
        }

        public List<ExamSet> Read()
        {
            throw new NotImplementedException();
        }

        public List<ExamSet> ReadExamSetForPosition(int positionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
