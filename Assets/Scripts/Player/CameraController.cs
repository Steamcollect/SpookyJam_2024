using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float timeOffset;

   [Range(0,1)] public float percentageDist;

    public Vector3 posOffset;

    public Camera cam;

    Vector3 velocity;

    private void Update()
    {
        Vector3 targetPos = Vector3.Lerp(target.position, cam.ScreenToWorldPoint(Input.mousePosition), percentageDist);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos + posOffset, ref velocity, timeOffset);
    }
}