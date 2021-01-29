namespace ChessBoard.Main
{
    public class Direction
    {
        public Direction(int vertical, int horizontal)
        {
            Vertical = vertical;
            Horizontal = horizontal;
        }

        public int Vertical { get; }
        public int Horizontal { get; }
    }
}
