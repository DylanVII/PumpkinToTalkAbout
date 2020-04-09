using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTurnOn : MonoBehaviour
{

    //This script is for the pressure pad that turns on the real pressure pad.

    public bool steppedOnBool;
    public bool steppedOff;

    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public GameObject pressurePad;


    // Update is called once per frame
    void Update()
    {
        SteppedOn();
    }

    public void SteppedOn()
    {
        //If the pressure pad was stepped on then
        if (steppedOnBool)
        {
            
            timePassing = 0;


            pressurePad.SetActive(true);

        }
        //If something has come off the pressure pad and nothing is on it
        if (!steppedOnBool & steppedOff)
            TimerFunction();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ghost")
            steppedOnBool = true;
    }
    private void OnTriggerExit(Collider other)
    {
        steppedOnBool = false;
        steppedOff = true;
    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime && pressurePad.GetComponent<PressurePad>().timePassing <= 0)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Turn off the pressure pad
        pressurePad.SetActive(false);

        steppedOff = false;
        //Only use if timer needs to be reset
        timePassing = 0;
    }
}
