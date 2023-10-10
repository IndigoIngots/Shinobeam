using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpowner : MonoBehaviour
{
    [SerializeField] GameObject[] Obj;

    // Start is called before the first frame update
    void Start()
    {
        int Num = Random.Range(0, Obj.Length);
        GameObject obj = transform.parent.gameObject;
        Vector3 shotPos = transform.position;
        float n = Random.Range(-8.0f, 8.0f);
        shotPos.z += n;
        Instantiate(Obj[Num], shotPos, Quaternion.identity, obj.transform);
    }

}
