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

// Makes me wonder if i should have used an ABC instead ...
public abstract class Piece : MonoBehaviour
{
    PieceType pieceType;
    Vector2[,] moveset;
    // The idea is that the possible Path for the piece will be 
    // Hard coded in the Class
    // 1st level of List represents all possible paths
    // 2nd level of List represents the tiles/cells of current path
}
