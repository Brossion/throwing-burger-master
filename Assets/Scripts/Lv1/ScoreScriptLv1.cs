using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class ScoreScriptLv1 : MonoBehaviour
{
    public float totalScore;

    public GameObject finishPanel, tryAgainPanel, welldonePS;

    public GameObject[] stars, likeDislikes, mouthTypes, browTypes, dollar, moneyAmount, wDTexts;

    public Animator[] animators;

    public int money, endMoney, growthRate;

    public Text endM;

    public GameObject uIManager, secondBurger, thirdBurger, gS;

    SecondBurger sB;
    ThirdBurger tB;
    UIManager uiManager;
    GeneralScript generalScript;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = uIManager.GetComponent<UIManager>();
        tB = thirdBurger.GetComponent<ThirdBurger>();
        sB = secondBurger.GetComponent<SecondBurger>();
        generalScript = gS.GetComponent<GeneralScript>();
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
        yield return new WaitForSeconds(1);
        if (generalScript.score < 33)
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
            yield return new WaitForSeconds(0.3f);
            dollar[0].SetActive(false);
            moneyAmount[3].SetActive(false);
            uiManager.isGameStarted = true;
            money += 0;
        }
        else if (generalScript.score == 33)
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
            yield return new WaitForSeconds(0.3f);
            dollar[0].SetActive(false);
            moneyAmount[0].SetActive(false);
            uiManager.isGameStarted = true;
            money += 10;
            print(money);
        }
        if (sB.score < 34)
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
            yield return new WaitForSeconds(0.3f);
            dollar[1].SetActive(false);
            moneyAmount[4].SetActive(false);
            uiManager.isGameStarted = true;
            money += 0;
        }
        else if (sB.score == 34)
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
            yield return new WaitForSeconds(0.3f);
            dollar[1].SetActive(false);
            moneyAmount[1].SetActive(false);
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
        else if (totalScore >= 33 && totalScore < 34)
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
        else if (totalScore >= 34 && totalScore < 67)
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
        else if (totalScore == 67)
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
