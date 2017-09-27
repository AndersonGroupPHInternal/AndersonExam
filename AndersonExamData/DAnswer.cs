using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DAnswer : DBase, IDAnswer
    {
        public DAnswer() : base(new Context())
        {
        }
    }
}
