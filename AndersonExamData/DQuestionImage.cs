using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DQuestionImage : DBase, IDQuestionImage
    {
        public DQuestionImage() : base(new Context())
        {
        }
    }
}
