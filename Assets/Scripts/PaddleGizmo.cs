using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleGizmo : MonoBehaviour
{
    public float size = 2f;
    public Color color = Color.red;
    void OnDrawGizmos()
    {
        DrawGizmoRail(size,color, transform.position);
        DrawGizmoRail(-size,color, transform.position);
    }
    void DrawGizmoRail(float size, Color color, Vector3 initialPos)
    {
        Vector3 target = initialPos;
        target.y += size;
        Gizmos.color = color;
        Gizmos.DrawLine(initialPos, target);
    }
}