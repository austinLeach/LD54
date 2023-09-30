using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 playerVelocity, testDirection;
    private Vector2 lastInput, lastInputFr;
    private bool isGrounded, hasLastInputFr = false;
    public float speed = 5f;
    public float gravity = -9.8f;

    public bool hasCollided = false;
    public float collisionLockoutTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;
        GlobalVariables.Timer(ref hasCollided, ref collisionLockoutTime);
        if (hasCollided)
        {
            if (!hasLastInputFr)
            {
                lastInputFr = lastInput;
                hasLastInputFr = true;
            }

            testDirection = Vector3.zero;
            // x and y are values from -1, 1
            testDirection.x = lastInputFr.x * -1;
            testDirection.z = lastInputFr.y * -1;
            rb.AddForce(testDirection * 1000 * Time.deltaTime);
        }
    }

    public void getLastInput(Vector2 input)
    {
        lastInput = input;
    }

    // recieves input from InputManager.cs and applies it to character controller
    public void ProcessMove(Vector2 input) 
    {
        if (hasCollided)
        {
            hasLastInputFr = true;
            return;
        } 
        
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0) 
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            hasCollided = true;
            collisionLockoutTime = 1f;
            other.gameObject.GetComponent<Enemy>().CollidedWithPlayer(lastInput);
        }
        
    }
}
