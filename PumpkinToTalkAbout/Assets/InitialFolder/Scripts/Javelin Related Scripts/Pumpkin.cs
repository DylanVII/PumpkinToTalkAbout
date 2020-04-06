using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public bool isGrabbed = false;

    public Transform parentTransform;

    private new Collider collider;
    private Rigidbody rigidbody;



    void Start()
    {
        collider = GetComponent<Collider>();

        if (GetComponent<Rigidbody>())
            rigidbody = GetComponent<Rigidbody>();

    }



    void Update()
    {
        if (isGrabbed)
        {
            Grabbed();
        }
        else
        {
            if (!collider.enabled)
                collider.enabled = true;

            if (rigidbody.velocity != new Vector3(0, 0, 0))
                rigidbody.velocity = new Vector3(0,0,0);
        }

    }



    void Grabbed()
    {
        if (collider.enabled)
            collider.enabled = false;

        if (parentTransform)
        {
            //Debug.Log("Mirroring Pitchfork transform...");
            //Debug.Log(parentTransform.GetComponent<Rigidbody>().velocity);
            //rigidbody.velocity = parentTransform.GetComponent<Rigidbody>().velocity;
            transform.position = new Vector3(parentTransform.position.x,
                                             transform.position.y,
                                             parentTransform.position.z);
        }
    }
}
