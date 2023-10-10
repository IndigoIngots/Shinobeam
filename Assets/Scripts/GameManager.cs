using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using NCMB;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text Num3;
    [SerializeField] Text Num2;
    [SerializeField] Text Num1;
    [SerializeField] Text Num0;

    bool isResult = false;
    [SerializeField] GameObject ResultUIs;
    [SerializeField] Text ResultScore;
    [SerializeField] Text HighScore;
    int highscore;
    [SerializeField] GameObject ScoreImage;

    [SerializeField] Image Panel;
    [SerializeField] GameObject UIs;
    [SerializeField] Text Score;
    int scoreInt;
    [SerializeField] GameObject Hearts;
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;

    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject CameraVs;
    [SerializeField] GameObject CameraV0;
    [SerializeField] GameObject CameraV1;
    [SerializeField] GameObject CameraV2;
    [SerializeField] GameObject CameraV3;

    AudioSource audioSource;
    [SerializeField] AudioSource BGM;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isResult == true)
        {
            BGM.DOFade(0f, 1f);
            Panel.DOFade(
            1f,
            1f
            );

            Invoke("GoHome", 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.R) && isResult == true)
        {
            BGM.DOFade(0f, 1f);
            Panel.DOFade(
            1f,
            1f
            );

            Invoke("GoRetry", 2.0f);
        }
    }

    void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

    void GoRetry()
    {
        SceneManager.LoadScene("Main");
    }

    public void OVER()
    {
        ScoreImage.transform.DOMoveX(-240f, 0.5f);
        isResult = true;
        ResultUIs.SetActive(true);
        ResultUIs.transform.DOScale(new Vector3(0, 0, 0), 0f);
        ResultUIs.transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        if (scoreInt > highscore)
        {
            PlayerPrefs.SetInt("SCORE", scoreInt);
            highscore = scoreInt;
        }
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(0);
        ResultScore.text = scoreInt.ToString("D6");
        HighScore.text = "ç≈çÇÅF" + highscore.ToString("D6");
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        highscore = PlayerPrefs.GetInt("SCORE", 0);

        Panel.gameObject.SetActive(true);
        Panel.DOFade(
            1f,
            0
            );

        Panel.DOFade(
            0f,
            1.75f
            );

        Invoke("Count3", 1.0f);
        Invoke("Count2", 2.0f);
        Invoke("Count1", 3.0f);
        Invoke("Count0", 3.8f);
    }

    public void GetScore(int Point)
    {
        scoreInt += Point;
        Score.text = scoreInt.ToString("D6");
    }

    public void Life3()
    {
        Heart3.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void Life2()
    {
        Heart3.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Heart2.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void Life1()
    {
        Heart2.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Heart1.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void Life0()
    {
        Heart1.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        OVER();
    }

    public void Count3()
    {
        Num3.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuart);
        Num3.DOFade(
        0f,
        1.5f
        );
    }

    public void Count2()
    {
        Num2.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuart);
        Num2.DOFade(
        0f,
        1.5f
        );
        CameraV1.SetActive(false);
        CameraV2.SetActive(true);
    }

    public void Count1()
    {
        Num1.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuart);
        Num1.DOFade(
        0f,
        1.5f
        );
        CameraV2.SetActive(false);
        CameraV3.SetActive(true);
    }

    public void Count0()
    {
        Num0.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutQuart);
        Num0.DOFade(
        0f,
        1f
        );
        Camera1.SetActive(true);
        CameraVs.SetActive(false);

        UIs.SetActive(true);

        ScoreImage.transform.DOMoveX(-240f, 0.5f).From();
        Hearts.transform.DOMoveX(2160f, 0.5f).From();
    }
}
