using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepEnigm : MonoBehaviour
{
    public StepTrace[] stepTrace;
    public StepCollid[] stepsOnRoom;

    public Door door;
    bool isDoorOpen = false;

    List<StepCollid> currentStepTouching = new List<StepCollid>();

    private void Start()
    {
        for (int i = 0; i < stepsOnRoom.Length; i++)
        {
            stepsOnRoom[i].stepEnigm = this;
        }

        for (int i = 0;i < stepTrace.Length; i++)
        {
            stepTrace[i].stepEnigm = this;
            stepTrace[i].Disable();
        }
    }

    public void AddTouch(StepCollid step)
    {
        currentStepTouching.Add(step);
    }

    public void RemoveTouch(StepCollid step)
    {
        currentStepTouching.Remove(step);
        if(currentStepTouching.Count <= 0)
        {
            LanternController.instance.SetActiveLight(true);
            ResetSteps();
        }
    }

    public bool CanActiveStep(StepTrace step)
    {
        if(step == stepTrace[0])
        {
            LanternController.instance.SetActiveLight(false);
            return true;
        }

        if (stepTrace[0].isActive) return true;
        else return false;
    }

    private void ResetSteps()
    {
        if (isDoorOpen) return;

        for (int i = 0;i < stepTrace.Length; i++)
        {
            stepTrace[i].Disable();
        }
    }

    public void CheckAllTraceActive()
    {
        if (AllTraceActive())
        {
            isDoorOpen = true;
            door.OpenDoor();
            LanternController.instance.SetActiveLight(true);
        }
    }

    bool AllTraceActive()
    {
        for (int i = 0; i < stepTrace.Length; i++)
        {
            if (stepTrace[i].isActive == false) return false;
        }
        return true;
    }
}