using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFireController : MonoBehaviour
{
    public Fire[] firesReferences;

    public static MainFireController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < firesReferences.Length; i++)
        {
            ActiveFire(i, firesReferences[i].isActive);
        }
    }

    public void ActiveFire(int id, bool active)
    {
        firesReferences[id].SetActiveFire(active);
    }

    public bool HaveFoundEveryFire()
    {
        for (int i = 0; i < firesReferences.Length; i++)
        {
            if (firesReferences[i].isActive == false) return false;
        }

        return true;
    }
}

[System.Serializable]
public class Fire
{
    public GameObject fireReference, runeReference;
    public bool isActive;

    public void SetActiveFire(bool active)
    {
        fireReference.SetActive(active);
        runeReference.SetActive(active);
        isActive = active;
    }
}