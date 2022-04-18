using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBurger : MonoBehaviour
{
    public float scoreIncrease, kofteMiktari = 0, marulMik = 0, peynirMik = 0;

    public float score, comingIngAmount;

    public GameObject meatball, lettuce,cheese;
    public GameObject finishPanel, tryAgainPanel, panel;

    public GameObject[] gamePanels;

    public GameObject generalScript;

    UIManager uiManager; 
    GeneralScript gS;

    private void Start()
    {
        comingIngAmount = 3;
        uiManager = FindObjectOfType<UIManager>();
        gS = generalScript.GetComponent<GeneralScript>();
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
            meatball.SetActive(true);
            Destroy(other.gameObject);
            uiManager.canTouch = false;
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
                score += scoreIncrease;
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
                score += scoreIncrease;
            }
            else
            {
                uiManager.isBad = true;
                gS.ClosingAllPanels();
                StartCoroutine(TryAgain());
            }
            cheese.SetActive(true);
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
