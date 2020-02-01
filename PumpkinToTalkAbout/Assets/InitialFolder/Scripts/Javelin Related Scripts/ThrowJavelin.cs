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
    public float throwStrength = 10f;

    [SerializeField]
    private GameObject javelinPrefab;

    public void CreateJavelin()
    {
        GameObject javelin = Instantiate(javelinPrefab, transform.position + Vector3.forward, transform.rotation, transform);
        javelin.GetComponent<Rigidbody>().velocity = Vector3.forward * throwStrength;
        javelin.transform.Rotate(new Vector3(90, 0, 0));
    }

    void Update()
    {
        //PRIMITIVE CHECK; REVISE LATER
        if (Input.GetKey(KeyCode.Space))
        {
            CreateJavelin();
        }
    }
}
