using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeScript : MonoBehaviour
{
    private Vector3 startPos, endPos, force; // touch start position, touch end position, force

    float factor = 1000f;

    Rigidbody rb;

    public float startTime;

    private bool touchStarted;

    UIManager uiManager;
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.isGameStarted == true)
        {
            Debug.Log("uiManager.isGameStarted is " + uiManager.isGameStarted);
            // if you touch the screen
            if (Input.GetMouseButtonDown(0) && touchStarted == false /*&& uiManager.canTouch == true*/)
            {
                if (/*EventSystem.current.IsPointerOverGameObject() &&*/ IsPointerOverUIObject())
                {
                    Debug.Log("UI Button touchedDown!");
                    return;
                }
                // getting touch position and marking time when you touch the screen
                startTime = Time.time;
                startPos = Input.mousePosition;
                startPos.z = transform.position.z - Camera.main.transform.position.z;
                startPos = Camera.main.ScreenToWorldPoint(startPos);
                touchStarted = true;
                Debug.Log("Swiping has began.");
            }

            // if you release your finger
            if (Input.GetMouseButtonUp(0) && touchStarted == true /*&& uiManager.canTouch == true*/)
            {
                if (/*EventSystem.current.IsPointerOverGameObject() &&*/ IsPointerOverUIObject())
                {
                    Debug.Log("UI Button touchedUp!");
                    return;
                }
                // getting release finger position
                endPos = Input.mousePosition;
                endPos.z = transform.position.z - Camera.main.transform.position.z;
                endPos = Camera.main.ScreenToWorldPoint(endPos);

                // calculating swipe direction in 2D space
                force = (endPos - startPos).normalized;
                force.z = force.magnitude;
                //force /= (Time.time - startTime);

                // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces             
                if (Vector3.Distance(startPos, endPos) > 0.4f)
                {
                    rb.AddForce(force * factor);
                }
                touchStarted = false;
                Debug.Log("Swiping has finished.");
                Debug.Log("force is: " + force + ", startTime is: " + startTime + "startPos is: " + startPos + ", endPos is: " + endPos + ", factor is: " + factor);
            }
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}


