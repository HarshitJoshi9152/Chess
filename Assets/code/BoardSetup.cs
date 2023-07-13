using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.coreMo

public class setup : MonoBehaviour
{
    public GameObject BottomLeftPiece;
    public GameObject sprite;

    public int spriteHeight;
    public int spriteWidth;

    // Start is called before the first frame update
    int BoardHeight = 8;
    int BoardWidth = 8;

    // Array of Array of GameObjects all of type pieces...
    GameObject[,] pieces = {
        // should i make an array of Prefabs here or....
    };

    PieceType[,] StartLayout = new PieceType[8, 8]
    {
        { PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.King, PieceType.Queen, PieceType.Bishop, PieceType.Knight, PieceType.Rook },
        { PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn },
        { PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.King, PieceType.Queen, PieceType.Bishop, PieceType.Knight, PieceType.Rook }
    };



    void Start()
    {
        // Get Sprite Width and Height and remove public w, h;

        Debug.Assert(sprite != null, "Sprite is Null", this.gameObject);
        Debug.Assert(BottomLeftPiece != null, "BottomLeftPiece is Null", this.gameObject);

        PlacePieces();

        // get player display preferences and display the correct board lol
        // Make a Grid and Place Pieces

    }

    private void PlacePieces()
    {
        int start_x = (int)BottomLeftPiece.transform.position.x;
        int start_y = (int)BottomLeftPiece.transform.position.y;

        int x = start_x;
        int y = start_y;

        for (int i = 0; i < BoardHeight; i++)
        {
            for (int ii = 0; ii < BoardWidth; ii++)
            {
                if (i > 1 && i < 6) continue;
                // To avoid placing Pieces in the Center;
                GameObject piece = Instantiate(sprite, new Vector3(x, y, 0), Quaternion.identity);
                x += spriteWidth;
            }
            x = start_x;
            y += spriteHeight;
        }
    }

}
