using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("ChoiceImage")]
    public class EChoiceImage: EBase
    {
        [ForeignKey("Choice")]
        public int ChoiceId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChoiceImageId { get; set; }


        public string Url { get; set; }

        public virtual EChoice Choice { get; set; }
    }
}
