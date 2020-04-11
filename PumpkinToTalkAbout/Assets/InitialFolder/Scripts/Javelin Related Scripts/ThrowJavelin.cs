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


    [Header("Adjustable Parameters")]
    public float throwStrength = 10f;
    public float reelStrength = 5f;

    public float javelinDuration = 4f;

    public float maxJavelinCooldown = 2f;
    public float currentJavelinCooldown;

    [Header("Farmer's Inventory")]
    public List<GameObject> toolInventory;

    private List<GameObject> instantiatedTools;


    public void Start()
    {
        if (!pitchforkSpawnLocation)
            pitchforkSpawnLocation = GetComponentsInChildren<Transform>()[1];

        if (!eventManager)
            eventManager = GameObject.Find("EventManager");

        if (!anim && GetComponent<Animator>())
            anim = GetComponent<Animator>();


        instantiatedTools = new List<GameObject>();
        InstantiateToolsInInventory();
    }



    /* TossJavelin()
     * ---------------
     * Enables a Pitchfork at a gameobject's location.
     * Sets the rotation, speed, duration, etc. of the pitchfork here. As such, all parameters meant to
     * affect the Pitchfork should be tweaked in this script!
     */
    public void TossJavelin()
    {
        anim.SetTrigger("triggerThrow");

        GameObject javelin = instantiatedTools[0];

        javelin.SetActive(true);

        javelin.GetComponent<Rigidbody>().velocity = transform.forward * throwStrength;
        javelin.transform.rotation = transform.rotation;
        javelin.transform.position = pitchforkSpawnLocation.position;

        Javelin javelinScript = javelin.GetComponent<Javelin>();

        javelinScript.parent = gameObject;
        javelinScript.reelSpeed = reelStrength;
        javelinScript.maxDuration = javelinDuration;
    }

    /* InstantiateToolsInInventory()
     * -----------------------------
     * Instantiates and disables all GameObjects in the Farmer's inventory.
     * A poor-man's object pool.
     * Can fully support a single projectile, but still needs work to support multiple.
     * Intended for Pitchforks ONLY, but doesn't currently have a way to filter.
     */
    public void InstantiateToolsInInventory()
    {
        foreach (GameObject tool in toolInventory)
        {
            Debug.Log("Instantiated a " + tool.name);
            GameObject javelin = Instantiate(tool, pitchforkSpawnLocation.position, transform.rotation, null);
            
            instantiatedTools.Add(javelin);

            javelin.SetActive(false);
        }
                
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
