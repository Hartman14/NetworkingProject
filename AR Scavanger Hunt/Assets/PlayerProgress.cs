using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour {

    private int currentCheckpoint;
    private int currentClue;
    public GameObject PlayerUI;

    // Use this for initialization
    void Start () {
        setStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //Sets Checkpoint value to
    private void setStart()
    {
        currentCheckpoint = 1;
        currentClue = 1;
    }

    //checks variable progress (includes checkpoint, and clue status)
    private void playerProgress()
    {
        //currentClue = PlayerUI.GetComponents<ClueHandler>().CurrentClue();
    }

    public int returnClueProgress()
    {
        return currentClue;
    }


    public int returnCheckpointProgress()
    {
        return currentCheckpoint;
    }

}
