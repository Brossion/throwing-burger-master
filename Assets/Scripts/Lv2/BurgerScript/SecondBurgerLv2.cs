using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBurgerLv2 : MonoBehaviour
{
    public float scoreIncrease, peynirMik = 0, kofteMiktari = 0, marulMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, cheese, lettuce;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScriptLv2;
    UIManager uiManager;
    GeneralScriptLv2 gSLv2;
    private void Start()
    {
        comingIngAmount = 2;
        uiManager = FindObjectOfType<UIManager>();
        gSLv2 = generalScriptLv2.GetComponent<GeneralScriptLv2>();
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
            if (gSLv2.isSecondFinished == false)
            {
                gSLv2.particleSystems[0].SetActive(false);
            }
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(kofteMiktari);
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
            if (gSLv2.isSecondFinished == false)
            {
                gSLv2.particleSystems[2].SetActive(false);
            }
            cheese.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(peynirMik);
            Next();
        }
        if (other.gameObject.tag == "marul")
        {
            comingIngAmount -= 1;
            marulMik += 1;
            if (marulMik <= 1)
            {
                uiManager.isBad = false;
                score -= scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                gSLv2.ClosingAllPanels();
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
        gSLv2.ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    void Next()
    {
        if (comingIngAmount == 0)
        {
            gSLv2.NextBTN1();
        }
    }
}
