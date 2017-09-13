using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DPosition : DBase, IDPosition
    {
        public DPosition() : base(new Context())
        {
        }
    }
}
