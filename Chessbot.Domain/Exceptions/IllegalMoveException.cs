namespace Chessbot.Domain.Exceptions
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException(string message) : base(message) { }
    }
}
