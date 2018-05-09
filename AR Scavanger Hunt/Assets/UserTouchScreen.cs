using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTouchScreen : MonoBehaviour {

    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] oldTouches;
    private RaycastHit hit;
    private GameObject newTarget;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        try
        {
            Debug.Log("FUCK YOU BITCH!!!");
            clickUpdate();
        }
        catch
        {
            Debug.Log("Click Error");
        }
        try
        {
            touchUpdater();
        }
        catch
        {
            Debug.Log("Click 2.0 Error");
        }
        try
        {
            touchUpdate();
        }
        catch
        {
            Debug.Log("Touch Error!");
        }
    }



    //checks and updates the clue progress
    private void ClueChecker()
    {

    }

    void touchUpdater()
    {
        if (Input.touchCount > 0) {
            Ray rayout = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            if (Physics.Raycast(rayout, out Hit))
            {
                newTarget = Hit.transform.gameObject;
                newTarget.GetComponentInParent<CheckPointController>().setCheckPointActive(newTarget);
            }
        }
    }

    void touchUpdate()
    {
        
        if (Input.touchCount > 0)
        {

            oldTouches = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouches);
            touchList.Clear();

            

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject target = hit.transform.gameObject;

                    if (touch.phase == TouchPhase.Began)
                    {
                        target.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        target.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Stationary)
                    {
                        target.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Canceled)
                    {
                        target.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            foreach (GameObject g in oldTouches)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        } 

    }


    void clickUpdate()
    {
        //This code will only be run with in the Unity environment for testing purposes, upon compiling this will go as invisible code that isn't referenced

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            Debug.Log("Click made");

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            oldTouches = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouches);
            touchList.Clear();



            foreach (Touch touch in Input.touches)
            {

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject target = hit.transform.gameObject;

                    if (Input.GetMouseButtonDown(0))
                    {
                        target.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("SHOTS FIRED!!!!");
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        Debug.Log("HOLD YOUR FIRE!!!");
                        target.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);

                    }

                    if (Input.GetMouseButton(0))
                    {
                        target.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                }
            }

            foreach (GameObject g in oldTouches)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
