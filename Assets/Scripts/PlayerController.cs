using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public int direction;
    public float moveSpeed;
    public Vector2 inputValue;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        Movement_Action();
    }

    void Movement_1()
    {
        if (Input.GetKey(KeyCode.A))
            direction = -1;
        else if (Input.GetKey(KeyCode.D))
            direction = 1;
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            direction = 0;

        rigidBody.velocity = new Vector2(direction * moveSpeed, rigidBody.velocity.y);
    }

    void MovementInput()
    {
        inputValue = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, rigidBody.velocity.y);
        rigidBody.velocity = inputValue;
    }
    void Movement_Action()
    {
        rigidBody.velocity = inputValue;
    }
}
