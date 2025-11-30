using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ControlSettings
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode run = KeyCode.LeftShift;
}

public class PlayerBounds : MonoBehaviour
{
    public ControlSettings controls;  // Settings for control keys
    public float moveSpeed = 5f;      // Speed of the player movement
    public float runSpeed = 8f;       // Running speed
    private Vector3 moveDirection;    // The current movement direction

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleInput()
    {
        float horizontal = 0;
        float vertical = 0;

        // Check input for movement
        if (Input.GetKey(controls.moveUp)) vertical = 1;
        if (Input.GetKey(controls.moveDown)) vertical = -1;
        if (Input.GetKey(controls.moveLeft)) horizontal = -1;
        if (Input.GetKey(controls.moveRight)) horizontal = 1;

        // Check for running
        float speed = Input.GetKey(controls.run) ? runSpeed : moveSpeed;

        // Calculate movement direction
        moveDirection = new Vector3(horizontal, 0, vertical).normalized * speed;
    }

    private void MovePlayer()
    {
        // Move the player based on the moveDirection
        transform.position += moveDirection * Time.deltaTime;
    }
}

