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
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.z += Speed * Time.deltaTime;    // z座標へ0.01加算

        myTransform.position = pos;  // 座標を設定

        Transform ModelTransform = ShurikenModel.transform;

        ModelTransform.Rotate(0, RotSpeed, 0);
    }
}
