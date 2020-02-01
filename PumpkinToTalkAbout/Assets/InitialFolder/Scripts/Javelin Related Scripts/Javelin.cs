using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Javelin.cs
 * ----------
 * Script that sets the functionality behind the "javelin".
 * Apply onto the Javelin prefab.
 * 
 */
public class Javelin : MonoBehaviour
{
    private new Collider collider;
    void Start()
    {
        if (!collider)
            collider = GetComponent<Collider>();
    }

    void OnColliderEnter(Collider other)
    {
        if (other.tag == "Hedge")
        {
            collider.enabled = false;
        }
    }

    void OnColliderExit(Collider other)
    {
        if (other.tag == "Hedge")
        {
            collider.enabled = true;
        }
    }
}
