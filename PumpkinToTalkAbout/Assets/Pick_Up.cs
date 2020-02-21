using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    Movement ghostMovement;
    Transform ghostPosition;
    public GameObject grabHitbox;
    
    void Start()
    {
        ghostMovement = GetComponent<Movement>();
        ghostPosition = GetComponent<Transform>();
    }


    void Update()
    {
        grabHitbox.transform.position = ghostPosition.position + ghostMovement.lastRecordedInput;
    }
}
