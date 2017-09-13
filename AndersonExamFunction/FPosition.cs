using AndersonExamData;
using AndersonExamEntity;
using AndersonExamModel;
using System.Collections.Generic;
using System.Linq;

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
                Name = a.Name
            });

            return returnPositions.ToList();
        }

        private EPosition EPosition(Position position)
        {
            EPosition returnEPosition = new EPosition
            {
                PositionId = position.PositionId,

                Description = position.Description,
                Name = position.Name
            };
            return returnEPosition;
        }

        private Position Position(EPosition ePosition)
        {
            Position returnPosition = new Position
            {
                PositionId = ePosition.PositionId,

                Description = ePosition.Description,
                Name = ePosition.Name
            };
            return returnPosition;
        }
        #endregion
    }
}
