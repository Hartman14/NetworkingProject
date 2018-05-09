using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    public GameObject CheckPoint1;
    public GameObject CheckPoint2;
    public GameObject CheckPoint3;

    // Use this for initialization
    void Start () {
        startHunt();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //resets the checkpoints for the scavanger hunt. turns off all but checkpoint 1
    private void startHunt()
    {
        CheckPoint1.SetActive(true);
        CheckPoint2.SetActive(false);
        CheckPoint3.SetActive(false);
    }


    //returns active checkpoint progress
    public int ChockpointProgressOutput()
    {
        if (CheckPoint2.activeSelf)
        {
            return 2;
        }

        else if (CheckPoint3.activeSelf)
        {
            return 3;
        }

        else
        {
            return 1;
        }
    }

    //sets Checkpoint 2 active
    private void setCheckPoint2Active()
    {
        CheckPoint2.SetActive(true);
        CheckPoint1.SetActive(false);
        CheckPoint3.SetActive(false);
    }
    //sets Checkpoint 3 active
    private void setCheckPoint3Active()
    {
        CheckPoint3.SetActive(true);
        CheckPoint1.SetActive(false);
        CheckPoint2.SetActive(false);
    }

    public void setCheckPointActive(GameObject input)
    {
        if (input == CheckPoint1)
        {
            Debug.Log("On to Clue 2!");
            setCheckPoint2Active();
        }

        else if (input == CheckPoint2)
        {
            Debug.Log("On to Clue 3");
            setCheckPoint3Active();

        }

        else if (input == CheckPoint3)
        {
            Debug.Log("YOU WIN!!!!!");
        }
    }

}
