using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
    public Animator anim;

    public static FadePanel instance;

    private void Awake()
    {
        instance = this;
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}