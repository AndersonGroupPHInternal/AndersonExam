using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Answer")]
    public class EAnswer: EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [ForeignKey("Choice")]
        public int ChoiceId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("TakenExam")]
        public int TakenExamId { get; set; }

        public virtual EChoice Choice { get; set; }
        public virtual EQuestion Question { get; set; }
        public virtual ETakenExam TakenExam { get; set; }
    }
}
