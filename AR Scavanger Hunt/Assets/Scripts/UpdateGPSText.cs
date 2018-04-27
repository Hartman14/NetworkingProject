using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour{
    public Text Coordinates;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Coordinates.text = "Lat: " + GPSFinder.Instance.latitude.ToString() + "\n Long: " + GPSFinder.Instance.longitude.ToString();
    }
}
