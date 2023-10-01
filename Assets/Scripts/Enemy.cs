using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Vector2 playerInput;
    public string targetName = string.Empty;
    public Transform target;
    public TargetLogic targetLogic;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(4f, 6f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        targetName = targetLogic.ChooseTarget(this.gameObject.name);
        target = GameObject.Find(targetName).transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetName == "NULL")
        {
            targetName = targetLogic.ChooseTarget(this.gameObject.name);
            target = GameObject.Find(targetName).transform;
        }
        // locked in order to keep enemy from falling over after target is pushed off
        Vector3 lockedTarget = target.position;
        lockedTarget.y = transform.position.y;
        transform.LookAt(lockedTarget);
        transform.Rotate(-90, transform.rotation.y, transform.rotation.z);
        Vector3 direction = (target.position - this.transform.position).normalized;

        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);

    }



    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside on trigger" + other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            GlobalVariables.Bump(rb, other);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("HERERERERERERERERRE");
            GlobalVariables.Bump(rb, other);
        }

    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("HERERERERERERERERRE");
    //        //GlobalVariables.Bump(rb, collision);
    //    }
    //}
}
