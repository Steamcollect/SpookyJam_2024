using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public float timeOffset;
    Vector2 velocity;

    public float velocityRotDiviser;
    public float rotationAmount;
    public float rotationSpeed;

    Vector3 rotationDelta;

    public Camera cam;

    private void Update()
    {
        Vector2 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Movement
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, timeOffset);

        // Rotation
        Vector3 movementRot = -(velocity / velocityRotDiviser * rotationAmount);
        rotationDelta = Vector3.Lerp(rotationDelta, movementRot, rotationSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(rotationDelta.x, -60, 60));
    }
}