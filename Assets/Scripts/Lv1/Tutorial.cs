using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] tutorial;

    GeneralScript generalScript;
    SwipeScript swipeScript;
    BurgerInstantiate burgerIns;
    CheeseInstantiate cheeseIns;
    // Start is called before the first frame update
    void Start()
    {
        generalScript = FindObjectOfType<GeneralScript>();
        swipeScript = FindObjectOfType<SwipeScript>();
        burgerIns = FindObjectOfType<BurgerInstantiate>();
        cheeseIns = FindObjectOfType<CheeseInstantiate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AllClosed();
            burgerIns.isKofte = false;
            cheeseIns.isPeynir = false;
        }
        if (burgerIns.isKofte == true)
        {
            tutorial[2].SetActive(true);
        }
        else if (cheeseIns.isPeynir == true)
        {
            tutorial[2].SetActive(true);
        }
        else
        {
            tutorial[2].SetActive(false);
        }
        if (generalScript.isTutOver == true)
        {
            AllClosed();
        }
    }
    void AllClosed() 
    {
        for (int i = 0; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(false);
        }
    }
}
