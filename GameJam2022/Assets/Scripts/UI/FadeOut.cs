using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    [SerializeField] Animator animator;
    private void Awake()
    {
        animator.SetTrigger("Fade");
    }

}
