using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DExamSetPosition : DBase, IDExamSetPosition
    {
        public DExamSetPosition() : base(new Context())
        {
        }
    }
}
