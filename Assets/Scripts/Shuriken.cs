using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float RotSpeed;
    [SerializeField] GameObject ShurikenModel;

    void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // transform���擾
        Transform myTransform = this.transform;

        // ���W���擾
        Vector3 pos = myTransform.position;
        pos.z += Speed * Time.deltaTime;    // z���W��0.01���Z

        myTransform.position = pos;  // ���W��ݒ�

        Transform ModelTransform = ShurikenModel.transform;

        ModelTransform.Rotate(0, RotSpeed, 0);
    }
}
