using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioClip Shu;
    [SerializeField] AudioClip Throw;
    [SerializeField] AudioClip Damage;
    [SerializeField] AudioClip Coin;
    [SerializeField] AudioClip dango;

    [SerializeField] AudioSource Speaker;

    public void Move()
    {
        Speaker.PlayOneShot(Shu);
    }

    public void Throwing()
    {
        Speaker.PlayOneShot(Throw);
    }

    public void Damaged()
    {
        Speaker.PlayOneShot(Damage);
    }

    public void Koban()
    {
        Speaker.PlayOneShot(Coin);
    }

    public void Dango()
    {
        Speaker.PlayOneShot(dango);
    }
}
