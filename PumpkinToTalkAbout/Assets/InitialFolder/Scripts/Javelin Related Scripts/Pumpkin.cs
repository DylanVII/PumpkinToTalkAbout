using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public bool isGrabbed = false;

    public Transform parentTransform;

    private new Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            collider.enabled = false;

            if (parentTransform)
            {
                Debug.Log("Mirroring Pitchfork transform...");
                //Debug.Log(parentTransform.GetComponent<Rigidbody>().velocity);
                GetComponent<Rigidbody>().velocity = parentTransform.GetComponent<Rigidbody>().velocity * -2f;
            }
        }
        else
        {
            collider.enabled = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

       
    }
}
