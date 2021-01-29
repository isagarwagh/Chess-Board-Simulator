namespace ChessBoard.Main
{
    public class BoardCell
    {
        public BoardCell(BoardCellColor color)
        {
            Color = color;
        }

        public BoardCellColor Color { get; }

        public BaseSoldier Soldier { get; set; }

        public bool IsEmpty => Soldier == null;
    }
}
