using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCrate : MonoBehaviour
{
    public Transform mirrorPoint;

    public Rigidbody2D rb;
    public Transform mirrorCrate;

    private void Start()
    {
        float x = mirrorPoint.position.x - transform.position.x;
        mirrorCrate.position = new Vector2(mirrorPoint.position.x + x, transform.position.y);
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.05f)
        {
            float x = mirrorPoint.position.x - transform.position.x;
            mirrorCrate.position = new Vector2(mirrorPoint.position.x + x, transform.position.y);
        }
    }
}