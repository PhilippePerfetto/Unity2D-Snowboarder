using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
// gave up on course 37 to detect head on ground
    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("...");

        if (other.tag == "Ground")
        {
            Debug.Log("Hit my head !");
        }
    }
}
