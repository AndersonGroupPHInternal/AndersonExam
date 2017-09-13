using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonExamEntity
{
    [Table("Exam")]
    public class EExam: EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public int TimeLimit { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Copyright { get; set; }

        public virtual ICollection<EExamPosition> ExamPositions { get; set; }
        public virtual ICollection<EQuestion> Questions { get; set; }
        public virtual ICollection<ETakenExam> TakenExams { get; set; }
    }
}

