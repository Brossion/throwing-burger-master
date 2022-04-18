using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScript : MonoBehaviour
{
    public float scoreIncrease, score, kofteMiktari = 0, marulMiktari = 0, peynirMiktari = 0;

    float currentTime = 0f;

    [SerializeField] 
    Text countDownText;

    [SerializeField]
    float startingTime = 15f;

    public GameObject[] particleSystems;

    public GameObject meatball,lettuce, cheese;

    public GameObject startPanel, tryAgainPanel, countDownT;

    public GameObject[] gamePanels, images, burgers, breads;

    public Camera[] cameras;

    public Animator[] animators;

    public GameObject uIManager, secondBurger, thirdBurger;

    public bool gameOver, isFirstFinished, isSecondFinished, isTutOver;

    public Button[] buttons;

    ScoreScriptLv1 scoreManager;
    SecondBurger sB;
    ThirdBurger tB;
    UIManager uiManager;
    Tutorial tutorial;
    BurgerInstantiate burgerIns;
    CheeseInstantiate cheeseIns;
    void Start()
    {
        isTutOver = false;
        tutorial = FindObjectOfType<Tutorial>();
        scoreManager = FindObjectOfType<ScoreScriptLv1>();
        gameOver = false;
        uiManager = uIManager.GetComponent<UIManager>();
        tB = thirdBurger.GetComponent<ThirdBurger>();
        sB = secondBurger.GetComponent<SecondBurger>();
        burgerIns = FindObjectOfType<BurgerInstantiate>();
        cheeseIns = FindObjectOfType<CheeseInstantiate>();
        Time.timeScale = 0;
        if (uiManager.isGameStarted == false)
        {
            startPanel.SetActive(true);
        }
        score = 0;
        isFirstFinished = true;
        isSecondFinished = true;
    }
    private void Update()
    {
        Timer();
    }
    public void StartGame()
    {
        tutorial.tutorial[0].SetActive(true);
        buttons[1].interactable = false;
        buttons[2].interactable = false;
        Time.timeScale = 1;
        startPanel.SetActive(false);
        gamePanels[0].SetActive(true);
        uiManager.isGameStarted = true;
        images[0].SetActive(true);
        isFirstFinished = false;
        particleSystems[0].SetActive(true);
        currentTime = startingTime;
        countDownT.SetActive(true);
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
        
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "kofte")
        {
            kofteMiktari += 1;
            if (kofteMiktari == 1)
            {
                uiManager.isBad = false;
                score += scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
            }
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            AllButtonsUp();
            NextBTN();

        }
        if (other.gameObject.tag == "marul")
        {
            marulMiktari += 1;
            if (marulMiktari == 1)
            {
                uiManager.isBad = false;
                if (score > 0)
                {
                    score -= scoreIncrease;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
            }
            lettuce.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            NextBTN();
        }
        if (other.gameObject.tag == "peynir")
        {
            peynirMiktari += 1;
            if (peynirMiktari == 1)
            {
                uiManager.isBad = false;
                if (score > 0)
                {
                    score -= scoreIncrease;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
            }
            Destroy(other.gameObject);
            cheese.SetActive(true);
            uiManager.canTouch = false;
            print(score);
            NextBTN();
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
        isFirstFinished = true;
        isSecondFinished = false;
        animators[3].SetBool("isFinished", true);
        tutorial.tutorial[0].SetActive(true);
        images[0].SetActive(false);
        images[1].SetActive(true);
        burgers[1].SetActive(true);
        buttons[1].interactable = false;
        buttons[2].interactable = false;
        particleSystems[1].SetActive(true);
        currentTime = startingTime;
    }
    /*public void NextBTN1()
    {
        animators[4].SetBool("isFinished", true);
        images[1].SetActive(false);
        images[2].SetActive(true);
        burgers[2].SetActive(true);
    }*/
    public void NextBTN1()
    {
        countDownT.SetActive(false);
        isSecondFinished = true;
        images[1].SetActive(false);
        animators[4].SetBool("isFinished", true);
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        isTutOver = true;
        //animators[5].SetBool("isFinished", true);
        ClosingAllPanels();
        StartCoroutine(scoreManager.Next());
    }
    public void ClosingAllPanels()
    {
        gamePanels[0].SetActive(false);
    }
    public void AllButtonsUp() 
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
