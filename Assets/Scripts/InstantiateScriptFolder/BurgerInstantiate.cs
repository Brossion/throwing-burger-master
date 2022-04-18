using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerInstantiate : MonoBehaviour
{
    public GameObject[] obj;

    public bool isKofte;
    private void Start()
    {
        isKofte = false;
    }
    public void ObjInstantiate()
    {
        isKofte = true;
        Destroy(GameObject.Find("Peynir Duz (1) 1(Clone)"));
        Destroy(GameObject.Find("Marul (1) 1(Clone)"));
        Destroy(GameObject.Find("Kofte (1) 1(Clone)"));
        Destroy(GameObject.Find("Domates (1) 1(Clone)"));
        Destroy(GameObject.Find("Pickle (1) 1(Clone)"));
        Instantiate(obj[0], transform.position, Quaternion.identity);
    }
}
