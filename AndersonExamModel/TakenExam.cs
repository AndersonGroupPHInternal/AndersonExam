using System.Collections.Generic;
using System.Linq;

namespace AndersonExamModel
{
    public class TakenExam : Base.Base
    {
        public decimal Percentage
        {
            get
            {
                if (Score == 0 || Total == 0)
                {
                    return 0;
                }
                else
                {
                    return ((Score * 100) / Total);
                }
            }
        }

        public int ExamId { get; set; }
        public int ExamineeId { get; set; }
        public int Score
        {
            get
            {
                if (Answers?.Any() ?? false)
                {
                    return Answers.Count(a => a.Choice.Correct);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int TakenExamId { get; set; }
        public int Total
        {
            get
            {
                if (Answers?.Any() ?? false)
                {
                    return Answers.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        public virtual Exam Exam { get; set; }
        public virtual Examinee Examinee { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}

