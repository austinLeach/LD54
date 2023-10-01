using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class GlobalVariables
{

    public static float timeInAudio = 0f;
    public static bool beenBumped = false;
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

    public static void Bump(Rigidbody rb, Collider other, AudioSource bumpSource, AudioClip softBump, AudioClip hardBump)
    {
        float baseBumpForce = 40f;
        
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();

        float colliderForce = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z);
        float otherForce = Mathf.Abs(otherRb.velocity.x) + Mathf.Abs(otherRb.velocity.z);


        float TotalCollisionForce = colliderForce + otherForce;

        float bumpForce = baseBumpForce * TotalCollisionForce;

        AudioClip audio = softBump;
        if (bumpForce > 300f)
        {
            audio = hardBump;
        }
        if (bumpForce > 500f)
        {
            bumpForce = 500f;
            
        }
        if (otherForce > colliderForce)
        {
            bumpForce = 250f;
        }
        bumpSource.PlayOneShot(audio);
        otherRb.AddExplosionForce(Mathf.Max(250f, bumpForce), rb.GetComponent<Collider>().ClosestPointOnBounds(rb.GetComponent<Transform>().transform.position), 5);
        return;
    }
}
