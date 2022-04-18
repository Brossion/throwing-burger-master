using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;
    public bool isGameStarted, canTouch, isBad;
    // Start is called before the first frame update
    void Start()
    {
        canTouch = false;
        isGameStarted = false;
        isBad = false;
    }
    public void Reload() 
    {
        Debug.Log("Replay the game!");
        SceneManager.LoadScene("SampleScene");
    }
    public IEnumerator iGS()
    {
        isGameStarted = false;
        yield return new WaitForSeconds(0.1f);
        isGameStarted = true;
    }
    public void Lv2()
    {
        SceneManager.LoadScene("Lv2");
        Time.timeScale = 1;
    }
    public void Lv3()
    {
        SceneManager.LoadScene("Lv3");
        Time.timeScale = 1;
    }
    public void Lv4()
    {
        SceneManager.LoadScene("Lv4");
        Time.timeScale = 1;
    }
    public void Lv5()
    {
        SceneManager.LoadScene("Lv5");
        Time.timeScale = 1;
    }
    public void Lv6()
    {
        SceneManager.LoadScene("Lv6");
        Time.timeScale = 1;
    }
    public void Lv7()
    {
        SceneManager.LoadScene("Lv7");
        Time.timeScale = 1;
    }
    public IEnumerator TryAgain()
    {
        isGameStarted = false;
        yield return new WaitForSeconds(0.1f);
        panels[0].SetActive(false);
        panels[1].SetActive(true);
        Time.timeScale = 0.001f;
    }
}
