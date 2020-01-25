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
    [SerializeField]
    private float accelTime;
    [SerializeField]
    private float decelTime;


    public int playerNum;
    // Start is called before the first frame update
    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void MovementUpdate()
    {
        //General Movement (Keyboard)
        input.x = Input.GetAxisRaw("HorizontalK_P" + playerNum);
        input.z = Input.GetAxisRaw("VerticalK_P" + playerNum);






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
        float acceleration = maxSpeed / accelTime * Time.fixedDeltaTime;
        float deceleration = maxSpeed / decelTime * Time.fixedDeltaTime;

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

        Vector3 velocity = new Vector3(lastRecordedInput.x * inputSpeed.x, 0, lastRecordedInput.z * inputSpeed.z);

        rigBod.velocity = velocity.normalized * velocity.magnitude * maxSpeed;
    }



}
