using System.Data.Entity;

namespace AndersonExamContext
{

    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}
