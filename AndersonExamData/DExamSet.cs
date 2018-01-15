using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DExamSet : DBase, IDExamSet
    {
        public DExamSet() : base(new Context())
        {
        }
    }
}