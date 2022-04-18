using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCBurgerBlue : MonoBehaviour
{
    public float kofteP, peynirP, marulP, domatesP;

    public float score;

    private float comingIngAmount, peynirMik = 0, kofteMiktari = 0, marulMik = 0, domatesMik = 0;

    public GameObject meatball, cheese, lettuce, tomato;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject generalScript;

    GeneralScriptLv6 gSLv6;
    UIManager uiManager;

    void Start()
    {
        comingIngAmount = 3;
        gSLv6 = generalScript.GetComponent<GeneralScriptLv6>();
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
                StartCoroutine(uiManager.TryAgain());
                gSLv6.ClosingAllPanels();
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
                StartCoroutine(uiManager.TryAgain());
                gSLv6.ClosingAllPanels();
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
                    score += marulP;
                }
            }
            else
            {
                uiManager.isBad = true;
                StartCoroutine(uiManager.TryAgain());
                gSLv6.ClosingAllPanels();
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
                StartCoroutine(uiManager.TryAgain());
                gSLv6.ClosingAllPanels();
            }
            tomato.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
            print(score);
            Next();
        }
    }
    void Next()
    {
        if (comingIngAmount == 0)
        {
            gSLv6.NextBTN2();
        }
    }
}
