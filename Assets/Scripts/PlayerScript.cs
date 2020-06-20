using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  
    
    Rigidbody rb;
    
    public float topSpeed;
    public float acceleration;
    public float deceleration;
    public float sideSpeed;
    public float xLaneLimit;
    public float jumpForce;
    [Range(1,20)]
    public float moveSensitivity = 10;


    //Private Variables
    bool isjumping;
    float xPosition;
    float forwardSpeed;


    //Public Calls to Variables
    public bool Isjumping { get => isjumping; set => isjumping = value; }
    public float XPosition { get => xPosition; set => xPosition = value; }

    //public float forwardvelocity;
    // Start is called before the first frame update
    void Start()
    {
        isjumping = false;
        rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ForwardMovement();
        SideMovement();

        

    }


    void ForwardMovement()
    {
        if (RefHolder.instance.playerController.Tap && isjumping != true)
        {
            forwardSpeed += acceleration;
            if(forwardSpeed > topSpeed)
            {
                forwardSpeed = topSpeed;
            }
        }
        else if(!isjumping)
        {
            forwardSpeed -= deceleration;
            if (forwardSpeed < 0)
            {
                forwardSpeed = 0;
            }
        }
        this.transform.position += this.transform.forward * Time.deltaTime * forwardSpeed;
    }

    void SideMovement()
    {
        if (RefHolder.instance.playerController.Move)
        {                         
            if(xPosition > -xLaneLimit && xPosition < xLaneLimit)
            {
                //MoveValue Set
                xPosition -= RefHolder.instance.playerController.MoveDisplacement * moveSensitivity;
                //Check Limit
                if (xPosition <= -xLaneLimit)
                {
                    xPosition = -(xLaneLimit - 0.01f);
                }
                else if (xPosition >= xLaneLimit)
                {
                    xPosition = (xLaneLimit - 0.01f);
                }     
            }
        }
        //Moving
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, xPosition, Time.deltaTime * sideSpeed), this.transform.position.y, this.transform.position.z);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Road"))
        {
            isjumping = false;
        }
        else if (collision.gameObject.CompareTag("Jumper"))
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            RefHolder.instance.levelGenaration.deleteTile();
        }
    }

    private void Jump()
    {
        isjumping = true;
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
    }
   
}
