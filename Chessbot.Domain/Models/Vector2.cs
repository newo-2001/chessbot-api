using System.Numerics;

namespace Chessbot.Domain.Models;
public record Vector2<T>(T X, T Y) where T : INumber<T>
{
    public override string ToString() => $"({X}, {Y})";

    public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2<T> operator +(Vector2<T> vec, T scalar) => new(vec.X + scalar, vec.Y + scalar);
    public static Vector2<T> operator -(Vector2<T> a, Vector2<T> b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2<T> operator -(Vector2<T> vec, T scalar) => new(vec.X - scalar, vec.Y - scalar);
    public static Vector2<T> operator *(Vector2<T> vec, T scalar) => new(vec.X * scalar, vec.Y * scalar);

    public static readonly Vector2<T> Zero = new(T.Zero, T.Zero);
    public static readonly Vector2<T> One = new(T.One, T.One);
}