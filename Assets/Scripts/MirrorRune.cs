using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRune : MonoBehaviour
{
    [HideInInspector] public MirrorEnigme enigmeParent;

    [HideInInspector] public bool isActive = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableCrate"))
        {
            isActive = true;
            enigmeParent.CheckAllRuneSet();
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableCrate"))
        {
            isActive = false;
            enigmeParent.CheckAllRuneSet();
        }
    }
}
