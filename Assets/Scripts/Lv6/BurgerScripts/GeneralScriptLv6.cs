using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScriptLv6 : MonoBehaviour
{
    public float score, kofteMiktari = 0, marulMiktari = 0, peynirMiktari = 0, domatesMik = 0, marulP, kofteP, peynirP, domatesP;

    private float comingIngAmount;

    float currentTime = 0f;

    [SerializeField]
    Text countDownText;

    [SerializeField]
    float startingTime = 20f;

    public GameObject meatball, meatball2, lettuce, cheese, tomato;
    public GameObject startPanel, countDownT;

    public GameObject[] gamePanels, images, burgers;
    public Camera[] cameras;

    public Animator[] animators;

    public GameObject uIManager;


    UIManager uiManager;
    ScoreScriptLv6 scoreManager;
    ShurikenScriptLv6 shurikenScript;

    public bool gameOver;

    private bool isFirstFinished, isSecondFinished, isThirdFinished;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreScriptLv6>();
        comingIngAmount = 5;
        gameOver = false;
        uiManager = uIManager.GetComponent<UIManager>();
        shurikenScript = FindObjectOfType<ShurikenScriptLv6>();
        Time.timeScale = 0;
        startPanel.SetActive(true);
        score = 0;
        isFirstFinished = true;
        isSecondFinished = true;
        isThirdFinished = true;
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kofte")
        {
            comingIngAmount -= 1;
            kofteMiktari += 1;
            if (kofteMiktari <= 2)
            {
                uiManager.isBad = false;
                score += kofteP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
            }
            if (kofteMiktari == 1)
            {
                meatball.SetActive(true);
            }
            if (kofteMiktari == 2)
            {
                meatball2.SetActive(true);
            }
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
        if (other.gameObject.tag == "marul")
        {
            comingIngAmount -= 1;
            marulMiktari += 1;
            if (marulMiktari <= 1)
            {
                uiManager.isBad = false;
                score += marulP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
            }
            lettuce.SetActive(true);
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
        animators[0].SetBool("isFinished", true);
        images[0].SetActive(false);
        images[1].SetActive(true);
        burgers[1].SetActive(true);
        isFirstFinished = true;
        isSecondFinished = false;
        currentTime = startingTime;
        ShurikenScriptLv6.remainedHeart = 3;
    }
    public void NextBTN1()
    {
        animators[1].SetBool("isFinished", true);
        images[1].SetActive(false);
        images[2].SetActive(true);
        burgers[2].SetActive(true);
        isSecondFinished = true;
        isThirdFinished = false;
        currentTime = startingTime;
        ShurikenScriptLv6.remainedHeart = 3;
    }
    public void NextBTN2()
    {
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        images[2].SetActive(false);
        animators[2].SetBool("isFinished", true);
        ClosingAllPanels();
        StartCoroutine(scoreManager.Next());
        isThirdFinished = true;
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
