using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickleBurger : MonoBehaviour
{
    public float kofteP, peynirP, tursuP, domatesP, peynirMik = 0, kofteMiktari = 0, tursuMik = 0, domatesMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, cheese, pickle, tomato;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScriptLv4;

    GeneralScriptLv4 gSLv4;
    UIManager uiManager;

    void Start()
    {
        comingIngAmount = 4;
        gSLv4 = generalScriptLv4.GetComponent<GeneralScriptLv4>();
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
                gSLv4.ClosingAllPanels();
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
                gSLv4.ClosingAllPanels();
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
                score += tursuP;
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(TryAgain());
                gSLv4.ClosingAllPanels();
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
                gSLv4.ClosingAllPanels();
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
        gSLv4.ClosingAllPanels();
        tryAgainPanel.SetActive(true);
    }
    void Next()
    {
        if (comingIngAmount == 0)
        {
            gSLv4.NextBTN3();
        }
    }
}
