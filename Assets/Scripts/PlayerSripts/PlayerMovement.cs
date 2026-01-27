using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
public float maxDrag = 4f;
public float power = 8f;
public Rigidbody2D rb;
public LineRenderer lr;
Vector3 dragStartPos;
bool dragging = false;
    void Update()
    {
        if(dragging == true)
        {
            Vector3 draggingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggingPosition.z = 0;

            Vector3 finalDragPosition = dragStartPos - draggingPosition;

            lr.positionCount = 2;
            lr.SetPosition(1, finalDragPosition);
        
        }
        if (dragging == false && Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.z = 0;
            dragging = true;
            lr.positionCount = 1;
            lr.SetPosition(0, dragStartPos);
        }
        if(Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;
            dragging = false;
            Vector3 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 force = dragStartPos - dragEndPos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag)* power;

            if (rb.linearVelocity.magnitude >= 0 && rb.linearVelocity.magnitude <= 0.5f)
            {
                rb.AddForce(clampedForce, ForceMode2D.Impulse);
            }
        }

    }
}
