using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HomeManager : MonoBehaviour
{
    [SerializeField] Image Panel;
    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    [SerializeField] AudioSource BGM;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    public void pushStart()
    {
        audioSource.PlayOneShot(sound);
        FadeBGM();
        Panel.gameObject.SetActive(true);
        Invoke("ChangeScene", 2.0f);
        Panel.DOFade(
            1f,
            1.75f
            );
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void FadeBGM()
    {
        BGM.DOFade(0f, 1f);
    }
}
