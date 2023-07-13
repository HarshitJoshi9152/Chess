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

    public GameObject KingPrefab;
    public GameObject QueenPrefab;
    public GameObject BishopPrefab;
    public GameObject KnightPrefab;
    public GameObject RookPrefab;
    public GameObject PawnPrefab;

    // Start is called before the first frame update
    int BoardHeight = 8;
    int BoardWidth = 8;

    // Array of Array of GameObjects all of type pieces...
    GameObject[,] BoardState = new GameObject[8,8];

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

        Debug.Assert(KingPrefab != null, "KingPrefab is not assigned", this.gameObject);
        Debug.Assert(QueenPrefab != null, "QueenPrefab is not assigned", this.gameObject);
        Debug.Assert(BishopPrefab != null, "BishopPrefab is not assigned", this.gameObject);
        Debug.Assert(KnightPrefab != null, "KnightPrefab is not assigned", this.gameObject);
        Debug.Assert(RookPrefab != null, "RookPrefab is not assigned", this.gameObject);
        Debug.Assert(PawnPrefab != null, "PawnPrefab is not assigned", this.gameObject);


        PopulatePieces();
        //PlacePieces();

        // get player display preferences and display the correct board lol
        // Make a Grid and Place Pieces

    }

    private void PopulatePieces()
    {
        // also places the Prefabs lol
        int start_x = (int)BottomLeftPiece.transform.position.x;
        int start_y = (int)BottomLeftPiece.transform.position.y;

        int x = start_x;
        int y = start_y;

        // use StartLayout and Populate the Starting State of the Board.
        for (int i = 0; i < BoardHeight; i++)
        {
            for (int ii = 0; ii < BoardWidth; ii++)
            {
                // Populate the Pieces 
                GameObject piece = null;

                PieceType pieceType = StartLayout[i, ii];
                // awesome autocomplete
                switch (pieceType)
                {
                    case PieceType.None:
                        // hmmmm continue ???
                        continue;
                    case PieceType.King:
                        piece = KingPrefab;
                        break;
                    case PieceType.Queen:
                        piece = QueenPrefab;
                        break;
                    case PieceType.Rook:
                        piece = RookPrefab;
                        break;
                    case PieceType.Bishop:
                        piece = BishopPrefab;
                        break;
                    case PieceType.Knight:
                        piece = KnightPrefab;
                        break;
                    case PieceType.Pawn:
                        piece = PawnPrefab;
                        break;
                    default:
                        break;
                }

                // Instantiate Piece But what about the position ...!!!
                GameObject spawned_piece = Instantiate(piece, new Vector3(x, y, 0), Quaternion.identity);
                BoardState[i, ii] = spawned_piece;

                x += spriteWidth;
            }
            x = start_x;
            y += spriteHeight;
        }
    }

    // Obsolete now lmao
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


    // When a Piece is CLicked Fire the isHighlighted Event and Highlight the Valid Squares on the Board
}
