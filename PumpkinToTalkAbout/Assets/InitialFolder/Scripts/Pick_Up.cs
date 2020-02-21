using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    Movement ghostMovement;
    Transform ghostPosition;
    public GameObject grabLocation;
    public GameObject grabHitbox;
    public BoxCollider hitBox;
    public Triggered triggerScript;

    public Material onHitbox;
    public Material offHitbox;
    
    void Start()
    {
        grabHitbox.GetComponent<MeshRenderer>().material = offHitbox;
        ghostMovement = GetComponent<Movement>();
        ghostPosition = GetComponent<Transform>();
    }


    void Update()
    {
        grabHitbox.transform.position = ghostPosition.position + ghostMovement.lastRecordedInput;
        //This commented code will be relevant when we have rotation code down
        // grabHitbox.transform.position = grabLocation.transform.position;
        //if the b button is pressed and the hitbox is triggering with a pumpkin Grab the pumpkin
        if (Input.GetButton("b button"))
        {
            Debug.Log("Button B is pressed");
            //set the active hitbox color
            grabHitbox.GetComponent<MeshRenderer>().material = onHitbox;
            if (triggerScript.triggered)
            {
                GrabPumpkin();
            }
        }
        else
        {
            //set the hitbox to inactive color
            grabHitbox.GetComponent<MeshRenderer>().material = offHitbox;
        }

      

    }


    //set the position of the pumpkin while the button is held
    void GrabPumpkin()
    {
        //This commented code will be relevant when we have rotation code down
        // triggerScript.targetPumpkin.transform.position = grabLocation.transform.position;
        triggerScript.targetPumpkin.transform.position = ghostPosition.position + ghostMovement.lastRecordedInput;
    }
}
