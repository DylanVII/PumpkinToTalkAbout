using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTurnOn : MonoBehaviour
{
    public bool steppedOnBool;
    public bool steppedOff;

    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public GameObject pressurePad;

    // Start is called before the first frame update
    void Start()
    {

    }

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
            //Ensure the door won't come down (Must discuss whether or not want this to forever stay up when something is on pad)
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
