using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBurger : MonoBehaviour
{
    public float scoreIncrease, peynirMik = 0, kofteMiktari = 0, marulMik = 0;

    public float score;

    public int comingIngAmount;

    public GameObject meatball, cheese, lettuce;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject[] gamePanels;

    public GameObject generalScript;
    UIManager uiManager;
    GeneralScript gS;
    Tutorial tutorial;
    BurgerInstantiate burgerIns;
    CheeseInstantiate cheeseIns;

    private void Start()
    {
        comingIngAmount = 2;
        uiManager = FindObjectOfType<UIManager>();
        gS = generalScript.GetComponent<GeneralScript>();
        burgerIns = FindObjectOfType<BurgerInstantiate>();
        cheeseIns = FindObjectOfType<CheeseInstantiate>();
        tutorial = FindObjectOfType<Tutorial>();
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
                score += scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                gS.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            if (gS.isSecondFinished == false)
            {
                gS.particleSystems[0].SetActive(false);
            }
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(kofteMiktari);
            print(score);
            tutorial.tutorial[1].SetActive(true);
            Next();
            gS.buttons[0].interactable = false;
            gS.buttons[1].interactable = true;
            gS.buttons[2].interactable = false;
        }
        if (other.gameObject.tag == "peynir")
        {
            comingIngAmount -= 1;
            peynirMik += 1;
            if (peynirMik <= 1)
            {
                uiManager.isBad = false;
                score += scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                gS.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            if (gS.isSecondFinished == false)
            {
                gS.particleSystems[1].SetActive(false);
            }
            cheese.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(peynirMik);
            print(score);
            Next();
        }
        if (other.gameObject.tag == "marul")
        {
            comingIngAmount -= 1;
            marulMik += 1;
            if (marulMik <= 1)
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
                gS.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            lettuce.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            Next();
        }
    }
    public IEnumerator TryAgain()
    {
        uiManager.isGameStarted = false;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < gamePanels.Length; i++)
        {
            gamePanels[i].SetActive(false);
        }
        tryAgainPanel.SetActive(true);
    }
    void Next() 
    {
        if (comingIngAmount == 0)
        {
            gS.NextBTN1();
        }
    }
}
