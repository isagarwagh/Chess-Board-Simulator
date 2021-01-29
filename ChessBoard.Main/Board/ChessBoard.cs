using System.Collections.Generic;

namespace ChessBoard.Main
{
    public class ChessBoard
    {
        private BoardCell[,] Cells { get; set; }

        private readonly PositionBuilder _positionBuilder;

        public ChessBoard()
        {
            Cells = new EmptyCellsBuilder().BuildCells(BoardCellColor.Black, BoardCellColor.White);
            _positionBuilder = new PositionBuilder(Cells.GetLength(0) - 1, Cells.GetLength(1) - 1);
        }

        public IEnumerable<BoardPosition> GetPossibleMoves(BaseSoldier soldier
            , BoardPosition currentPosition)
        {
            List<BoardPosition> possibleMoves = new List<BoardPosition>();
            foreach (var direction in soldier.PossibleDirections)
            {
                var newPosition = _positionBuilder.TryBuildNewPosition(currentPosition, direction);
                if (newPosition == null)
                    continue;

                var requiredBoardCell = Cells[newPosition.Row, newPosition.Column];

                if (requiredBoardCell.IsEmpty == true)
                {
                    possibleMoves.Add(newPosition);
                }
            }

            return possibleMoves;
        }
    }
}
