using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float forwardDistance = 3f;
    public float backwardDistance = 2f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    void Start()
    {
        startPos = transform.position;

        // Déplacement sur l’axe Z
        pointA = startPos - Vector3.forward * backwardDistance;
        pointB = startPos + Vector3.forward * forwardDistance;

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
}
