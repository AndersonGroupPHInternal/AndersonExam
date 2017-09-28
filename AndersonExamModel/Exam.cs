using System.Collections.Generic;

namespace AndersonExamModel
{
    public class Exam : Base.Base
    {
        public int ExamId { get; set; }
        public int TimeLimit { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Copyright { get; set; }
        
        public virtual ICollection<ExamPosition> ExamPositions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TakenExam> TakenExams { get; set; }
    }    
}
