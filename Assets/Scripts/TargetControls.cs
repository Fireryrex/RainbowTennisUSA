using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControls : MonoBehaviour
{
    void Update()
    {
        Vector3 position = GetMouseWorldPos(0);
        transform.position = position;
    }

    Vector3 GetMouseWorldPos(float z)
    {
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
