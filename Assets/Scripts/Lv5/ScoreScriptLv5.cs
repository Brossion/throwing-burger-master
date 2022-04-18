using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptLv5 : MonoBehaviour
{
    public float totalScore;

    public GameObject finishPanel, tryAgainPanel, welldonePS;

    public GameObject[] stars, likeDislikes, mouthTypes, browTypes, dollar, moneyAmount, wDTexts;

    public Animator[] animators;

    public int money, endMoney, growthRate;

    public Text endM;

    public GameObject uIManager, secondBurger, thirdBurger, gS;

    DoubleMeatBurger sB;
    CheeseBurgerG tB;
    UIManager uiManager;
    GeneralScriptLv5 generalScript;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = uIManager.GetComponent<UIManager>();
        tB = thirdBurger.GetComponent<CheeseBurgerG>();
        sB = secondBurger.GetComponent<DoubleMeatBurger>();
        generalScript = gS.GetComponent<GeneralScriptLv5>();
    }

    // Update is called once per frame
    void Update()
    {
        if (generalScript.gameOver == true)
        {
            endM.text = endMoney.ToString("0");
            GameOver();
        }
    }
    public void GameOver()
    {
        if (endMoney != money && money > endMoney)
        {
            endMoney += growthRate;
        }
    }
    public IEnumerator Next()
    {
        Debug.Log("Next is happening!");
        yield return new WaitForSeconds(1.0f);
        if (generalScript.score < 30)
        {
            uiManager.isGameStarted = false;
            mouthTypes[3].SetActive(true);
            browTypes[3].SetActive(true);
            mouthTypes[6].SetActive(false);
            browTypes[6].SetActive(false);
            animators[0].SetBool("isMad", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[1].SetActive(true);
            dollar[0].SetActive(true);
            moneyAmount[3].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[0].SetActive(false);
            moneyAmount[3].SetActive(false);
            uiManager.isGameStarted = true;
            money += 0;
        }
        else if (generalScript.score == 30)
        {
            uiManager.isGameStarted = false;
            mouthTypes[0].SetActive(true);
            browTypes[0].SetActive(true);
            mouthTypes[6].SetActive(false);
            browTypes[6].SetActive(false);
            animators[0].SetBool("isHappy", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[0].SetActive(true);
            dollar[0].SetActive(true);
            moneyAmount[0].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[0].SetActive(false);
            moneyAmount[0].SetActive(false);
            uiManager.isGameStarted = true;
            money += 25;
            print(money);
        }
        if (sB.score < 50)
        {
            uiManager.isGameStarted = false;
            mouthTypes[4].SetActive(true);
            browTypes[4].SetActive(true);
            mouthTypes[7].SetActive(false);
            browTypes[7].SetActive(false);
            animators[1].SetBool("isMad", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[3].SetActive(true);
            dollar[1].SetActive(true);
            moneyAmount[4].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[1].SetActive(false);
            moneyAmount[4].SetActive(false);
            uiManager.isGameStarted = true;
            money += 0;
        }
        else if (sB.score == 50)
        {
            uiManager.isGameStarted = false;
            mouthTypes[1].SetActive(true);
            browTypes[1].SetActive(true);
            mouthTypes[7].SetActive(false);
            browTypes[7].SetActive(false);
            animators[1].SetBool("isHappy", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[2].SetActive(true);
            dollar[1].SetActive(true);
            moneyAmount[1].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[1].SetActive(false);
            moneyAmount[1].SetActive(false);
            uiManager.isGameStarted = true;
            money += 50;
            print(money);
        }
        if (tB.score < 20)
        {
            uiManager.isGameStarted = false;
            mouthTypes[5].SetActive(true);
            browTypes[5].SetActive(true);
            mouthTypes[8].SetActive(false);
            browTypes[8].SetActive(false);
            animators[2].SetBool("isMad", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[5].SetActive(true);
            dollar[2].SetActive(true);
            moneyAmount[5].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[2].SetActive(false);
            moneyAmount[5].SetActive(false);
            uiManager.isGameStarted = true;
            money += 0;
        }
        else if (tB.score == 20)
        {
            uiManager.isGameStarted = false;
            mouthTypes[2].SetActive(true);
            browTypes[2].SetActive(true);
            mouthTypes[8].SetActive(false);
            browTypes[8].SetActive(false);
            animators[2].SetBool("isHappy", true);
            yield return new WaitForSeconds(0.3f);
            likeDislikes[4].SetActive(true);
            dollar[2].SetActive(true);
            moneyAmount[2].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            dollar[2].SetActive(false);
            moneyAmount[2].SetActive(false);
            uiManager.isGameStarted = true;
            money += 15;
            print(money);
        }
        yield return new WaitForSeconds(0.5f);
        likeDislikes[0].SetActive(false);
        likeDislikes[1].SetActive(false);
        likeDislikes[2].SetActive(false);
        likeDislikes[3].SetActive(false);
        likeDislikes[4].SetActive(false);
        likeDislikes[5].SetActive(false);
        totalScore = generalScript.score + tB.score + sB.score;
        if (totalScore < 33)
        {
            Debug.Log("Try again!");
            yield return new WaitForSeconds(0.3f);
            tryAgainPanel.SetActive(true);
            generalScript.gameOver = true;
            uiManager.isGameStarted = true;
        }
        else if (totalScore >= 33 && totalScore < 66)
        {
            Debug.Log("1 Star!");
            uiManager.isGameStarted = false;
            yield return new WaitForSeconds(0.3f);
            finishPanel.SetActive(true);
            wDTexts[0].SetActive(false);
            wDTexts[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            generalScript.gameOver = true;
            stars[0].SetActive(true);
            uiManager.isGameStarted = true;

        }
        else if (totalScore >= 66 && totalScore < 100)
        {
            Debug.Log("2 Stars!");
            uiManager.isGameStarted = false;
            yield return new WaitForSeconds(0.3f);
            finishPanel.SetActive(true);
            wDTexts[0].SetActive(false);
            wDTexts[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            generalScript.gameOver = true;
            stars[0].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            stars[1].SetActive(true);
            uiManager.isGameStarted = true;
        }
        else if (totalScore == 100)
        {
            Debug.Log("3 Stars!");
            uiManager.isGameStarted = false;
            yield return new WaitForSeconds(0.3f);
            finishPanel.SetActive(true);
            wDTexts[0].SetActive(true);
            wDTexts[1].SetActive(false);
            yield return new WaitForSeconds(0.3f);
            generalScript.gameOver = true;
            stars[0].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            stars[2].SetActive(true);
            welldonePS.SetActive(true);
            uiManager.isGameStarted = true;
        }
    }
}
