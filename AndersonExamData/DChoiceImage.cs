using AndersonExamContext;
using BaseData;

namespace AndersonExamData
{
    public class DChoiceImage : DBase, IDChoiceImage
    {
        public DChoiceImage() : base(new Context())
        {
        }
    }
}
