using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShurikenScript : MonoBehaviour
{
    public GameObject firstBurger, secondBurger, thirdBurger, camera, minusOne, cFX;

    public float remainedHeart;

    public Text heartRemained;

    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        remainedHeart = 3;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        Fail();
        heartRemained.text = remainedHeart.ToString("0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kofte")
        {
            shurikenTouch();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "marul")
        {
            shurikenTouch();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "peynir")
        {
            shurikenTouch();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "domates")
        {
            shurikenTouch();
            Destroy(other.gameObject);
        }
    }
    void Fail() 
    {
        if (remainedHeart == 0)
        {
            StartCoroutine(uiManager.TryAgain());
        }
    }
    private IEnumerator minusOneSecond() 
    {
        minusOne.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        minusOne.SetActive(false);
    }
    void shurikenTouch() 
    {
        Instantiate(cFX, transform.position, Quaternion.identity);
        camera.transform.DOShakePosition(0.3f, 0.5f, 10, 90);
        remainedHeart -= 1;
        StartCoroutine(minusOneSecond());
        heartRemained.text = remainedHeart.ToString("0");
    }
}
