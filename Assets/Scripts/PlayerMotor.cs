using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private float speed = 7f;
    public bool hasCollided = false;
    public float collisionLockoutTime = 1f;
    bool gameOver = false;
    public AudioSource audio;
    public AudioSource bumpSource;
    public AudioClip softBump;
    public AudioClip hardBump;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audio.time = GlobalVariables.timeInAudio;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // recieves input from InputManager.cs and applies it to character controller
    public void ProcessMove(Vector2 input) 
    {
        if (gameOver)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            Vector3 moveDirection = transform.right * input.x + transform.forward * input.y;
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GlobalVariables.Bump(rb, other, bumpSource, softBump, hardBump);
        }
    }

    public void StopMovement()
    {
        gameOver = true;
    }
}
