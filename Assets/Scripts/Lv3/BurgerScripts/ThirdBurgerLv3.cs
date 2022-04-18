using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBurgerLv3 : MonoBehaviour
{
    public float scoreIncrease, kofteMiktari = 0, marulMik = 0, peynirMik = 0, domatesMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, lettuce, cheese, tomato;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScriptLv3;

    UIManager uiManager;
    GeneralScriptLv3 gSLv2;

    private void Start()
    {
        comingIngAmount = 3;
        uiManager = FindObjectOfType<UIManager>();
        gSLv2 = generalScriptLv3.GetComponent<GeneralScriptLv3>();
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
                gSLv2.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            if (gSLv2.isThirdFinished == false)
            {
                gSLv2.particleSystems[0].SetActive(false);
            }
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            Next();
        }
        if (other.gameObject.tag == "marul")
        {
            comingIngAmount -= 1;
            marulMik += 1;
            if (marulMik <= 1)
            {
                uiManager.isBad = false;
                score += scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                gSLv2.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            if (gSLv2.isThirdFinished == false)
            {
                gSLv2.particleSystems[1].SetActive(false);
            }
            lettuce.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            Next();
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
                gSLv2.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            if (gSLv2.isThirdFinished == false)
            {
                gSLv2.particleSystems[1].SetActive(false);
            }
            cheese.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            Next();
        }
        if (other.gameObject.tag == "domates")
        {
            comingIngAmount -= 1;
            domatesMik += 1;
            if (domatesMik <= 1)
            {
                uiManager.isBad = false;
                score -= scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                gSLv2.ClosingAllPanels();
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
        gSLv2.ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    void Next()
    {
        if (comingIngAmount == 0)
        {
            gSLv2.NextBTN2();
        }
    }
}
