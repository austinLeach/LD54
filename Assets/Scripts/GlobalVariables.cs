using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class GlobalVariables
{

    public static float timeInAudio = 0f;
    public static bool beenBumped = false;
    public static string[] factList = new string[] {
        "Chickens and ostriches are the closest modern relatives to the Tyrannosaurus rex",
        "Baby hoatzins have tiny claws on their wings",
        "Crows and ravens are extremely intelligent",
        "Pigeons can recognize human faces",
        "Ospreys carry their prey a specific way to be more aerodynamic",
        "Parasitic jaegers gather food by stealing it directly from the mouths of other birds",
        "The average man would have to eat around 285 pounds of meat per day to maintain your weight if you had the metabolism of a hummingbird",
        "Bearded vultures are the only birds to dye their plumage on purpose",
        "The Flamingo can eat only when its head is upside down",
        "A chicken with dark earlobes will produce brown eggs and a chicken with white earlobes will produce white eggs"
    }; 
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
        if (bumpForce > 350f)
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
