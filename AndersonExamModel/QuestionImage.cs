namespace AndersonExamModel
{
    public class QuestionImage : Base.Base
    {
        public int QuestionId { get; set; }
        public int QuestionImageId { get; set; }

        public string Url { get; set; }

        public virtual Question Question { get; set; }
    }
}
