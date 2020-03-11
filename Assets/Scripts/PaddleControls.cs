using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControls : MonoBehaviour
{
    public bool iControl = false;
    public bool mouseControl = false;
    public bool mouseMovement = false;
    public float speed = 10f;
    public float verticalRange = 2f;
    Rigidbody rb;
    float targetPos;
    Vector3 targetWorldPos;
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
            targetWorldPos = transform.position;
            targetWorldPos.y = GetMouseWorldPos(0f).y;
            if(mouseMovement)
            {
                targetWorldPos = GetInputControl("Mouse Y");
            }
        }
        else
        {
            targetWorldPos = GetInputControl("Vertical");
        }
    }
    void FixedUpdate()
    {
        if(iControl)
        {
            Vector3 currentPos = transform.position;
            if((currentPos.y < targetWorldPos.y & currentPos.y < maxHeight) || (currentPos.y > targetWorldPos.y & currentPos.y > minHeight))
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, speed * Time.fixedDeltaTime);
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

    Vector3 GetInputControl(string name)
    {
        Vector3 yPos = transform.position;
        yPos.y += Input.GetAxisRaw(name);
        return yPos;
    }
}
