using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //Vector3�^��ϐ�vector�Ő錾���܂��B
    Vector3 vector;

    //GameObject�^��ϐ�Target�Ő錾���܂��B
    [SerializeField] GameObject target;
    //float�^��ϐ�followSpeed�Ő錾���܂��B
    [SerializeField] float followSpeed;

    void Start()
    {
        //�ʒu��Target�̈ʒu�����ɐݒ肷���B
        vector = target.transform.position - transform.position;
    }


    void Update()
    {
        if (target != null)
        { 
            //�ʒu���擾���ăX�s�[�h�����킹�Ă�����B
            transform.position = Vector3.Lerp(
                transform.position,
                target.transform.position - vector,
                Time.deltaTime * followSpeed);
        }
    }
}