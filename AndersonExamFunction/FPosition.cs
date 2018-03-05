using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonExamFunction
{
    public class FPosition : IFPosition
    {
        private IDPosition _iDPosition;

        public FPosition(IDPosition iDPosition)
        {
            _iDPosition = iDPosition;
        }

        #region CREATE
        public Position Create(Position position)
        {
            EPosition ePosition = EPosition(position);
            ePosition = _iDPosition.Create(ePosition);
            return Position(ePosition);
        }
        #endregion

        #region READ
        public Position Read(string positionName)
        {

            var ePosition = _iDPosition.Read<EPosition>(a => a.PositionName == positionName);

            if (ePosition == null)
                return new Position();

            return Position(ePosition);
        }

        public List<Position> Read()
        {
            List<EPosition> ePositions = _iDPosition.List<EPosition>(a => true);
            return Positions(ePositions);
        }
        #endregion

        #region UPDATE
        public Position Update(Position position)
        {
            var ePosition = _iDPosition.Update(EPosition(position));
            return (Position(ePosition));
        }
        #endregion

        #region DELETE
        #endregion

        #region OTHER FUNCTION
        private List<Position> Positions(List<EPosition> ePositions)
        {
            var returnPositions = ePositions.Select(a => new Position
            {
                PositionId = a.PositionId,

                Description = a.Description,
                PositionName = a.PositionName
            });

            return returnPositions.ToList();
        }

        private EPosition EPosition(Position position)
        {
            EPosition returnEPosition = new EPosition
            {
                PositionId = position.PositionId,

                Description = position.Description,
                PositionName = position.PositionName
            };
            return returnEPosition;
        }

        private Position Position(EPosition ePosition)
        {
            Position returnPosition = new Position
            {
                PositionId = ePosition.PositionId,

                Description = ePosition.Description,
                PositionName = ePosition.PositionName
            };
            return returnPosition;
        }

        public Position Read(int positionId)
        {
            //throw new System.NotImplementedException();
            EPosition ePosition = _iDPosition.Read<EPosition>(a => a.PositionId == positionId);
            return Position(ePosition);
        }

        public List<Position> ReadExamForPosition(int takenExamId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
