namespace Chessbot.Parsing

open Chessbot.Domain.Models
open FParsec
open System

module Parsers =
    let files = "abcdefgh"

    let color =
        (pchar 'w' >>% PieceColor.White) <|>
        (pchar 'b' >>% PieceColor.Black)
    
    let piece = function
        | 'p' -> Piece.Pawn
        | 'n' -> Piece.Knight
        | 'b' -> Piece.Bishop
        | 'r' -> Piece.Rook
        | 'q' -> Piece.Queen
        | 'k' -> Piece.King
        | c -> failwith $"Invalid piece: {c}"

    let tiles =
        let occupied =
            anyOf "pnbrqkPNBRQK" |>> fun c ->
                let piece = Char.ToLower c |> piece
                let color =
                    if isAsciiUpper c
                    then PieceColor.White
                    else PieceColor.Black

                [| Tile(piece, color) |]
        
        let empty =
            digit |>> fun c -> Array.create (int (c - '0')) null

        empty <|> occupied

    let row =
        manyTill tiles (anyOf "/ ")
        |>> Array.concat

    let board =
        parray 8 row |>> Board

    let castle =
        let side =
            anyOf "kqKQ-"
            |>> function
            | 'K' -> CastleState.WhiteKingSide
            | 'Q' -> CastleState.WhiteQueenSide
            | 'k' -> CastleState.BlackKingSide
            | 'q' -> CastleState.BlackQueenSide
            | '-' -> CastleState.None
            | c -> failwith $"Invalid castle state: {c}"

        parray 4 side
        |>> Array.reduce (+)

    let position =
        let file = anyOf files |>> files.IndexOf
        let rank = digit |>> fun c -> int (c - '1')
        tuple2 file rank |>> BoardPosition

    let state =
        pipe4 board color castle position
            (fun board color castle position -> new GameState(
                Board=board,
                CurrentColor=color,
                CastleState=castle,
                EnPassentSquare=position))

    let move =
        tuple2 position position |>> Move
    
    let action =
        (pstring "drop" >>% PieceInteraction.Drop) <|>
        (pstring "lift" >>% PieceInteraction.Lift)

    let interaction =
        pipe2 (action .>> spaces) position (fun action pos ->
            new PieceInteractionEvent(Location = pos, Action = action))

    let unwrap = function
        | Success(result, _, _) -> result
        | Failure(err, _, _) -> raise (Exception(err))
    
    let ParseGameState fen =
        run state fen
        |> unwrap

    let ParseMove uci =
        run move uci
        |> unwrap

    let ParseInteraction uci =
        run interaction uci
        |> unwrap
