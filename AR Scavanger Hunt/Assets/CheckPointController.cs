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


}
