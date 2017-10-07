using AndersonExamEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonExamData
{
    public interface IDExamPosition : IDBase
    {
        List<EExamPosition> Read(int positionId);
    }
}
