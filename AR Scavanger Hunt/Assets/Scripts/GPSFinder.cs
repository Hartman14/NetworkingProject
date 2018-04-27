using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSFinder : MonoBehaviour {

    public static GPSFinder Instance { set; get; }

    public float latitude;
    public float longitude;


    // Use this for initialization
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        StartCoroutine(LocationServiceInitial());
    }

    private IEnumerator LocationServiceInitial()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS!");
            yield break;
        }

        Input.location.Start();
        int maxWait = 15;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
