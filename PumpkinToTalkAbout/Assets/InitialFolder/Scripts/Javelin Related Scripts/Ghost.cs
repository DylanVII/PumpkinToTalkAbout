using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool canMove;

    public float maxStunDuration, currentStunDuration;

    public _states status;
    public enum _states
    {
        normal,
        stunned
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case _states.normal:
                //be ok
                break;

            case _states.stunned:
                //be not ok
                Stunned();
                break;
        }
    }

    public void Stunned()
    {
        canMove = false;

        if (status == _states.stunned)
        {
            if (currentStunDuration > 0)
                currentStunDuration -= Time.deltaTime;
            else
                status = _states.normal;
        }
    }
}
