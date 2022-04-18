using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseInstantiate : MonoBehaviour
{
    public GameObject[] obj;

    public bool isPeynir;
    private void Start()
    {
        isPeynir = false;
    }
    public void ObjInstantiate()
    {
        isPeynir = true;
        Destroy(GameObject.Find("Peynir Duz (1) 1(Clone)"));
        Destroy(GameObject.Find("Marul (1) 1(Clone)"));
        Destroy(GameObject.Find("Kofte (1) 1(Clone)"));
        Destroy(GameObject.Find("Domates (1) 1(Clone)"));
        Destroy(GameObject.Find("Pickle (1) 1(Clone)"));
        Instantiate(obj[0], transform.position, Quaternion.Euler(90, 30.5919113f, 0));
    }
}
