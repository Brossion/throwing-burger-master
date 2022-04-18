using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScriptLv3 : MonoBehaviour
{
    public float score, kofteMiktari = 0, marulMiktari = 0, peynirMiktari = 0,domatesMik = 0, marulP, kofteP, peynirP, domatesP;

    private float comingIngAmount;

    float currentTime = 0f;

    [SerializeField]
    Text countDownText;

    [SerializeField]
    float startingTime = 20f;

    public GameObject meatball, lettuce, cheese, tomato;

    public GameObject[] particleSystems;

    public GameObject tryAgainPanel, startPanel, countDownT;

    public GameObject[] gamePanels, images, burgers;

    public Camera[] cameras;

    public Animator[] animators;

    public GameObject tBurger, uIManager;

    ThirdBurgerLv3 tB;

    UIManager uiManager;
    ScoreScriptLv3 scoreManager;

    public bool gameOver, isFirstFinished, isSecondFinished, isThirdFinished;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreScriptLv3>();
        comingIngAmount = 2;
        gameOver = false;
        uiManager = uIManager.GetComponent<UIManager>();
        tB = tBurger.GetComponent<ThirdBurgerLv3>();
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
    public void Wrapper()
    {
        StartCoroutine(scoreManager.Next());
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanels[0].SetActive(true);
        Time.timeScale = 1;
        uiManager.isGameStarted = true;
        images[1].SetActive(true);
        particleSystems[0].SetActive(true);
        particleSystems[1].SetActive(true);
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
            if (kofteMiktari <= 1)
            {
                uiManager.isBad = false;
                score += kofteP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
            }
            if (isFirstFinished == false)
            {
                particleSystems[0].SetActive(false);
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
                if (score > 0)
                {
                    score += peynirP;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
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
                StartCoroutine(TryAgain());
            }
            if (isFirstFinished == false)
            {
                particleSystems[1].SetActive(false);
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
                if (score>0)
                {
                    score += domatesP;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                ClosingAllPanels();
            }
            tomato.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Nexting();
        }
    }
    public IEnumerator TryAgain()
    {
        uiManager.isGameStarted = false;
        yield return new WaitForSeconds(0.1f);
        ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    public void NextBTN()
    {
        animators[3].SetBool("isFinished", true);
        images[1].SetActive(false);
        images[2].SetActive(true);
        burgers[2].SetActive(true);
        particleSystems[0].SetActive(true);
        particleSystems[1].SetActive(true);
        particleSystems[2].SetActive(true);
        particleSystems[3].SetActive(true);
        isFirstFinished = true;
        isSecondFinished = false;
        currentTime = startingTime;
    }
    public void NextBTN1()
    {
        animators[5].SetBool("isFinished", true);
        images[2].SetActive(false);
        images[3].SetActive(true);
        burgers[3].SetActive(true);
        particleSystems[0].SetActive(true);
        particleSystems[1].SetActive(true);
        particleSystems[2].SetActive(true);
        isSecondFinished = true;
        isThirdFinished = false;
        currentTime = startingTime;
    }
    public void NextBTN2()
    {
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        images[3].SetActive(false);
        animators[6].SetBool("isFinished", true);
        ClosingAllPanels();
        Wrapper();
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
