using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGrabScript : MonoBehaviour
{

    private bool isGrabbed = false;
    private Vector2 PosBeforeGrab = Vector2.zero;
    void Update()
    {
        if (isGrabbed)
        {
            // is Calling this function every frame okay ???
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 nextPos = new Vector3(mousePosInWorld.x, mousePosInWorld.y, 0);
            transform.position = nextPos;
        }
    }


    protected void OnMouseUp()
    {
        isGrabbed = false;
        transform.position = PosBeforeGrab;
        // reset to original Position if not Snapped to a Valid position
    }

    // Update is called once per frame
    protected void OnMouseDown()
    {
        isGrabbed = true;
        PosBeforeGrab = transform.position;
        // Check If its the turn of the player
        // Attach to Mouse pointer, Snap to Grid of Routes, Make Transparent
        // 

    }
}
