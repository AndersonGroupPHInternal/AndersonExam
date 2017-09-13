namespace AndersonExamModel
{
    public class ExamPosition: Base.Base
    {
        public int ExamId { get; set; }
        public int ExamPositionId { get; set; }
        public int PositionId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Position Position { get; set; }        
    }
}

