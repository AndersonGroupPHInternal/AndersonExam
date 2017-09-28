using AndersonExamEntity;
using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("ExamPosition")]
    public class EExamPosition: EBase
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamPositionId { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }

        public virtual EExam Exam { get; set; }
        public virtual EPosition Position { get; set; }        
    }
}

