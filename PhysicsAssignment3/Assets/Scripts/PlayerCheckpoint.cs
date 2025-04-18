using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
     private Vector3 lastCheckpoint;
    public int keysCollected = 0;

    public float maxFallDistance = 10f; 
    private float lastSafeY;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastCheckpoint = transform.position;
        lastSafeY = transform.position.y;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint + Vector3.up * 1f;
        lastSafeY = lastCheckpoint.y; 
    }

    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Key collected: " + keysCollected);
    }

    void Update()
    {
       
        if (transform.position.y < lastSafeY - maxFallDistance)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        transform.position = lastCheckpoint;
    }
}
