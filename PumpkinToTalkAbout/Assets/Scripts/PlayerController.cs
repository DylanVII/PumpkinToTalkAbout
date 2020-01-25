using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement != null)
            movement.MovementUpdate();

    }
    private void FixedUpdate()
    {
        if (movement != null)
            movement.MovementFixedUpdate();
    }



}
