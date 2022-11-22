﻿namespace Chessbot.Domain.Models.Pieces;
public enum PieceColor
{
    White, Black
}

public static class PieceColorExtensions
{
    public static PieceColor Complement(this PieceColor color) =>
        color == PieceColor.White ? PieceColor.Black : PieceColor.White;
}
