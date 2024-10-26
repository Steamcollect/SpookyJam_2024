using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRune : MonoBehaviour
{
    [HideInInspector] public MirrorEnigme enigmeParent;

    [HideInInspector] public bool isActive = false;

    public Color disableColor = Color.white;
    public SpriteRenderer graphics;

    List<Collider2D> collidsTouch = new List<Collider2D> ();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableCrate"))
        {
            isActive = true;
            enigmeParent.CheckAllRuneSet();

            collidsTouch.Add(collision);

            if(graphics) graphics.color = Color.white;
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableCrate"))
        {
            collidsTouch.Remove(collision);

            if(collidsTouch.Count <= 0)
            {
                isActive = false;
                enigmeParent.CheckAllRuneSet();

                if (graphics) graphics.color = disableColor;
            }            
        }
    }
}
