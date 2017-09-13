namespace AndersonExamModel
{
    public class ChoiceImage : Base.Base
    {
        public int ChoiceId { get; set; }
        public int ChoiceImageId { get; set; }

        public string Url { get; set; }

        public virtual Choice Choice { get; set; }
    }
}
