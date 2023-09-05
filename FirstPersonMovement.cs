using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    //Movement Values
    public Vector3 direction; //The player's direction at any given time
    public float speed; //The player's speed at any given time

    public Rigidbody rb; //Player's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // All physics calculations happen in FixedUpdate
    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //make world direction into local direction
        Vector3 localDirection = transform.TransformDirection(direction);
        //move using physics
        rb.MovePosition(rb.position + (direction * speed * Time.deltaTime));
    }

    // OnPlayerMode event handler
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y components corresponding to the player's WASD and arrow inputs
        // Both components are in the range [-1, 1]
        Vector2 inputVector = value.Get<Vector2>();
        direction.x = inputVector.x;
        direction.z = inputVector.y;

    }
}

