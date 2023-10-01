using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool Timer(ref bool isChanging, ref float timer) {
      if (isChanging)
      {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
          isChanging = false;
        }
      }
      return isChanging;
    }

    public static void Bump(Rigidbody rb, Collider other)
    {
        float baseBumpForce = 40f;
        
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();

        float colliderForce = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z);
        float otherForce = Mathf.Abs(otherRb.velocity.x) + Mathf.Abs(otherRb.velocity.z);


        float TotalCollisionForce = colliderForce + otherForce;

        float bumpForce = baseBumpForce * TotalCollisionForce;
        if (bumpForce > 500f)
        {
            bumpForce = 500f;
        }
        if (otherForce > colliderForce)
        {
            bumpForce = 250f;
        }
        otherRb.AddExplosionForce(Mathf.Max(250f, bumpForce), rb.GetComponent<Collider>().ClosestPointOnBounds(rb.GetComponent<Transform>().transform.position), 5);
        return;
    }
}
