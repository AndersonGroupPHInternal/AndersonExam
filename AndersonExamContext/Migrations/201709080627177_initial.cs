namespace AndersonExamContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        ChoiceId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        TakenExamId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Choice", t => t.ChoiceId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.TakenExam", t => t.TakenExamId)
                .Index(t => t.ChoiceId)
                .Index(t => t.QuestionId)
                .Index(t => t.TakenExamId);
            
            CreateTable(
                "dbo.Choice",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        Correct = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        TimeLimit = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Instructions = c.String(),
                        Copyright = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamId);
            
            CreateTable(
                "dbo.ExamPosition",
                c => new
                    {
                        ExamPositionId = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamPositionId)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.Position", t => t.PositionId)
                .Index(t => t.ExamId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.Examinee",
                c => new
                    {
                        ExamineeId = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(nullable: false),
                        ReferenceCode = c.String(),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Middlename = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamineeId)
                .ForeignKey("dbo.Position", t => t.PositionId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.TakenExam",
                c => new
                    {
                        TakenExamId = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        ExamineeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TakenExamId)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.Examinee", t => t.ExamineeId)
                .Index(t => t.ExamId)
                .Index(t => t.ExamineeId);
            
            CreateTable(
                "dbo.QuestionImage",
                c => new
                    {
                        QuestionImageId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Url = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionImageId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.ChoiceImage",
                c => new
                    {
                        ChoiceImageId = c.Int(nullable: false, identity: true),
                        ChoiceId = c.Int(nullable: false),
                        Url = c.String(),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceImageId)
                .ForeignKey("dbo.Choice", t => t.ChoiceId)
                .Index(t => t.ChoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChoiceImage", "ChoiceId", "dbo.Choice");
            DropForeignKey("dbo.Answer", "TakenExamId", "dbo.TakenExam");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Answer", "ChoiceId", "dbo.Choice");
            DropForeignKey("dbo.Choice", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionImage", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.ExamPosition", "PositionId", "dbo.Position");
            DropForeignKey("dbo.TakenExam", "ExamineeId", "dbo.Examinee");
            DropForeignKey("dbo.TakenExam", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.Examinee", "PositionId", "dbo.Position");
            DropForeignKey("dbo.ExamPosition", "ExamId", "dbo.Exam");
            DropIndex("dbo.ChoiceImage", new[] { "ChoiceId" });
            DropIndex("dbo.QuestionImage", new[] { "QuestionId" });
            DropIndex("dbo.TakenExam", new[] { "ExamineeId" });
            DropIndex("dbo.TakenExam", new[] { "ExamId" });
            DropIndex("dbo.Examinee", new[] { "PositionId" });
            DropIndex("dbo.ExamPosition", new[] { "PositionId" });
            DropIndex("dbo.ExamPosition", new[] { "ExamId" });
            DropIndex("dbo.Question", new[] { "ExamId" });
            DropIndex("dbo.Choice", new[] { "QuestionId" });
            DropIndex("dbo.Answer", new[] { "TakenExamId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropIndex("dbo.Answer", new[] { "ChoiceId" });
            DropTable("dbo.ChoiceImage");
            DropTable("dbo.QuestionImage");
            DropTable("dbo.TakenExam");
            DropTable("dbo.Examinee");
            DropTable("dbo.Position");
            DropTable("dbo.ExamPosition");
            DropTable("dbo.Exam");
            DropTable("dbo.Question");
            DropTable("dbo.Choice");
            DropTable("dbo.Answer");
        }
    }
}
