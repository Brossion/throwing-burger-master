using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC2xBurgerRed : MonoBehaviour
{
    public float kofteP, peynirP, tursuP, domatesP, peynirMik = 0, kofteMiktari = 0, tursuMik = 0, domatesMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, meatball2, cheese, pickle, tomato;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScript;

    GeneralScriptLv7 gSLv7;
    UIManager uiManager;

    void Start()
    {
        comingIngAmount = 4;
        gSLv7 = generalScript.GetComponent<GeneralScriptLv7>();
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
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
                StartCoroutine(TryAgain());
                gSLv7.ClosingAllPanels();
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
            print(kofteMiktari);
            print(score);
            Next();
        }
        if (other.gameObject.tag == "peynir")
        {
            comingIngAmount -= 1;
            peynirMik += 1;
            if (peynirMik <= 1)
            {
                uiManager.isBad = false;
                score += peynirP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                gSLv7.ClosingAllPanels();
            }
            cheese.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(peynirMik);
            print(score);
            Next();
        }
        if (other.gameObject.tag == "tursu")
        {
            comingIngAmount -= 1;
            tursuMik += 1;
            if (tursuMik <= 1)
            {
                uiManager.isBad = false;
                if (score > 0)
                {
                    score += tursuP;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                gSLv7.ClosingAllPanels();
            }
            pickle.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Next();
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
                StartCoroutine(TryAgain());
                gSLv7.ClosingAllPanels();
            }
            tomato.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Next();
        }
    }
    public IEnumerator TryAgain()
    {
        uiManager.isGameStarted = false;
        yield return new WaitForSeconds(0.1f);
        gSLv7.ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    void Next()
    {
        if (comingIngAmount == 0)
        {
            gSLv7.NextBTN1();
        }
    }
}
