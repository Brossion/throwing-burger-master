using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScriptLv7 : MonoBehaviour
{
    public float score, tursuP, kofteP, peynirP, domatesP;

    private float comingIngAmount, kofteMiktari = 0, tursuMik = 0, peynirMiktari = 0, domatesMik = 0;

    float currentTime = 0f;

    [SerializeField]
    Text countDownText;

    [SerializeField]
    float startingTime = 20f;

    public GameObject meatball, pickle, cheese, tomato;
    public GameObject tryAgainPanel, startPanel, countDownT;

    public GameObject[] gamePanels, images, burgers;
    public Camera[] cameras;

    public Animator[] animators;

    public GameObject uIManager;

    UIManager uiManager;
    ScoreScriptLv7 scoreManager;

    public bool gameOver;

    private bool isFirstFinished, isSecondFinished, isThirdFinished, isFourthFinished;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreScriptLv7>();
        comingIngAmount = 4;
        gameOver = false;
        uiManager = uIManager.GetComponent<UIManager>();
        Time.timeScale = 0;
        startPanel.SetActive(true);
        score = 0;
        isFirstFinished = true;
        isSecondFinished = true;
        isThirdFinished = true;
        isFourthFinished = true;
    }
    private void Update()
    {
        Timer();
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanels[0].SetActive(true);
        Time.timeScale = 1;
        uiManager.isGameStarted = true;
        images[0].SetActive(true);
        isFirstFinished = false;
        countDownT.SetActive(true);
        currentTime = startingTime;
    }
    void Timer()
    {
        if (isFirstFinished == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 5)
            {
                countDownText.color = Color.red;
            }
            else
            {
                countDownText.color = Color.white;
            }
            if (currentTime <= 0)
            {
                currentTime -= 0 * Time.deltaTime;
                NextBTN();
            }
        }
        if (isSecondFinished == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 5)
            {
                countDownText.color = Color.red;
            }
            else
            {
                countDownText.color = Color.white;
            }
            if (currentTime <= 0)
            {
                currentTime -= 0 * Time.deltaTime;
                NextBTN1();
            }
        }
        if (isThirdFinished == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 5)
            {
                countDownText.color = Color.red;
            }
            else
            {
                countDownText.color = Color.white;
            }
            if (currentTime <= 0)
            {
                currentTime -= 0 * Time.deltaTime;
                NextBTN2();
            }
        }
        if (isFourthFinished == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 5)
            {
                countDownText.color = Color.red;
            }
            else
            {
                countDownText.color = Color.white;
            }
            if (currentTime <= 0)
            {
                currentTime -= 0 * Time.deltaTime;
                NextBTN3();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kofte")
        {
            comingIngAmount -= 1;
            kofteMiktari += 1;
            if (kofteMiktari <= 1)
            {
                uiManager.isBad = false;
                score += kofteP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
            }
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Nexting();
        }
        if (other.gameObject.tag == "peynir")
        {
            comingIngAmount -= 1;
            peynirMiktari += 1;
            if (peynirMiktari <= 1)
            {
                uiManager.isBad = false;
                score += peynirP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
            }
            cheese.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Nexting();
        }
        if (other.gameObject.tag == "tursu")
        {
            comingIngAmount -= 1;
            tursuMik += 1;
            if (tursuMik <= 1)
            {
                uiManager.isBad = false;
                score += tursuP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
            }
            pickle.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Nexting();
        }
        if (other.gameObject.tag == "domates")
        {
            comingIngAmount -= 1;
            domatesMik += 1;
            if (domatesMik <= 1)
            {
                uiManager.isBad = false;
                score += domatesP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
                ClosingAllPanels();
            }
            tomato.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Nexting();
        }
    }
    public void NextBTN()
    {
        animators[4].SetBool("isFinished", true);
        images[0].SetActive(false);
        images[1].SetActive(true);
        burgers[1].SetActive(true);
        isFirstFinished = true;
        isSecondFinished = false;
        currentTime = startingTime;
        ShurikenScriptLv7.remainedHeart = 3;
    }
    public void NextBTN1()
    {
        animators[5].SetBool("isFinished", true);
        images[1].SetActive(false);
        images[2].SetActive(true);
        burgers[2].SetActive(true);
        isSecondFinished = true;
        isThirdFinished = false;
        currentTime = startingTime;
        ShurikenScriptLv7.remainedHeart = 3;
    }
    public void NextBTN2()
    {
        animators[6].SetBool("isFinished", true);
        images[2].SetActive(false);
        images[3].SetActive(true);
        burgers[3].SetActive(true);
        isThirdFinished = true;
        isFourthFinished = false;
        currentTime = startingTime;
        ShurikenScriptLv7.remainedHeart = 3;
    }
    public void NextBTN3()
    {
        images[3].SetActive(false);
        animators[7].SetBool("isFinished", true);
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        ClosingAllPanels();
        StartCoroutine(scoreManager.Next());
        isFourthFinished = true;
        countDownT.SetActive(false);
    }
    public void ClosingAllPanels()
    {
        gamePanels[0].SetActive(false);
    }
    void Nexting()
    {
        if (comingIngAmount == 0)
        {
            NextBTN();
        }
    }
}
