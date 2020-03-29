using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Gain access to the following scripts
    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        //Set the following scripts

        if (GetComponent<Movement>())
            movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //If x is existant, call it
        if (movement != null)
            movement.MovementUpdate();

    }
    private void FixedUpdate()
    {
        //If x is existant, call it
        if (movement != null)
            movement.MovementFixedUpdate();
    }



}
