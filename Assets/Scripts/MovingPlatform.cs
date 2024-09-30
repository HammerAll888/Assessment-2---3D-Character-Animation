using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float speed = 2f;
    public float moveDistance = 5f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMoving = false;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + moveDirection.normalized * moveDistance;
    }

    private void Update()
    {
        if(isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);

            if(transform.position == endPos)
            {
                Vector3 temp = startPos;
                startPos = endPos;
                endPos = temp;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isMoving = false;
        }
    }
}