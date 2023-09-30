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
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("herererer");
        if (other.gameObject.tag == "Player")
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            otherRb.AddExplosionForce(300f, GetComponent<Collider>().ClosestPointOnBounds(transform.position), 5);
        }
        
    }
}
