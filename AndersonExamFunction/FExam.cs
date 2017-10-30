using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonExamFunction
{
    public class FExam : IFExam
    {
        private IDExam _iDExam;

        public FExam(IDExam iDExam)
        {
            _iDExam = iDExam;
        }

        #region CREATE
        public Exam Create(Exam exam)
        {
            EExam eExam = EExam(exam);
            eExam = _iDExam.Create(eExam);
            return (Exam(eExam));
        }
        #endregion

        #region READ
        public Exam Read(int examId)
        {
            EExam eExam = _iDExam.Read<EExam>(a => a.ExamId == examId);
            return Exam(eExam);
        }

        public Exam ReadExamForTakeExam(int examId)
        {
            EExam eExam = _iDExam.Read<EExam>(a => a.ExamId == examId);
            return Exam(eExam);
        }

        public List<Exam> Read()
        {
            List<EExam> eExams = _iDExam.List<EExam>(a => true);
            return Exams(eExams);
        }

        public List<Exam> ReadExamForExaminee(int examineeId)
        {
            List<EExam> eExams = _iDExam.List<EExam>(a => a.ExamPositions.Any(
                b => b.Position.Examinees.Any(c => c.ExamineeId == examineeId)));
            return Exams(eExams);
        }

        public List<Exam> ReadExamForPosition(int positionId)
        {
            List<EExam> eExams = _iDExam.List<EExam>(a => a.ExamPositions.Any(b => b.PositionId == positionId));
            return Exams(eExams);
        }
        #endregion

        #region UPDATE
        public Exam Update(Exam exam)
        {
            var eExam = _iDExam.Update(EExam(exam));
            return (Exam(eExam));
        }
        #endregion

        #region DELETE
        public void Delete(Exam Exam)
        {     
            _iDExam.Delete(EExam(Exam));
        }
        #endregion

        #region OTHER FUNCTION
        private EExam EExam(Exam Exam)
        {
            EExam returnEExam = new EExam
            {
                ExamId = Exam.ExamId,
                TimeLimit = Exam.TimeLimit,

                Name = Exam.Name,
                Description = Exam.Description,
                Instructions = Exam.Instructions,
                Copyright = Exam.Copyright
            };
            return returnEExam;
        }

        private Exam Exam(EExam eExam)
        {
            Exam returnExam = new Exam
            {
                ExamId = eExam.ExamId,
                TimeLimit = eExam.TimeLimit,

                Name = eExam.Name,
                Description = eExam.Description,
                Instructions = eExam.Instructions,
                Copyright = eExam.Copyright
            };
            return returnExam;
        }

        private List<Exam> Exams(List<EExam> eExams)
        {
            var returnExams = eExams.Select(a => new Exam
            {
                ExamId = a.ExamId,
                TimeLimit = a.TimeLimit,

                Name = a.Name,
                Description = a.Description,
                Instructions = a.Instructions,
                Copyright = a.Copyright
            });

            return returnExams.ToList();
        }


        #endregion
    }
}
