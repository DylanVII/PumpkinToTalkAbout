﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    public GameObject doorHedge;
    public bool steppedOnBool;
    public bool steppedOff;

    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    private GameObject eventManager;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager");
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
            //Ensure the door won't come down 
            timePassing = 0;

            //Raise the door hedge
            doorHedge.transform.position = new Vector3(doorHedge.transform.position.x, 1.15f, doorHedge.transform.position.z);
        }
        //If something has come off the pressure pad and nothing is on it
        if (!steppedOnBool & steppedOff)
            TimerFunction();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Can only be used by ghosts
        if (other.gameObject.tag == "Ghost")
            steppedOnBool = true;
    }
    private void OnTriggerExit(Collider other)
    {
        eventManager.GetComponent<EventManager>().AddToSteppedOnPressurePlate();
        steppedOnBool = false;
        steppedOff = true;
    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Bring down the pressure pad
        doorHedge.transform.position = new Vector3(doorHedge.transform.position.x, -1.45f, doorHedge.transform.position.z);

        steppedOff = false;
        //Only use if timer needs to be reset
        timePassing = 0;
    }
}
