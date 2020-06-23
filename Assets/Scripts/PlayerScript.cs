using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  
    
    Rigidbody rb;
    
    [Header("Player Perameters")]
    public float topSpeed;
    public float acceleration;
    public float deceleration;
    [Range(1, 10)]
    public float sideSpeed;
    public float xLaneLimit;
    public float jumpForce;

    [Header("Speed Boost Perameters")]
    public float speedBoost;
    public float speedBoostAcceleration;
    public float speedBoostDeceleration;
    public float speedBoostTime;
    
    [Range(1,50)]
    public float moveSensitivity = 20;


    //Private Variables
    bool isjumping;
    float xPosition;
    public float forwardSpeed;
    float tmpSpeedBostTime = 0;


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
        if (RefHolder.instance.playerController.ProcessedTap && isjumping != true)
        {
            //Debug.Log("took Input");
            forwardSpeed += acceleration;
            if(forwardSpeed > topSpeed)
            {
                forwardSpeed -= 1f;
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
            if (isjumping)
            {
                isjumping = false;
                //Debug.LogError("ground colliding");
                SpeedBooster();
            }
            
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
        else if (other.CompareTag("EndRaceTrigger"))
        {
            RefHolder.instance.gameplay.endGame();
            tmpSpeedBostTime = 0;
        }
        else if (other.CompareTag("StartTileDeleteTrigger"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }

    private void Jump()
    {
        isjumping = true;
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
    }
   

    private void SpeedBooster()
    {
        if(tmpSpeedBostTime <= 0)
        {
            tmpSpeedBostTime = speedBoostTime;
            topSpeed += speedBoost;
            acceleration += speedBoostAcceleration;
            deceleration += speedBoostDeceleration;
            StartCoroutine(speedBoosCor());
        }
        else
        {
            tmpSpeedBostTime = speedBoostTime;
        }
    }
    IEnumerator speedBoosCor()
    {
        while(tmpSpeedBostTime > 0)
        {
            yield return new WaitForSeconds(0.1f);
            tmpSpeedBostTime -= 0.1f;
        }
        topSpeed -= speedBoost;
        acceleration -= speedBoostAcceleration;
        deceleration -= speedBoostDeceleration;
    }
}
