using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType
{
    None,
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}

public abstract class Piece : MonoBehaviour
{
    // What is C#'s issue with fields lol !
    public abstract PieceType pieceType { get; set; }
    public abstract Vector2Int[,] moveset { get; set; }
    // The idea is that the possible Path for the piece will be 
    // Hard coded in the Class
    // 1st level of List represents all possible paths
    // 2nd level of List represents the tiles/cells of current path
}
