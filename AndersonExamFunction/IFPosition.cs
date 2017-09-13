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
        List<Position> Read();
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
