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



    [Header("DO NOT MODIFY BELOW IN INSPECTOR")]
    public GameObject parent;
    public GameObject trail;
    public GameObject hitParticle;


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

    private GameObject eventManager;

    void Awake()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager");

        if (!collider)
            collider = GetComponent<Collider>();
    }

    void OnEnable()
    {
        if (maxDuration == 0)
            maxDuration = 1f;

        currentDuration = maxDuration;

        //Return parameters to default
        collider.enabled = true;
        isReeling = false;
        attachedObject = null;

        hitParticle.SetActive(false);
        trail.SetActive(true);

    }

    void Update()
    {

        if (isReeling)
            PullObjectToLocation(parent.transform.position + new Vector3(0, 2), reelSpeed);

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
        if (Vector3.Distance(endPosition, transform.position) > 1.5f)
        {
            float step = reelingSpeed * 90f * Time.deltaTime;

            Vector3 direction = endPosition - transform.position;
            Vector3 normalizedDirection = direction.normalized;


            GetComponent<Rigidbody>().velocity = normalizedDirection * step;

            Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.up);
            transform.rotation = rotation;
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

            ReturnToInventory();
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
            ReturnToInventory();
    }


    /* ReturnToInventory()
     * -------------------
     * Disables the GameObject, resetting its state.
     * Typically called where you'd usually destroy this object.
     */
    public void ReturnToInventory()
    {


       gameObject.SetActive(false);
    }



    public void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Pumpkin":
                isReeling = true;

                GameObject pumpkin = other.gameObject;
                Pumpkin pumpkinScript = pumpkin.GetComponent<Pumpkin>();

                //Movement-oriented variables
                pumpkinScript.isGrabbed = true;
                pumpkinScript.parentTransform = transform;
                pumpkin.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                trail.SetActive(false);

                attachedObject = pumpkin;

                //Disable unnecessary collisions when reeling.
                collider.enabled = false;

                break;
                
            case "Ghost":

                SoundManager.PlaySound("Stab");

                //Debug.Log("Impaled a ghost boi");

                eventManager.GetComponent<EventManager>().AddToGhostHitCount();

                //Do stun code
                isReeling = true;
                hitParticle.SetActive(true);
                trail.SetActive(false);

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

                break;


            case "Fence":

                GetComponent<Rigidbody>().velocity = new Vector3(0, 0);

                break;
        }
    }


}
