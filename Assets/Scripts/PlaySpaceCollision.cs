using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpaceCollision : MonoBehaviour
{
    public TargetLogic targetLogic;
    private void Awake()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.useGravity = true;
        targetLogic.RemoveTarget(other.gameObject.tag);
    }
}