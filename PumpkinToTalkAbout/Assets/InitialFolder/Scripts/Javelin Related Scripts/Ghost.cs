using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ghost.cs
 * --------
 * Script required for the Ghost players to function properly.
 * Controls the stunned status when interacting with the Javelin.
 */
public class Ghost : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private new Collider collider;

    public bool canMove = true;

    public float maxStunDuration = 3f;
    public float currentStunDuration;

    public List<string> stunnableTags; //Which tags this object gets stunned on when pulled via pitchfork.

    public _states status;
    public enum _states
    {
        normal,
        stunned,
        grabbed
    }

    [HideInInspector]
    public Transform parentTransform;


    void Start()
    {
        if (!rigidbody && GetComponent<Rigidbody>())
            rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        switch (status)
        {
            case _states.normal:
                //be ok
                break;

            case _states.stunned:
                //be not ok
                Stunned();
                break;

            case _states.grabbed:
                //be pulled by pitchfork
                Grabbed();
                break;
        }
    }



    public void Stunned()
    {
        Debug.Log("Stunned!");

        rigidbody.velocity = new Vector3(0, 0);

        if (canMove)
        {
            canMove = false;
        }

        if (currentStunDuration > 0)
            currentStunDuration -= Time.deltaTime;
        else
        {
            canMove = true;
            status = _states.normal;
        }

    }



    public void Grabbed()
    {

        if (canMove)
        {
            canMove = false;
        }

        if (parentTransform)
        {
            rigidbody.velocity = parentTransform.GetComponent<Rigidbody>().velocity;
            //transform.position = new Vector3(parentTransform.position.x, 
            //                                 transform.position.y, 
            //                                 parentTransform.position.z);
        }
    }




    public void OnCollisionEnter(Collision other)
    {
        if (!stunnableTags.Contains(other.gameObject.tag))
            return;

        if (!canMove)
            status = _states.stunned;
    }
}
