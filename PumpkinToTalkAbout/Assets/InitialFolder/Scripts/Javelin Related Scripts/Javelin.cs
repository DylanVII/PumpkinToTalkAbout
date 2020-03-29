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
        
    public GameObject parent;

    [SerializeField]
    private GameObject attachedObject;

    [SerializeField]
    private bool isReeling = false;

    [HideInInspector]
    public float reelSpeed; //Speed for when the Javelin returns to the player.
    [HideInInspector]
    public float maxDuration; //Lifespan in seconds. When reeling, this is paused.
    [HideInInspector]
    public float currentDuration;



    void Start()
    {
        if (!collider)
            collider = GetComponent<Collider>();

        currentDuration = maxDuration;

    }



    void Update()
    {

        if (isReeling)
            PullObjectToLocation(parent.transform.position, reelSpeed);

        if (!isReeling)
            DestroyAfterDuration();
    }



    /* PullObjectToLocation
     * -------------------------------------
     * Moves this gameObject via velocity towards the input Vector3 position.
     * Velocity scales by input float "reeling speed".
     * Typically called every frame.
     * 
     */
    public void PullObjectToLocation(Vector3 endPosition, float reelingSpeed)
    {
        if (Vector3.Distance(endPosition,transform.position) > 0.5f)
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



    /* DestroyAfterDuration()
     * ----------------------
     * Self-explanatory.
     * No argument, as it already has the required information in the script.
     */
    public void DestroyAfterDuration()
    {
        currentDuration -= Time.deltaTime;

        if (currentDuration <= 0)
            Destroy(gameObject);
    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pumpkin")
        {
            isReeling = true;

            GameObject pumpkin = other.gameObject;
            Pumpkin pumpkinScript = pumpkin.GetComponent<Pumpkin>();

            //Movement-oriented variables
            pumpkinScript.isGrabbed = true;
            pumpkinScript.parentTransform = transform;
            pumpkin.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

            attachedObject = pumpkin;

            //Disable unnecessary collisions when reeling.
            collider.enabled = false;
        }

        if (other.gameObject.tag == "Ghost")
        {
            //Debug.Log("Impaled a ghost boi");

            //Do stun code
            isReeling = true;

            GameObject ghost = other.gameObject;
            Ghost ghostScript = ghost.GetComponent<Ghost>();

            ghostScript.canMove = false;
            ghostScript.status = Ghost._states.grabbed;
            ghostScript.currentStunDuration = ghostScript.maxStunDuration;

            //Movement-oriented variables
            ghostScript.parentTransform = transform;
            ghost.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            //attachedObject = ghost;

            //Disable unnecessary collisions when reeling.
            collider.enabled = false;

        }
    }

}
