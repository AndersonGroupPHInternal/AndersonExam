using AndersonExamModel;
using System.Collections.Generic;

namespace AndersonExamFunction
{
    public interface IFPosition
    {
        #region CREATE
        Position Create(Position position);
        #endregion

        #region READ
        Position Read(int positionId);
        Position Read(string positionName);
        List<Position> Read();
        List<Position> ReadExamForPosition(int takenExamId);  
        #endregion

        #region UPDATE
        Position Update(Position position);
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
