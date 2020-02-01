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

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pumpkin")
        {

        }

        if (other.gameObject.tag == "Ghost")
        {

        }
    }
}
