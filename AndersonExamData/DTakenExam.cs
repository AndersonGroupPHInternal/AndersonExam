using AndersonExamContext;
using AndersonExamEntity;
using BaseData;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace AndersonExamData
{
    public class DTakenExam : DBase, IDTakenExam
    {
        public DTakenExam() : base(new Context())
        {
        }
        #region CREATE
        #endregion

        #region READ
        public List<ETakenExam> Read(int examineeId)
        {
            using (var context = new Context())
            {
                return context.TakenExams
                    .Include(a => a.Exam)
                    .Include(a => a.Answers)
                    .Include(a => a.Answers.Select(b => b.Choice))
                    .Include(a => a.Answers.Select(b => b.Choice.Question))
                    .Where(a => a.ExamineeId == examineeId)
                    .ToList();
            }
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
