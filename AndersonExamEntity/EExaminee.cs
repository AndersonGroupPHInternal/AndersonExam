using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Examinee")]
    public class EExaminee: EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamineeId { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }

        public string ReferenceCode { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public virtual EPosition Position { get; set; }

        public virtual ICollection<ETakenExam> TakenExams { get; set; }
    }
}
