using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    int BoardHeight = 8;
    int BoardWidth = 8;

    // Array of Array of GameObjects all of type pieces...
    GameObject[,] BoardState = new GameObject[8,8];

    /// OH wait ... lmao ....
    PieceType[,] StartLayout = new PieceType[8, 8]
    {
        { PieceType.Rook, PieceType.Rook, PieceType.Bishop, PieceType.King, PieceType.Queen, PieceType.Bishop, PieceType.Knight, PieceType.Rook },
        { PieceType.Rook, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.King, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, PieceType.None, },
        { PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn, PieceType.Pawn },
        { PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.King, PieceType.Queen, PieceType.Bishop, PieceType.Knight, PieceType.Rook }
    };

    public GameObject HighlightPrefab;

    List<GameObject> HighligtedSquares = new List<GameObject>();

    void Start()
    {
        Debug.Assert(sprite != null, "Sprite is Null", this.gameObject);
        Debug.Assert(BottomLeftPiece != null, "BottomLeftPiece is Null", this.gameObject);

        Debug.Assert(KingPrefab != null, "KingPrefab is not assigned", this.gameObject);
        Debug.Assert(QueenPrefab != null, "QueenPrefab is not assigned", this.gameObject);
        Debug.Assert(BishopPrefab != null, "BishopPrefab is not assigned", this.gameObject);
        Debug.Assert(KnightPrefab != null, "KnightPrefab is not assigned", this.gameObject);
        Debug.Assert(RookPrefab != null, "RookPrefab is not assigned", this.gameObject);
        Debug.Assert(PawnPrefab != null, "PawnPrefab is not assigned", this.gameObject);

        Debug.Assert(HighlightPrefab != null, "HighlightPrefab is not assigned", this.gameObject);


        PopulatePieces();
    }

    private List<Vector2> onPieceHighlight(Vector2Int PiecePos)
    {
        List<Vector2> ValidSquares = new List<Vector2>();
        
        GameObject piece = BoardState[PiecePos.x, PiecePos.y];

        Piece pieceScript = piece.GetComponent<Piece>();

        for (int moveSetCounter = 0; moveSetCounter < pieceScript.moveset.GetLength(0); moveSetCounter++)
        {
            for (int moveCounter = 0; moveCounter < pieceScript.moveset.GetLength(1); moveCounter++)
            {
                Vector2Int offset = pieceScript.moveset[moveSetCounter, moveCounter];
                Vector2Int square = PiecePos + new Vector2Int(offset.y, offset.x);

                // Check If Square is Not on Board..
                if (square.x < 0 || square.y < 0 || square.x >= BoardHeight || square.y >= BoardWidth) continue;
                // Debug.Log(square); // x -> Row , y -> Col Yeah just remember this...

                if (isSquareEmpty(square))
                {
                    // Convert to World Coordinates and Add 
                    Vector2 square_loc = getSquareLocation(square);

                    ValidSquares.Add(square_loc);
                    GameObject highlightSquare = Instantiate(HighlightPrefab, square_loc, Quaternion.identity);
                    HighligtedSquares.Add(highlightSquare);
                }
                // TOOD: for the Knight We need to Code this seperately
            }
        }

        return ValidSquares;
    }
    
    private void onPieceStopHighlight()
    {
        foreach(var highlightSquare in HighligtedSquares)
        {
            Destroy(highlightSquare);
        }

        HighligtedSquares.Clear();
    }

    private bool isSquareEmpty(Vector2Int loc)
    {
        return BoardState[loc.x, loc.y] == null;
    }

    private Vector2 getSquareLocation(Vector2Int pos)
    {
        Debug.Assert(pos.x < 8 && pos.y < 8 && pos.x >= 0 && pos.y >= 0 , "Pos Out of Range !", this.gameObject);

        float start_x = BottomLeftPiece.transform.position.x;
        float start_y = BottomLeftPiece.transform.position.y;

        // [i, ii] -> .y is actually used for the x-pos in PopulatePieces and .x for y-pos...
        return new Vector2(start_x + pos.y * spriteWidth, start_y + pos.x * spriteHeight);

    }

    private void PopulatePieces()
    {
        int start_x = (int)BottomLeftPiece.transform.position.x;
        int start_y = (int)BottomLeftPiece.transform.position.y;

        for (int i = 0; i < BoardHeight; i++)
        {
            int y = i * spriteHeight + start_y;
            for (int ii = 0; ii < BoardWidth; ii++)
            {
                int x = ii * spriteWidth + start_x;
                PieceType pieceType = StartLayout[i, ii];

                GameObject piece = null;
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
                // Initialze the spawnedPiece
                PieceGrabScript pieceGrabScript = spawned_piece.GetComponent<PieceGrabScript>();
                pieceGrabScript.Init(new Vector2Int(i, ii)); // x here represents RowCount and y ColCount

                // Subscribe to Drag Events
                pieceGrabScript.HighlightEvent += onPieceHighlight;
                pieceGrabScript.StopHighlightEvent += onPieceStopHighlight;

                /* TODO: WHEN A PIECE IS DESTROYED
                PieceGrabScript pieceGrabScript = highlightSquare.GetComponent<PieceGrabScript>();
                // Unsubscribe from events
                pieceGrabScript.HighlightEvent -= onPieceHighlight;
                pieceGrabScript.StopHighlightEvent -= onPieceStopHighlight;
                */

                // Place the piece in state
                BoardState[i, ii] = spawned_piece;
            }
        }
    }

}
