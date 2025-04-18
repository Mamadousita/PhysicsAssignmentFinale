using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBarKiller : MonoBehaviour
{
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDir = (collision.transform.position - transform.position).normalized;
                rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            }

            // Optionnel : tuer le joueur ici
            // collision.gameObject.GetComponent<PlayerHealth>().Kill();
        }
    }
}
