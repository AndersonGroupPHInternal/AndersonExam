using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Position")]
    public class EPosition: EBase
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }

        public string Description { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<EExamPosition> EExamPositions { get; set; }
        public virtual ICollection<EExaminee> Examinees { get; set; }
    }
}
