namespace ChessBoard.Main
{
    public class PositionBuilder
    {
        private readonly int _rowLimit;
        private readonly int _columnLimit;

        public PositionBuilder(int rowLimit, int columnLimit)
        {
            _rowLimit = rowLimit;
            _columnLimit = columnLimit;
        }

        internal BoardPosition TryBuildNewPosition(BoardPosition currentPosition, Direction direction)
        {
            int newRow = currentPosition.Row + direction.Vertical;
            int newColumn = currentPosition.Column + direction.Horizontal;

            if (newRow < 0 || newColumn < 0 || newRow > _rowLimit
                    || newColumn > _columnLimit)
                return null;

            return new BoardPosition(newRow, newColumn);
        }
    }
}
