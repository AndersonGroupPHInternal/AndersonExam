using System.Collections.Generic;
using System.Linq;

namespace AndersonExamModel
{
    public class Examinee : Base.Base
    {
        public int ExamineeId { get; set; }
        public int PositionId { get; set; }

        public string ReferenceCode { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<TakenExam> TakenExams { get; set; }
    }
}
