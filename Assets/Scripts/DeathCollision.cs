using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponent<Enemy>().Died();
        }
        catch { }
        if (other.gameObject.tag == "Player")
        {
            canvas = GameObject.Find("Canvas");
            canvas.GetComponent<WinScreen>().ShowLoseScreen();
            try
            {
                other.GetComponent<PlayerMotor>().StopMovement();
            }
            catch { }
        }
    }
}
