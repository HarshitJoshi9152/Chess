using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override PieceType pieceType {get; set;} = PieceType.Pawn;

    // Hum how do we handle Castling
    // and En passant
    public override Vector2Int[,] moveset {get; set;} = new Vector2Int[1, 1]
        {
            { Vector2Int.up }, // Top
            // uhhh but top for the enemy pieces is Down !
            // should we even care about that ...??? coz its going to be multiplayer anyways...
        };

    private void OnMouseDown()
    {
        // Check If its the turn of the player
        // Attach to Mouse pointer, Snap to Grid of Routes, Make Transparent
        // 
    }
}
