using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeNinja : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        //DelayMethod��3.5�b��ɌĂяo���A�ȍ~�͂P�b���Ɏ��s
        InvokeRepeating(nameof(DelayMethod), 10f, 10f);
    }

    void DelayMethod()
    {
        animator.SetTrigger("idle");
    }
}
