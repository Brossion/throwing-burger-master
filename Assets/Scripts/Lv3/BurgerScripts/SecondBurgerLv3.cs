using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBurgerLv3 : MonoBehaviour
{
    public float kofteP, peynirP, marulP, domatesP, peynirMik = 0, kofteMiktari = 0, marulMik = 0, domatesMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, cheese, lettuce, tomato;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScriptLv3;

    GeneralScriptLv3 gSLv3;
    UIManager uiManager;

    void Start()
    {
        comingIngAmount = 4;
        gSLv3 = generalScriptLv3.GetComponent<GeneralScriptLv3>();
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
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
                gSLv3.ClosingAllPanels();
            }
            if (gSLv3.isSecondFinished == false)
            {
                gSLv3.particleSystems[0].SetActive(false);
            }
            meatball.SetActive(true);
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
                gSLv3.ClosingAllPanels();
            }
            if (gSLv3.isSecondFinished == false)
            {
                gSLv3.particleSystems[2].SetActive(false);
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
                score += marulP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                gSLv3.ClosingAllPanels();
            }
            if (gSLv3.isSecondFinished == false)
            {
                gSLv3.particleSystems[1].SetActive(false);
            }
            lettuce.SetActive(true);
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
                gSLv3.ClosingAllPanels();
            }
            if (gSLv3.isSecondFinished == false)
            {
                gSLv3.particleSystems[3].SetActive(false);
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
        gSLv3.ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    void Next() 
    {
        if (comingIngAmount == 0)
        {
            gSLv3.NextBTN1();
        }
    }
}
