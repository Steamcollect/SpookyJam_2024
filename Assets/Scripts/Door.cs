using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer graphics;
    public Sprite openSprite, closeSprite;

    public Collider2D collid;

    public void OpenDoor()
    {
        graphics.sprite = openSprite;
        collid.enabled = false;
    }

    public void CloseDoor()
    {
        graphics.sprite = closeSprite;
        collid.enabled = true;
    }
}