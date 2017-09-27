using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("ExamSet")]
    public class EExamSet: EBase
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EExamSet> EExamSets { get; set; }
        public virtual ICollection<EExaminee> Examinees { get; set; }
        public int ExamSetId { get; set; }
    }
}
