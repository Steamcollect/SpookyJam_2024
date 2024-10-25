using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    public int blueFireId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainFireController.instance.ActiveFire(blueFireId, true);
            gameObject.SetActive(false);
        }
    }
}