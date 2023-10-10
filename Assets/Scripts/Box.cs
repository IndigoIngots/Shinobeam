using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject[] item;
    GameObject SE;

    void Start()
    {
        SE = GameObject.Find("SEManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            SE.GetComponent<SEManager>().Damaged();
            int num = Random.Range(0, item.Length);
            Vector3 shotPos = transform.position;
            shotPos.y += 0f;
            Instantiate(item[num], shotPos, Quaternion.identity);


            Destroy(this.gameObject);
        }
    }
}
