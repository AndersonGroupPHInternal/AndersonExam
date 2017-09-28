using AndersonExamEntity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AndersonExamContext
{
    public class Context : DbContext
    {
        public Context() : base("AndersonExam")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<EAnswer> Answers { get; set; }
        public DbSet<EChoice> Choices { get; set; }
        public DbSet<EChoiceImage> ChoiceImages { get; set; }
        public DbSet<EExam> Exams { get; set; }
        public DbSet<EExaminee> Examinees { get; set; }
        public DbSet<EExamPosition> ExamPositions { get; set; }
        public DbSet<EPosition> Positions { get; set; }
        public DbSet<EQuestion> Questions { get; set; }
        public DbSet<EQuestionImage> QuestionImages { get; set; }
        public DbSet<ETakenExam> TakenExams { get; set; }
        
    }
}
