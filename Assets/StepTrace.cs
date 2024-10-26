using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrace : MonoBehaviour
{
    public bool isActive;

    public Color enableColor, disableColor;
    public SpriteRenderer graphics;

    [HideInInspector] public StepEnigm stepEnigm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && stepEnigm.CanActiveStep(this))
        {
            isActive = true;
            graphics.color = enableColor;
            stepEnigm.CheckAllTraceActive();
        }
    }

    public void Disable()
    {
        isActive = false;
        graphics.color = disableColor;
    }
}