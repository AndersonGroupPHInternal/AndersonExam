using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("QuestionImage")]
    public class EQuestionImage: EBase
    {
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionImageId { get; set; }
        
        public string Url { get; set; }

        public virtual EQuestion Question { get; set; }
    }
}
