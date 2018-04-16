using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //erases the grabbed item, here you will want to send the signal to the inventory class to let it know it got it
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
