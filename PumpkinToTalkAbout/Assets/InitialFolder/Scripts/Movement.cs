using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator anim;
    Quaternion targetRot;

    float angle;

    [SerializeField]
    private float maxSpeed;
    public Vector3 input;
    public float turnSpeed;
    
    private Vector3 lastRecordedInput;
    private Vector3 inputSpeed = Vector2.zero;
    private Rigidbody rigBod;
    private Rigidbody otherRigBod;
    [SerializeField]
    private float accelTime;
    [SerializeField]
    private float decelTime;

    bool pickedUpPumpkin = true; 

    public int playerNum;
    bool usingController = true;
    // Start is called before the first frame update
    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // stop and face current direction when input is absent in x or z-axis
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.z) < 1) return;
        
        CalculateDirection();
        Rotate();
    }

    // Update is called once per frame
    public void MovementUpdate()
    {

        //Setting the player number to their controls (keyboard)
        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") && playerNum == 1)
            usingController = false;

        if (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("left") || Input.GetKeyDown("right") && playerNum == 2)
            usingController = false;


        if (!usingController && playerNum < 3)
        {
            //General Movement (Keyboard)
            input.x = Input.GetAxisRaw("HorizontalK_P" + playerNum);
            input.z = Input.GetAxisRaw("VerticalK_P" + playerNum);
        }

        else
        {
            //General Movement (Controller)
            input.x = Input.GetAxisRaw("Horizontal_P" + playerNum);
            input.y = Input.GetAxisRaw("Vertical_P" + playerNum);

            //Quadrant Input (Controller)
            input.x = Input.GetAxis("Horizontal_P" + playerNum);
            input.y = Input.GetAxis("Vertical_P" + playerNum);
        }




        //Used to record the last input
        if (input.x != 0)
        {
            lastRecordedInput.x = input.x;
        }
        if (input.z != 0)
        {
            lastRecordedInput.z = input.z;
        }


    }


    public void MovementFixedUpdate()
    {
        //Formulas for creating deceleration and acceleration
        float acceleration = maxSpeed / accelTime * Time.fixedDeltaTime;
        float deceleration = maxSpeed / decelTime * Time.fixedDeltaTime;


        //Movement calculations 
        if (input.x != 0)
        {
            // if farmer moves, play running animation
            anim.SetBool("isRunning", true);
            inputSpeed.x = Mathf.Clamp(inputSpeed.x + acceleration, 0, 1);
        }
        else
        {
            // if farmer doesn't move, play idle animation
             anim.SetBool("isRunning", false);
            inputSpeed.x = Mathf.Clamp(inputSpeed.x - deceleration, 0, 1);
        }
        if (input.z != 0)
        {
            // if farmer moves, play running animation
            anim.SetBool("isRunning", true);
            inputSpeed.z = Mathf.Clamp(inputSpeed.z + acceleration, 0, 1);
        }
        else
        {
           // anim.SetBool("isRunning", false);
            inputSpeed.z = Mathf.Clamp(inputSpeed.z - deceleration, 0, 1);
        }
        //Final movement calulations
        Vector3 velocity = new Vector3(lastRecordedInput.x * inputSpeed.x, 0, lastRecordedInput.z * inputSpeed.z);

        rigBod.velocity = velocity.normalized * velocity.magnitude * maxSpeed;
    }

    // Calculate the math in the angle of movement directions
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.z);
        angle = Mathf.Rad2Deg * angle;
    }

    // Calculate target rotation based on the angle that was calculated
    // Smoothed the rotation
    void Rotate()
    {
        targetRot = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
    }


}
