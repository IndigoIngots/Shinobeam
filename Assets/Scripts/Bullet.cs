using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;

    void Start()
    {
        Destroy(this.gameObject, 1.2f);
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
    }
}
