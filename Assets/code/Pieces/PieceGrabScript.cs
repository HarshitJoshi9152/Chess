using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceGrabScript : MonoBehaviour
{
    private float GrabOffset = 2;

    private bool isGrabbed = false;
    private Vector2 PosBeforeGrab = Vector2.zero;
    private int defaultSortingOrder = 0;


    /// <summary>
    /// Sends Own Squares[x, y] and get the list of valid Squares (highlighted)
    /// </summary>
    public event Func<Vector2Int, List<Vector2>> HighlightEvent;
    public event Action StopHighlightEvent;
    private Vector2Int BoardLocation = Vector2Int.zero;

    private List<Vector2> ValidSquares = new List<Vector2>();

    public void Init(Vector2Int location)
    {
        BoardLocation = location;
    }

    private void Start()
    {
        defaultSortingOrder = GetComponent<Renderer>().sortingOrder;
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Todo: Add Sticking to Valid Squares to Move on !
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 nextPos = new Vector3(mousePosInWorld.x, mousePosInWorld.y, 0);

            // Check if nextPos is Over any Highlighted Square...
            foreach (Vector2 square in ValidSquares)
            {
                // square.x and y are the centers of square !

                float start_x = square.x - (16 / 2 + GrabOffset);
                float end_x = square.x + (16 / 2 + GrabOffset);

                float start_y = square.y - (16 / 2 + GrabOffset);
                float end_y = square.y + (16 / 2 + GrabOffset);

                if (nextPos.x >= start_x && nextPos.x <= end_x)
                {
                    if (nextPos.y >= start_y && nextPos.y <= end_y)
                    {
                        // Snap to Position... ie center of the square
                        nextPos = new Vector2(square.x, square.y);
                        break;
                    }
                }
            }

            transform.position = nextPos;
        }
    }

    protected void OnMouseUp()
    {
        StopHighlightEvent.Invoke();

        isGrabbed = false;
        transform.position = PosBeforeGrab;
        GetComponent<Renderer>().sortingOrder = defaultSortingOrder;
        ValidSquares.Clear();
    }

    protected void OnMouseDown()
    {
        isGrabbed = true;
        PosBeforeGrab = transform.position;
        // Grabbed piece should be rendered Above other pieces
        GetComponent<Renderer>().sortingOrder = 100;
        ValidSquares = HighlightEvent.Invoke(BoardLocation);   
    }
}
