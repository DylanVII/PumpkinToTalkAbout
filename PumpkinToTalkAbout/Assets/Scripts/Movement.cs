using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed;
    public Vector2 input;

    private Vector2 lastRecordedInput;
    private Vector2 inputSpeed = Vector2.zero;
    private Rigidbody2D rigBod;
    [SerializeField]
    private float accelTime;
    [SerializeField]
    private float decelTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
