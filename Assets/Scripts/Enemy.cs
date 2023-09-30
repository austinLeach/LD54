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
    public float speed = 5f;
    public Vector2 playerInput;
    public Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        Vector3 direction = (target.position - this.transform.position).normalized;
            
        rb.AddForce(direction.normalized *  speed, ForceMode.Acceleration);
        
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
