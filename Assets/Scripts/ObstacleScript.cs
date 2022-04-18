using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kofte")
        {
            Destroy(other.gameObject);
            uIManager.isGameStarted = false;
            StartCoroutine(uIManager.TryAgain());
        }
        if (other.gameObject.tag == "marul")
        {
            Destroy(other.gameObject);
            uIManager.isGameStarted = false;
            StartCoroutine(uIManager.TryAgain());
        }
        if (other.gameObject.tag == "peynir")
        {
            Destroy(other.gameObject);
            uIManager.isGameStarted = false;
            StartCoroutine(uIManager.TryAgain());
        }
        if (other.gameObject.tag == "tursu")
        {
            Destroy(other.gameObject);
            uIManager.isGameStarted = false;
            StartCoroutine(uIManager.TryAgain());
        }
        if (other.gameObject.tag == "domates")
        {
            Destroy(other.gameObject);
            uIManager.isGameStarted = false;
            StartCoroutine(uIManager.TryAgain());
        }
    }
}
