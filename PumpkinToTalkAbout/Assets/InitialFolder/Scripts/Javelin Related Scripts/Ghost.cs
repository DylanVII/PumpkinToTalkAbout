using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
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
                break;
        }
    }
}
