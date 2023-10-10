using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeNinja : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        //DelayMethod‚ğ3.5•bŒã‚ÉŒÄ‚Ño‚µAˆÈ~‚Í‚P•b–ˆ‚ÉÀs
        InvokeRepeating(nameof(DelayMethod), 10f, 10f);
    }

    void DelayMethod()
    {
        animator.SetTrigger("idle");
    }
}
