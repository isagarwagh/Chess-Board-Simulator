namespace ChessBoard.Main
{
    public abstract class BaseSoldier
    {
        public BaseSoldier(SoldierColor color)
        {
            Color = color;
        }

        public abstract Direction[] PossibleDirections { get; }

        public SoldierColor Color { get; }
    }
}
