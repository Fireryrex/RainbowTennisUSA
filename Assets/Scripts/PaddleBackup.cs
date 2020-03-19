using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBackup : MonoBehaviour
{
    public bool player2 = false;
    //public bool mouseControl = false;
    //public bool mouseMovement = false;
    public float speed = 40f;
    public float verticalRange = 20f;
    [SerializeField] float zDepth = 0f;
    Rigidbody rb;
    float targetPos;
    Vector3 targetWorldPos;
    float maxHeight;
    float minHeight;
    Vector3 startPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHeight = transform.position.y + verticalRange;
        minHeight = transform.position.y - verticalRange;
        startPos = transform.position;
    }
    void Update()
    {

        transform.position = new Vector3(startPos.x,transform.position.y,startPos.z);
        if(player2 == false)
        {
            targetWorldPos = GetInputControl("Vertical1");
        }
        else
        {
            targetWorldPos = GetInputControl("Vertical2");
        }
        
    }
    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        if((currentPos.y < targetWorldPos.y & currentPos.y < maxHeight) || (currentPos.y > targetWorldPos.y & currentPos.y > minHeight))
        {
            if(targetWorldPos.y > maxHeight)
            {
                targetWorldPos.y = maxHeight;
            }
            else if(targetWorldPos.y < minHeight)
            {
                targetWorldPos.y = minHeight;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, speed * Time.fixedDeltaTime);
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
        yPos.y += Input.GetAxisRaw(name) * speed;
        return yPos;
    }

    public void widen(float widenSize)
    {

    }
}
