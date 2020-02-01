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
        Instantiate(javelinPrefab, transform.position + Vector3.up, Quaternion.identity, transform);
    }
}
