using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyspickup : MonoBehaviour
{
  
   private void OnTriggerEnter(Collider other)
    {
         Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            PlayerCheckpoint pc = other.GetComponent<PlayerCheckpoint>();
            if (pc != null)
            {
                pc.SetCheckpoint(transform.position);
                pc.AddKey();
                Destroy(gameObject);
            }
        }
    }
}
