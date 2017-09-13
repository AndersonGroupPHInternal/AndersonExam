using System.Collections.Generic;

namespace AndersonExamModel
{
    public class Position : Base.Base
    {
        public int PositionId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExamPosition> EExamPositions { get; set; }
        public virtual ICollection<Examinee> Examinees { get; set; }
    }
}
