using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //Vector3型を変数vectorで宣言します。
    Vector3 vector;

    //GameObject型を変数Targetで宣言します。
    [SerializeField] GameObject target;
    //float型を変数followSpeedで宣言します。
    [SerializeField] float followSpeed;

    void Start()
    {
        //位置をTargetの位置を元に設定するよ。
        vector = target.transform.position - transform.position;
    }


    void Update()
    {
        if (target != null)
        { 
            //位置を取得してスピードも合わせていくよ。
            transform.position = Vector3.Lerp(
                transform.position,
                target.transform.position - vector,
                Time.deltaTime * followSpeed);
        }
    }
}