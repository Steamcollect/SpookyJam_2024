using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OrderInLayerUpdate : MonoBehaviour
{
    SpriteRenderer graphics;

    private void Awake()
    {
        graphics = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (graphics != null)
        {
            graphics.sortingOrder = (int)(transform.position.y * 10) * -1;
        }
    }
}