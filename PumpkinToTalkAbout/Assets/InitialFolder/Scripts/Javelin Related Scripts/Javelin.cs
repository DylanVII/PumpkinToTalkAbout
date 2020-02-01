using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javelin : MonoBehaviour
{
    public float throwStrength = 10f;

    [SerializeField]
    private GameObject javelinPrefab;

    
    public void ThrowJavelin ()
    {
        Instantiate(javelinPrefab, transform.position + Vector3.up, Quaternion.identity, transform);
    }
}
