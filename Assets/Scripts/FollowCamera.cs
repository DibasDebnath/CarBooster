using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeedX = 0.125f;
    public float smoothSpeedY = 0.125f;
    public float smoothSpeedZ = 0.125f;
    public Vector3 offset;
    public Vector3 LookAtOffset;

    public bool following = false;

    public bool activated = false;

    Vector3 desiredPosition;
    Vector3 smoothedPosition;
    void FixedUpdate()
    {
        if (activated)
        {
            if (following)
            {
                desiredPosition = target.position + offset;
                //smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);




                smoothedPosition = new Vector3(
                    Mathf.Lerp(this.transform.position.x, desiredPosition.x, Time.deltaTime * smoothSpeedX),
                    Mathf.Lerp(this.transform.position.y, desiredPosition.y, Time.deltaTime * smoothSpeedY),
                    Mathf.Lerp(this.transform.position.z, desiredPosition.z, Time.deltaTime * smoothSpeedZ));



                transform.position = smoothedPosition;

                transform.LookAt(target);
                transform.rotation *= Quaternion.Euler(LookAtOffset);
            }
        }
        
        
    }
}
