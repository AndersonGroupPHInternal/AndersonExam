using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("TakenExam")]
    public class ETakenExam : EBase
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Examinee")]
        public int ExamineeId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TakenExamId { get; set; }

        public virtual EExam Exam { get; set; }
        public virtual EExaminee Examinee { get; set; }

        public virtual ICollection<EAnswer> Answers { get; set; }
    }
}

