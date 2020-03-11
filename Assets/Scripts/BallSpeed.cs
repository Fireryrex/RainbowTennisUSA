using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallBounce))]
public class BallSpeed : MonoBehaviour
{
    BallBounce bb;
    public float speedUp;
    public float speedDown;
    public float minSpeed;
    public float maxSpeed;
    void Awake()
    {
        bb = GetComponent<BallBounce>();
    }
    void OnCollisionExit(Collision other)
    {
        if(other.transform.tag == "Paddle")
        {
            if(bb.GetSpeed() < maxSpeed)
            {
                bb.AddForce(speedUp);
            }
            else
            {
                bb.SetSpeed(maxSpeed);
            }
            
        }
        else
        {
            if(bb.GetSpeed() > minSpeed)
            {
                bb.AddForce(-speedDown);
            }
            else
            {
                bb.SetSpeed(minSpeed);
            }
        }
    }
}
