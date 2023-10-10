using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    GameObject Obj;
    GameObject SE;
    [SerializeField] GameObject Bullet;
    int ShotTimer;

    [SerializeField] GameObject Effect;

    [SerializeField] Animator animator;

    void Start()
    {
        Obj = GameObject.Find("GameManager");
        SE = GameObject.Find("SEManager");
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            Obj.GetComponent<GameManager>().GetScore(200);
            SE.GetComponent<SEManager>().Damaged();

            Instantiate(Effect, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        ShotTimer += 1;
        if (ShotTimer % 30 == 0)
        {
            Shot();
        }
    }

    void Shot()
    {
        Transform myTransform = this.transform;
        Vector3 shotPos = myTransform.position;
        shotPos.y = shotPos.y + 1.5f;
        shotPos.z = shotPos.z - 1.5f;

        Instantiate(Bullet, shotPos, Quaternion.identity);
    }
}
