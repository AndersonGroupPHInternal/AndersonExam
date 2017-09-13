using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DQuestion : DBase, IDQuestion
    {
        public DQuestion() : base(new Context())
        {
        }
    }
}
