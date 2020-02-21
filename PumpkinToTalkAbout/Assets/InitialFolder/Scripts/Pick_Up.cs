using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    Movement ghostMovement;
    Transform ghostPosition;
    public GameObject grabHitbox;
    public BoxCollider hitBox;

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

        if (Input.GetButtonDown("b button"))
        {
            Debug.Log("Button B is pressed");
            grabHitbox.GetComponent<MeshRenderer>().material = onHitbox;
        }
        else
        {
            grabHitbox.GetComponent<MeshRenderer>().material = offHitbox;
        }
        
    }


  
}
