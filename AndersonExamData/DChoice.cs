using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DChoice : DBase, IDChoice
    {
        public DChoice() : base(new Context())
        {
        }
    }
}
