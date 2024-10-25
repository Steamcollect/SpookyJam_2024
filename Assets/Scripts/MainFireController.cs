using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFireController : MonoBehaviour
{
    public Fire[] firesReferences;

    public static MainFireController instance;

    public Transform respawnPoint;
    public GameObject player;
    public GameObject cam;

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

    public void TpPlayer()
    {
        StartCoroutine(TeleportPlayer());
    }

    public IEnumerator TeleportPlayer()
    {
        PlayerController.instance.FreezMovement(true);
        yield return new WaitForSeconds(.4f);

        FadePanel.instance.FadeOut();

        yield return new WaitForSeconds(1);

        player.transform.position = respawnPoint.position;
        cam.transform.position = respawnPoint.position + Vector3.back * 10;

        FadePanel.instance.FadeIn();

        yield return new WaitForSeconds(.3f);
        PlayerController.instance.FreezMovement(false);
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