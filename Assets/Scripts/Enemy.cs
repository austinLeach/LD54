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
        targetName = targetLogic.ChooseTarget(this.gameObject.tag);
        target = GameObject.Find(targetName).transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetName == "NULL")
        {
            Debug.Log("TargetNAME IS NULLLFDSFSDF");
            targetName = targetLogic.ChooseTarget(this.gameObject.name);
            target = GameObject.Find(targetName).transform;
        }
        // locked in order to keep enemy from falling over after target is pushed off
        Vector3 lockedTarget = target.position;
        lockedTarget.y = transform.position.y;
        transform.LookAt(lockedTarget);
        Vector3 direction = (target.position - this.transform.position).normalized;
            
        rb.AddForce(direction.normalized *  speed, ForceMode.Acceleration);
        
    }



    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            GlobalVariables.Bump(rb, other);
        }
    }
}
