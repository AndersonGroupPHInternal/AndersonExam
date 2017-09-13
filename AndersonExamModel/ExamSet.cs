using System.Collections.Generic;

namespace AndersonExamModel
{
    public class ExamSet : Base.Base
    {
        public int ExamSetId { get; set; }
        public int PositionId { get; set; }

        public string Description { get; set; }
 
        
        public virtual ICollection<ExamSet> ExamSets { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TakenExam> TakenExams { get; set; }
    }    
}
