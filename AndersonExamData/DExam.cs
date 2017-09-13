using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DExam : DBase, IDExam
    {
        public DExam() : base(new Context())
        {
        }
    }
}
