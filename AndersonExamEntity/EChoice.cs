using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Choice")]
    public class EChoice: EBase
    {
        public bool Correct { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChoiceId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public string Description { get; set; }

        public virtual EQuestion Question { get; set; }
        public virtual ICollection<EAnswer> Answers { get; set; }
        public virtual ICollection<EChoiceImage> ChoiceImages { get; set; }
    }
}
