using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Transform pillarShadow;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 lookDir = LanternController.instance.transform.position - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        pillarShadow.rotation = Quaternion.Euler(0, 0, angle);

        if(Vector2.Distance(LanternController.instance.transform.position, transform.position) > LanternController.instance.lightDistance)
        {
            pillarShadow.gameObject.SetActive(false);
        }
        else
        {
            pillarShadow.gameObject.SetActive(true);
        }
    }
}