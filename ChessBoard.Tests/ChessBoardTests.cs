using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace ChessBoard.Main
{
    public class ChessBoardTests
    {
        [Fact(DisplayName = "Board must provide possible moves given a soldier with its directions and current position")]
        public void Board_must_provide_possible_moves_given_a_soldier_with_its_directions_and_current_position()
        {
            var chaseBoard = new ChessBoard();
            var mockSoldier = new Mock<BaseSoldier>(SoldierColor.Black);
            mockSoldier.Setup(x => x.PossibleDirections)
                       .Returns(new Direction[]
                       {
                           new Direction(1, 1),
                           new Direction(-1, 1),
                           new Direction(1, -1),
                           new Direction(-1, -1),
                       });

            var currentPosition = new BoardPosition(3, 4);

            var possibleMoves = chaseBoard.GetPossibleMoves(mockSoldier.Object, currentPosition).ToList();

            possibleMoves.Should().HaveCountGreaterThan(0);
            possibleMoves.Exists(x=> x.Row == currentPosition.Row - 1 && x.Column == currentPosition.Column - 1).Should().BeTrue();
            possibleMoves.Exists(x => x.Row == currentPosition.Row - 1 && x.Column == currentPosition.Column + 1).Should().BeTrue();
            possibleMoves.Exists(x => x.Row == currentPosition.Row + 1 && x.Column == currentPosition.Column - 1).Should().BeTrue();
            possibleMoves.Exists(x => x.Row == currentPosition.Row + 1 && x.Column == currentPosition.Column + 1).Should().BeTrue();
        }

        [Theory(DisplayName = "Board must provide No possible moves when soldier directions are beyond board boundries")]
        [InlineData(0, 0, -1, 1)]
        [InlineData(0, 0, 1, -1)]
        [InlineData(0, 7, 1, 1)]
        [InlineData(0, 7, -1, -1)]
        [InlineData(7, 7, 1, 1)]
        [InlineData(7, 7, -1, 1)]
        [InlineData(7, 0, 1, 1)]
        [InlineData(7, 0, 1, -1)]
        public void Board_must_provide_No_possible_moves_when_soldier_directions_are_beyond_board_boundries(
            int currentRow, int currentColumn, int moveRow, int moveColumn)
        {
            var chaseBoard = new ChessBoard();
            var mockSoldier = new Mock<BaseSoldier>(SoldierColor.Black);
            mockSoldier.Setup(x => x.PossibleDirections)
                       .Returns(new Direction[]
                       {
                           new Direction(moveRow, moveColumn),
                       });

            var currentPosition = new BoardPosition(currentRow, currentColumn);

            var possibleMoves = chaseBoard.GetPossibleMoves(mockSoldier.Object, currentPosition).ToList();

            possibleMoves.Should().HaveCount(0);
        }
    }
}
