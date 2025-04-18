using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcySlideBoost : MonoBehaviour
{
    public float slideForce = 10f;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc != null && !pc.isJumping)
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 slideDirection = -transform.forward;
                rb.AddForce(slideDirection.normalized * slideForce, ForceMode.Acceleration);
            }
        }
    }
}
