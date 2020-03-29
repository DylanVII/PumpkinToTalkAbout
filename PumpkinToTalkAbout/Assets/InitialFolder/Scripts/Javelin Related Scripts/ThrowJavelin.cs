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

    [Header("Adjustable Parameters")]
    public float throwStrength = 10f;
    public float reelStrength = 5f;

    public float javelinDuration = 4f;

    public void CreateJavelin()
    {
        GameObject javelin = Instantiate(javelinPrefab, transform.position + Vector3.forward, transform.rotation, null);
        javelin.GetComponent<Rigidbody>().velocity = transform.forward * throwStrength;
        javelin.transform.Rotate(new Vector3(90, 0, 0));

        Javelin javelinScript = javelin.GetComponent<Javelin>();

        javelinScript.parent = gameObject;
        javelinScript.reelSpeed = reelStrength;
        javelinScript.maxDuration = javelinDuration;
    }

    void Update()
    {
        //PRIMITIVE CHECK; REVISE LATER
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateJavelin();
        }
    }
}
