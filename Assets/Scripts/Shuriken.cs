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
        // transform‚ğæ“¾
        Transform myTransform = this.transform;

        // À•W‚ğæ“¾
        Vector3 pos = myTransform.position;
        pos.z += Speed * Time.deltaTime;    // zÀ•W‚Ö0.01‰ÁZ

        myTransform.position = pos;  // À•W‚ğİ’è

        Transform ModelTransform = ShurikenModel.transform;

        ModelTransform.Rotate(0, RotSpeed, 0);
    }
}
