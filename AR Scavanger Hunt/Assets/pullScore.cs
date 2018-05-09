using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pullScore : MonoBehaviour {

    public Text Leader;
    public Text score;
    public GameObject networkControl;

    void Update()
    {
        Leader.text = networkControl.GetComponent<ScoreboardManager>().sendLeadPlayerName();
        score.text = networkControl.GetComponent<ScoreboardManager>().sendLeadPlayerCheckpoint().ToString();
    }



}
