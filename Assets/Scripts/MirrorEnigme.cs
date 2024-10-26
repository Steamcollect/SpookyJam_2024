using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEnigme : MonoBehaviour
{
    public MirrorRune[] runes;
    public Door door;

    private void Start()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            runes[i].enigmeParent = this;
        }
    }

    public void CheckAllRuneSet()
    {
        if (HaveAllRune())
        {
            door.OpenDoor();
        }
        else
        {
            door.CloseDoor();
        }
    }

    bool HaveAllRune()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i].isActive == false) return false;
        }

        return true;
    }
}