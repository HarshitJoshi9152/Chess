using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class King : Piece
{
    public override PieceType pieceType { get; set; } = PieceType.King;
    public override Vector2Int[,] moveset {get; set;} = new Vector2Int[8, 1] {
        { Vector2Int.right }, // Right
        { Vector2Int.left }, // Left
        { Vector2Int.up }, // Top
        { Vector2Int.down }, // Bottom
        { new Vector2Int(-1, 1) }, // Top Left
        { new Vector2Int(1, 1) }, // Top Right
        { new Vector2Int(-1, -1) }, // Bottom Left
        { new Vector2Int(1, -1) } // Bottom Right
    };


    private Vector2Int BoardLocation = Vector2Int.zero;

    //Events

    public event Action<Vector2Int> highlighted;

    public void Init(Vector2Int location)
    {
        BoardLocation= location;
    }

    public void Update()
    {
    }

    // Or maybe i can make a seperate behavior for that behavior... and add it to all the Piece Prefabs..
}
