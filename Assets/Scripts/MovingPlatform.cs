using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Variables for the platform
    public Vector3 moveDirection = Vector3.forward; //The Direciton the platform will move in
    public float speed = 2f; //The speed the platform will go
    public float moveDistance = 5f; //How far the platform will move from the start position

    //Will get the start and end positions of the platform
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMoving = false; //Will tell the computer if the platform is moving

    private void Start()
    {
        startPos = transform.position; //Will get the current position of the platform
        endPos = startPos + moveDirection.normalized * moveDistance; //Will calculate the end position depending on the direction and distance
    }

    private void Update()
    {
        //Will dicitate when the platform is moving
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

    //Will detect when the Player enters the box collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    //Will detect when the Player exits the box collider
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isMoving = false;
        }
    }
}