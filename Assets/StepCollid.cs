using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCollid : MonoBehaviour
{
    [HideInInspector] public StepEnigm stepEnigm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stepEnigm.AddTouch(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stepEnigm.RemoveTouch(this);
        }
    }
}