using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Question")]
    public class EQuestion: EBase
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public virtual EExam Exam { get; set; }

        public virtual ICollection<EAnswer> Answer { get; set; }
        public virtual ICollection<EChoice> Choices { get; set; }
        public virtual ICollection<EQuestionImage> QuestionImages { get; set; }
    }
}
