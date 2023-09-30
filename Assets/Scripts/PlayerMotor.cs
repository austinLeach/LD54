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
    public float speed = 500f;

    public bool hasCollided = false;
    public float collisionLockoutTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getLastInput(Vector2 input)
    {
        lastInput = input;
    }

    // recieves input from InputManager.cs and applies it to character controller
    public void ProcessMove(Vector2 input) 
    {   
        Vector3 moveDirection = Vector3.zero;

        moveDirection = transform.right * input.x + transform.forward * input.y;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            otherRb.AddExplosionForce(300f, GetComponent<Collider>().ClosestPointOnBounds(transform.position), 5);
        }
    }
}
