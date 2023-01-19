namespace Chessbot.Domain.Exceptions
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException() : this("Illegal move!") { }
        public IllegalMoveException(string message) : base(message) { }
    }
}
