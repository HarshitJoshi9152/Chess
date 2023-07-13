using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override PieceType pieceType {get; set;} = PieceType.Knight;

    // Hum how do we handle Castling
    // and En passant
    public override Vector2Int[,] moveset {get; set;} = new Vector2Int[8, 1]
        {
            { Vector2Int.right }, // Right
            { Vector2Int.left }, // Left
            { Vector2Int.up }, // Top
            { Vector2Int.down }, // Bottom
            { new Vector2Int(-1, 1) }, // Top Left
            { new Vector2Int(1, 1) }, // Top Right
            { new Vector2Int(-1, -1) }, // Bottom Left
            { new Vector2Int(1, -1) } // Bottom Right
        };


    //void Highlight_path()
    //{

    //}

    // Update is called once per frame
    private void OnMouseDown()
    {
        // Check If its the turn of the player
        // Attach to Mouse pointer, Snap to Grid of Routes, Make Transparent
        // 
    }
}
