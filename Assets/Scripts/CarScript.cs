using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    Vector3 oldPos;
    Vector3 newPos;
    Rigidbody rb;
    float speed = 50f;

    public float forwardvelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        oldPos = this.transform.position;
        newPos = oldPos;
    }

    // Update is called once per frame
    void Update()
    {
        //newPos = oldPos + new Vector3(0, 0, 1);
        //transform.position = Vector3.Lerp(transform.position, newPos, 0.1f * Time.deltaTime);
        //oldPos = newPos;
        if (forwardvelocity < 100)
        {
            rb.AddForce(0, 0, speed * 1);
        }
        forwardvelocity = rb.velocity.z;
        
    }
}
