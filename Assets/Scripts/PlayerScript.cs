using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  
    
    Rigidbody rb;
    
    public float speed;
    public float sideSpeed;
    public float xLaneMaxValue;
    public float jumpForce;
    public bool isjumping;
    public float moveDisplacement;
    public float moveDisplacementSpeed;

    private float preXTouchPosition;
    private float postXTouchPosition;

    public float xPosition;

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
        
        this.transform.position += this.transform.forward  * Time.deltaTime * speed;
        SideMovement();
        if (xPosition > -xLaneMaxValue && xPosition < xLaneMaxValue)
        {
            this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, xPosition, Time.deltaTime * sideSpeed), this.transform.position.y, this.transform.position.z);
        }

        

    }


    void SideMovement()
    {
        if (PlayerController.instance.tap)
        {
            
            preXTouchPosition = PlayerController.instance.touchPosition.x;
            
            if(preXTouchPosition != postXTouchPosition && postXTouchPosition!= 0)
            {
                moveDisplacement = postXTouchPosition - preXTouchPosition;
                
                if(xPosition > -xLaneMaxValue && xPosition < xLaneMaxValue)
                {
                    xPosition += moveDisplacement * moveDisplacementSpeed;
                    if (xPosition <= -xLaneMaxValue)
                    {
                        xPosition = -(xLaneMaxValue-0.01f);
                    }
                    else if (xPosition >= xLaneMaxValue)
                    {
                        xPosition = (xLaneMaxValue - 0.01f);
                    }
                }
 

            }

            postXTouchPosition = preXTouchPosition;
            //moveDisplacement = 0;
        }
        else
        {
            preXTouchPosition = 0;
            postXTouchPosition = 0;
            //moveDisplacement = 0;
        }
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

    private void Jump()
    {
        isjumping = true;
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
    }
   
}
