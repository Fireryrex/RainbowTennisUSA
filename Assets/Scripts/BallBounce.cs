using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private bool test = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(test)
        {
            if(Input.GetKeyDown("space"))
            {
                SetBoth(new Vector3(1f,1f,0f), 10f);
            }
        }
    }
    public float GetSpeed() //returns speed of ball
    {
        return rb.velocity.magnitude;
    }
    public Vector3 GetDirection() //returns direction of ball
    {
        return rb.velocity.normalized;
    }

    public void SetSpeed(float speed) //set speed of ball
    {
        rb.velocity = GetDirection() * speed;
    }

    public void SetDirection(Vector3 direction) //set direction(normalized) of ball
    {
        rb.velocity = direction.normalized * GetSpeed();
    }

    public void SetBoth(Vector3 direction, float speed) //set both direction(normalized) and speed
    {
        rb.velocity = direction.normalized * speed;
    }

    public void AddForce(float force) //add force in direction of ball
    {
        rb.AddForce(GetDirection()*force, ForceMode.Impulse);
    }

    public void AddDirForce(Vector3 direction, float force) //add force in a direction
    {
        rb.AddForce(direction.normalized*force, ForceMode.Impulse);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
