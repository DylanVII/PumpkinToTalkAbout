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


    public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayerMovementUpdate()
    {
        //General Movement (Keyboard)
        input.x = Input.GetAxisRaw("HorizontalK_P" + playerNum);
        input.y = Input.GetAxisRaw("VerticalK_P" + playerNum);






        if (input.x != 0)
        {
            lastRecordedInput.x = input.x;
        }
        if (input.y != 0)
        {
            lastRecordedInput.y = input.y;
        }


    }


    public void PlayerMovementFixedUpdate()
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
        if (input.y != 0)
        {
            inputSpeed.y = Mathf.Clamp(inputSpeed.y + acceleration, 0, 1);
        }
        else
        {
            inputSpeed.y = Mathf.Clamp(inputSpeed.y - deceleration, 0, 1);
        }

        Vector2 velocity = new Vector2(lastRecordedInput.x * inputSpeed.x, lastRecordedInput.y * inputSpeed.y);

        rigBod.velocity = velocity.normalized * velocity.magnitude * maxSpeed;
    }



}
