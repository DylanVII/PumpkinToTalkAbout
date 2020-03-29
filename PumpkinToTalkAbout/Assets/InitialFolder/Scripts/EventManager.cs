using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EventManager : MonoBehaviour
{
    public int pitchforkButtonPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pitchforkButtonPressed += 1;
        }

        UsedPitchfork();
    }

    public void UsedPitchfork()
    {


        Analytics.CustomEvent("Used Pitchfork", new Dictionary<string, object>
        {

            {"Pitchfork Button Pressed", pitchforkButtonPressed }


        });




    }
}
