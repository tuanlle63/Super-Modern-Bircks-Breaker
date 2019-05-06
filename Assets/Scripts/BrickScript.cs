using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int point;
    public int hittobreak;
    public Sprite hitSprite;

    public void BreakBrick()
    {
        hittobreak--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
