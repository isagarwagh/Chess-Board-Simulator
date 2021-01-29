namespace ChessBoard.Main
{
    public class EmptyCellsBuilder
    {
        public BoardCell[,] BuildCells(BoardCellColor evenCellColor, BoardCellColor oddCellColor)
        {
            BoardCell[,] cells = new BoardCell[8, 8];

            for (int row = 0; row <= 7; row++)
            {
                for (int column = 0; column <= 7; column++)
                {
                    var color = column % 2 == 0 ? evenCellColor : oddCellColor;
                    cells[row, column] = new BoardCell(color);
                }
            }

            return cells;
        }
    }
}
