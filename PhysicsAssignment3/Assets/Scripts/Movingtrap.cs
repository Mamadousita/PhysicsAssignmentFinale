using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingtrap : MonoBehaviour
{
    public float forwardDistance = 3f;
    public float backwardDistance = 2f;
    public float speed = 2f;
    public Vector3 moveDirection = Vector3.forward;

    private Vector3 startPos;
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    void Start()
    {
        startPos = transform.position;

       
        pointA = startPos - moveDirection.normalized * backwardDistance;
        pointB = startPos + moveDirection.normalized * forwardDistance;

        target = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (pc != null && rb != null)
            {
               
                pc.SetControl(false);

               
                Vector3 pushDir = (collision.transform.position - transform.position).normalized;
                rb.AddForce(pushDir * 10f, ForceMode.Acceleration);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.SetControl(true);
            }
        }
    }
}
