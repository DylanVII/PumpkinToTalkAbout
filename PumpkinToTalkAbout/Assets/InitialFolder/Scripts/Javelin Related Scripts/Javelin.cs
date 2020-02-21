using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Javelin.cs
 * ----------
 * Script that sets the functionality behind the "javelin".
 * Apply onto the Javelin prefab.
 * 
 * Not really too satisfied with how the code functions (probably forgetting
 * some obvious fundamentals cuz smol brain), but will have to do for now.
 */
public class Javelin : MonoBehaviour
{
    private new Collider collider;

    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject attachedObject;

    [SerializeField]
    private bool isReeling = false;

    [SerializeField]
    private float reelSpeed = 5f; //Speed for when the Javelin returns to the player.

    void Start()
    {
        if (!collider)
            collider = GetComponent<Collider>();
    }



    void Update()
    {

        if (isReeling)
            PullObjectToLocation(parent.transform.position, reelSpeed);
    }



    public void PullObjectToLocation(Vector3 endPosition, float reelingSpeed)
    {
        if (Vector3.Distance(endPosition,transform.position) > 0.1f)
        {
            float step = reelingSpeed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

            Vector3 direction = endPosition - transform.position;
            Vector3 normalizedDirection = direction.normalized;

            GetComponent<Rigidbody>().velocity = normalizedDirection * step;
        }
        else
        {
            isReeling = false;

            //collider.enabled = true;

            if (attachedObject)
            {
                attachedObject.transform.parent = null;

                if (attachedObject.tag == "Pumpkin")
                {
                    attachedObject.GetComponent<Pumpkin>().isGrabbed = false;
                }
            }

            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pumpkin")
        {
            isReeling = true;

            GameObject pumpkin = other.gameObject;
            Pumpkin pumpkinScript = pumpkin.GetComponent<Pumpkin>();

            pumpkinScript.isGrabbed = true;
            pumpkinScript.parentTransform = transform;
            pumpkin.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            //pumpkin.transform.parent = gameObject.transform;
            attachedObject = pumpkin;

            //Disable unnecessary collisions when reeling.
            collider.enabled = false;
        }

        if (other.gameObject.tag == "Ghost")
        {
            Debug.Log("Impaled a ghost boi");

            //Do stun code
            isReeling = true;

            GameObject ghost = other.gameObject;



        }
    }

}
