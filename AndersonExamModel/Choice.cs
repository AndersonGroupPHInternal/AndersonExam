using System.Collections.Generic;

namespace AndersonExamModel
{
    public class Choice : Base.Base
    {
        public bool Correct { get; set; }
        
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<ChoiceImage> ChoiceImages { get; set; }
    }
}
