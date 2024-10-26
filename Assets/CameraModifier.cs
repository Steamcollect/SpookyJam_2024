using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModifier : MonoBehaviour
{
    public Transform newTarget;
    public float orthoSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraController.instance.ChangeTarget(newTarget);
            CameraController.instance.orthoSize = orthoSize;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraController.instance.ChangeTargetToPlayer();
            CameraController.instance.ResetOrthoSize();
        }
    }
}