using System.Collections.Generic;

namespace AndersonExamModel
{
    public class Question : Base.Base
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<QuestionImage> QuestionImages { get; set; }
    }
}
