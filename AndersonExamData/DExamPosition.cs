using AndersonExamContext;
using AndersonExamEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersonExamData
{
    public class DExamPosition : DBase, IDExamPosition
    {
        public DExamPosition() : base(new Context())
        {
        }

        public List<EExamPosition> Read(int positionId)
        {
            using (var context = new Context())
            {
                return context.ExamPositions
                    .Include(a => a.Exam)
                    .Where(a => a.PositionId == positionId)
                    .ToList();
            }
        }
    }
}
