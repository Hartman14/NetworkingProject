using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueHandler : MonoBehaviour {

    public GameObject ClueLock1;
    public GameObject ClueLock2;
    public GameObject ClueLock3;

    public GameObject Clue1;
    public GameObject Clue2;
    public GameObject Clue3;


    // Use this for initialization
    void Start () {
        setFeild();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void setFeild()
    {
        ClueLock1.SetActive(false);
        Clue1.SetActive(true);
        ClueLock2.SetActive(true);
        Clue2.SetActive(false);
        ClueLock3.SetActive(true);
        Clue3.SetActive(false);
    }

    //unlocks clue 2
    public void setClue2()
    {
        ClueLock2.SetActive(false);
        Clue2.SetActive(true);
    }

    //unlocks clue 3
    public void setClue3()
    {
        ClueLock3.SetActive(false);
        Clue3.SetActive(true);
    }

    public int CurrentClue()
    {
        if (Clue3.activeSelf)
        {
            return 3;
        }

        else if (Clue2.activeSelf)
        {
            return 2;
        }

        else
        {
            return 1;
        }
    }
}
