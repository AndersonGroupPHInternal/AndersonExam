using AndersonExamContext;
using BaseData;
using System.Linq;

namespace AndersonExamData
{
    public class DExaminee : DBase, IDExaminee
    {
        public DExaminee() : base(new Context())
        {
        }
        #region CREATE
        #endregion

        #region READ
        public decimal Percentage(int examineeId)
        {
            using (var context = new Context())
            {
                var takenExamSummary = context.TakenExams
                    .Where(a => a.ExamineeId == examineeId)
                    .Select(a => new
                    {
                        Score = a.Answers.Count(b => b.Choice.Correct),
                        Total = a.Answers.Count()
                    })
                    .Where(a => a.Total > 0);

                if (takenExamSummary == null || takenExamSummary.Count() == 0)
                    return 0;
                var totalPercentage = takenExamSummary?.Average(a => ((a.Score * 100) / a.Total)) ?? 0;
                return (decimal)totalPercentage;
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
