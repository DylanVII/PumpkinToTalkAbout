using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    Movement ghostMovement;
    Transform ghostPosition;
    public GameObject grabLocation;
    public GameObject grabHitbox;
    public Collider hitBox;
    public Triggered triggerScript;

    private GameObject eventManager;
   // public Material onHitbox;
    //public Material offHitbox;
    
    void Start()
    {
        //grabHitbox.GetComponent<MeshRenderer>().material = offHitbox;
        eventManager = GameObject.FindGameObjectWithTag("EventManager");
        ghostMovement = GetComponent<Movement>();
        ghostPosition = GetComponent<Transform>();
    }


    void Update()
    {
        //Old Code that made rotation but doesnt matter anymore
        //grabHitbox.transform.position = ghostPosition.position + ghostMovement.lastRecordedInput;

        //This commented code will be relevant when we have rotation code down
        grabHitbox.transform.position = grabLocation.transform.position;
        //if the b button is pressed and the hitbox is triggering with a pumpkin Grab the pumpkin
        if (Input.GetButton("Fire2") || Input.GetKey("b"))
        {
            Debug.Log("Button B is pressed");
            //set the active hitbox color
           // grabHitbox.GetComponent<MeshRenderer>().material = onHitbox;
            if (triggerScript.triggered)
            {
                GrabPumpkin();
            }
        }
        else
        {
            //set the hitbox to inactive color
           // grabHitbox.GetComponent<MeshRenderer>().material = offHitbox;
        }

      

    }


    //set the position of the pumpkin while the button is held
    void GrabPumpkin()
    {

        eventManager.GetComponent<EventManager>().AddToPumpkinPickCount();
        //This commented code will be relevant when we have rotation code down
        triggerScript.targetPumpkin.transform.position = grabLocation.transform.position;
        //Old Code that made rotation but doesnt matter anymore
        //triggerScript.targetPumpkin.transform.position = ghostPosition.position + ghostMovement.lastRecordedInput;
    }
}
