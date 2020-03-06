using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControls : MonoBehaviour
{
    public bool iControl = false;
    public bool mouseControl = false;
    public float speed = 10f;
    public float verticalRange = 2f;
    Rigidbody rb;
    float targetPos;
    float maxHeight;
    float minHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHeight = transform.position.y + verticalRange;
        minHeight = transform.position.y - verticalRange;
    }
    void Update()
    {
        if(mouseControl)
        {
            targetPos = GetMouseWorldPos(0f).y;
        }
        else
        {
            targetPos = GetInputControl();
        }
    }
    void FixedUpdate()
    {
        if(iControl)
        {
            Vector3 currentPos = transform.position;
            if(currentPos.y < targetPos - speed*1.01f & currentPos.y < maxHeight)
            {
                currentPos.y += speed;// * Time.fixedDeltaTime;
                rb.position = currentPos;
            }
            else if(currentPos.y > targetPos + speed*1.01f & currentPos.y > minHeight)
            {
                currentPos.y -= speed;// * Time.fixedDeltaTime;
                rb.position = currentPos;
            }
        }
    }
    Vector3 GetMouseWorldPos(float z)
    {
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    float GetInputControl()
    {
        float yPos = transform.position.y;
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            yPos += speed*1.02f;
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {
            yPos -= speed*1.02f;
        }
        return yPos;
    }
}
