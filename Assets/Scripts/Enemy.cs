using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class Enemy : MonoBehaviour
{

    public bool hasCollided = false;
    public float collisionLockoutTime = 1f;
    private Rigidbody rb;
    private Vector3 testDirection;
    public float speed = 5f;
    public Vector2 playerInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.Timer(ref hasCollided, ref collisionLockoutTime);
        if (hasCollided)
        {

            testDirection = Vector3.zero;
            // x and y are values from -1, 1
            // currently going off of the objects rotation
            testDirection.x = playerInput.x;
            testDirection.z = playerInput.y;
            rb.AddForce(testDirection*1000*Time.deltaTime);
        }
    }

    public void CollidedWithPlayer(Vector2 input)
    {
        hasCollided = true;
        collisionLockoutTime = 1f;
        playerInput = input;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("herererer");
        if (other.gameObject.tag == "Player")
        {
        }
        
    }
}
