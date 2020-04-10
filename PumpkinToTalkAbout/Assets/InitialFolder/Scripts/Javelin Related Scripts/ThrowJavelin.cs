using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ThrowJavelin.cs
 * ---------------
 * Pilots the throwing mechanic for the Farmer.
 * Currently rigidly designed to function only with the javelin mechanic.
 * 
 */
public class ThrowJavelin : MonoBehaviour
{
    [SerializeField]
    private GameObject javelinPrefab;

    [SerializeField]
    private Transform pitchforkSpawnLocation;

    private GameObject eventManager;
    private Animator anim;

    private List<GameObject> toolInventory;


    [Header("Adjustable Parameters")]
    public float throwStrength = 10f;
    public float reelStrength = 5f;

    public float javelinDuration = 4f;

    public float maxJavelinCooldown = 2f;
    public float currentJavelinCooldown;




    public void Start()
    {
        if (!pitchforkSpawnLocation)
            pitchforkSpawnLocation = GetComponentsInChildren<Transform>()[1];

        if (!eventManager)
            eventManager = GameObject.Find("EventManager");

        if (!anim && GetComponent<Animator>())
            anim = GetComponent<Animator>();

        //Initialize new list
        toolInventory = new List<GameObject>();
    }



    /* CreateJavelin()
     * ---------------
     * Instantiates a Pitchfork at a gameobject's location.
     * Sets the rotation, speed, duration, etc. of the pitchfork here. As such, all parameters meant to
     * affect the Pitchfork should be tweaked in this script!
     */
    public void TossJavelin()
    {
        anim.SetTrigger("triggerThrow");

        GameObject javelin = Instantiate(javelinPrefab, pitchforkSpawnLocation.position, transform.rotation, null);
        javelin.GetComponent<Rigidbody>().velocity = transform.forward * throwStrength;
        javelin.transform.Rotate(new Vector3(0, 0, 0));

        Javelin javelinScript = javelin.GetComponent<Javelin>();

        javelinScript.parent = gameObject;
        javelinScript.reelSpeed = reelStrength;
        javelinScript.maxDuration = javelinDuration;
    }



    void Update()
    {
        if (currentJavelinCooldown > 0)
            currentJavelinCooldown -= Time.deltaTime;

        //PRIMITIVE CHECK; REVISE LATER
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJavelinCooldown <= 0)
            {
                eventManager.GetComponent<EventManager>().pitchforkButtonPressed++;

                currentJavelinCooldown = maxJavelinCooldown;
                TossJavelin();
            }
        }
    }
}
