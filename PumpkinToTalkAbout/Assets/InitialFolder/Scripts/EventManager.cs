using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EventManager : MonoBehaviour
{
    public int pitchforkButtonPressed;
    public int pitchforkHitGhost;
    public int pumpkinsPickedUp;
    public int steppedOnPressurePlate;
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

        AnalyseGhosts();
        UsedPitchfork();
    }


    //Functions called by other objects
    public void AddToPumpkinPickCount()
    {
        pumpkinsPickedUp += 1;
    }
    public void AddToSteppedOnPressurePlate()
    {
        steppedOnPressurePlate += 1;
    }
    public void AddToGhostHitCount()
    {
        pitchforkHitGhost += 1;
    }

    public void UsedPitchfork()
    {


        Analytics.CustomEvent("Used Pitchfork", new Dictionary<string, object>
        {

            {"Pitchfork Button Pressed", pitchforkButtonPressed }


        });

        Analytics.CustomEvent("Pitchfork Hit", new Dictionary<string, object>
        {

            {"Pitchfork Hit Ghost", pitchforkHitGhost }


        });
    }

    public void AnalyseGhosts()
    {
        Analytics.CustomEvent("PumpkinPickedUp", new Dictionary<string, object>
        {

            {"Picked Up Pumpkin", pumpkinsPickedUp }


        });
        Analytics.CustomEvent("SteppedOnPressurePlate", new Dictionary<string, object>
        {

            {"Stepped on Pressure Plate", steppedOnPressurePlate }


        });


    }

}
