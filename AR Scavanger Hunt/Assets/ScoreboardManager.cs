using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour {

    private string LeadPlayer;
    private string checkpointAt;


    private void Start()
    {
        LeadPlayer = "Tied";
        checkpointAt = "1";
    }

    void Update()
    {
        try
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<PlayerProgress>().returnCheckpointProgress() > getCP(checkpointAt))
                {
                    LeadPlayer = players[i].name;
                    checkpointAt = players[i].GetComponent<PlayerProgress>().returnCheckpointProgress().ToString();
                }
                else if (players[i].GetComponent<PlayerProgress>().returnCheckpointProgress() == getCP(checkpointAt))
                {
                    LeadPlayer = "tied";
                }
            }
        }
        catch
        {
            Debug.Log("Empty Network");
        }
    }


    public string sendLeadPlayerName()
    {
        return LeadPlayer;
    }

    public string sendLeadPlayerCheckpoint()
    {
        return checkpointAt;
    }


    private int getCP(string input)
    {
        if(input == "2")
        {
            return 2;
        }
        else if(input == "3")
        {
            return 3;
        }
        
        else
        {
            return 1;
        }

    }
}
