namespace AndersonExamModel
{
    public class Answer : Base.Base
    {
        public int AnswerId { get; set; }
        public int ChoiceId { get; set; }
        public int TakenExamId { get; set; }

        public virtual Choice Choice { get; set; }
        public virtual TakenExam TakenExam { get; set; }
    }
}
