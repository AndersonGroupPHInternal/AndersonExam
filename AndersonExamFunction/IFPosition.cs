﻿using AndersonExamModel;
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
        List<Position> Read();
        List<Position> ReadExamForPosition(int examId);   
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
