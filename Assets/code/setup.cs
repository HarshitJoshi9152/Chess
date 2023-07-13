using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.coreMo

public class setup : MonoBehaviour
{
    public GameObject SpawnStart;

    public GameObject sprite;
    public int spriteHeight;
    public int spriteWidth;

    public float offsetx = 8;
    public float offsety = 8;
    // Start is called before the first frame update

    private int BoardHeight = 8;
    private int BoardWidth = 8;

    void Start()
    {
        // Get Sprite Width and Height and remove public w, h;

        Debug.Assert(sprite != null, "Sprite is Null", this.gameObject);
        Debug.Assert(SpawnStart != null, "Sprite is Null", this.gameObject);

        float total_offset_x = SpawnStart.transform.position.x + offsetx + spriteWidth / 2;
        float total_offset_y = SpawnStart.transform.position.y + offsety + spriteHeight / 2;

        for (float i = 0; i < BoardHeight; i++)
        {
            float y = i * spriteHeight + total_offset_y;

            for (float ii = 0; ii < BoardWidth; ii++)
            {
                float x = ii * spriteWidth + total_offset_x;

                GameObject piece = Instantiate(sprite, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        // get player display preferences and display the correct board lol
        // Make a Grid and Place Pieces
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
