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

    [Header("Adjustable Parameters")]
    public float throwStrength = 10f;
    public float reelStrength = 5f;

    public float javelinDuration = 4f;

    public float maxJavelinCooldown = 2f;
    public float currentJavelinCooldown;

    private GameObject eventManager;

    public void Start()
    {
        if (!pitchforkSpawnLocation)
            pitchforkSpawnLocation = GetComponentsInChildren<Transform>()[1];

        if (!eventManager)
            eventManager = GameObject.Find("EventManager");
    }

    public void CreateJavelin()
    {
        GameObject javelin = Instantiate(javelinPrefab, pitchforkSpawnLocation.position, transform.rotation, null);
        javelin.GetComponent<Rigidbody>().velocity = transform.forward * throwStrength;
        javelin.transform.Rotate(new Vector3(90, 0, 0));

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
                CreateJavelin();
            }
        }
    }
}
