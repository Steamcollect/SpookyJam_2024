using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Transform player;

    public float timeOffset;

    [HideInInspector]public float orthoSize;
    public float orthoSizeTime;
    float orthoSizeVel;
    float initOrthoSize;

   [Range(0,1)] public float percentageDist;

    public Vector3 posOffset;

    public Camera cam;

    Vector3 velocity;

    public static CameraController instance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        instance = this;
    }

    private void Start()
    {
        orthoSize = cam.orthographicSize;
        initOrthoSize = orthoSize;
    }

    private void Update()
    {
        Vector3 targetPos = Vector3.Lerp(target.position, cam.ScreenToWorldPoint(Input.mousePosition), percentageDist);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos + posOffset, ref velocity, timeOffset);

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, orthoSize, ref orthoSizeVel, orthoSizeTime);
    }

    public void ChangeTarget(Transform target)
    {
        this.target = target;
    }
    public void ChangeTargetToPlayer()
    {
        target = player;
    }

    public void ResetOrthoSize()
    {
        orthoSize = initOrthoSize;
    }
}