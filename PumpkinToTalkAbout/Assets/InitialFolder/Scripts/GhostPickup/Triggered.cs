using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public bool triggered = false;
    public GameObject targetPumpkin;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pumpkin")
        {
            targetPumpkin = other.gameObject; 
            triggered = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
