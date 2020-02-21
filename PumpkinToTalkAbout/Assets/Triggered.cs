using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public bool triggered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pumpkin")
        {
            triggered = true;
        }
        else
        {
            triggered = false; 

        }
    }
}
