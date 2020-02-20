using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed;
    public Vector3 input;

    private Vector3 lastRecordedInput;
    private Vector3 inputSpeed = Vector2.zero;
    private Rigidbody rigBod;
    private Rigidbody otherRigBod;
    [SerializeField]
    private float accelTime;
    [SerializeField]
    private float decelTime;

    bool pickedUpPumpkin = false; 

    public int playerNum;
    bool usingController = true;
    // Start is called before the first frame update
    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
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
            inputSpeed.x = Mathf.Clamp(inputSpeed.x + acceleration, 0, 1);
        }
        else
        {
            inputSpeed.x = Mathf.Clamp(inputSpeed.x - deceleration, 0, 1);
        }
        if (input.z != 0)
        {
            inputSpeed.z = Mathf.Clamp(inputSpeed.z + acceleration, 0, 1);
        }
        else
        {
            inputSpeed.z = Mathf.Clamp(inputSpeed.z - deceleration, 0, 1);
        }
        //Final movement calulations
        Vector3 velocity = new Vector3(lastRecordedInput.x * inputSpeed.x, 0, lastRecordedInput.z * inputSpeed.z);

        rigBod.velocity = velocity.normalized * velocity.magnitude * maxSpeed;
    }



}
