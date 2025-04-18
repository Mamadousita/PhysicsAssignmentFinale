using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
   public float upwardDistance = 3f;
    public float downwardDistance = 2f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    void Start()
    {
        startPos = transform.position;

        pointA = startPos - Vector3.up * downwardDistance;
        pointB = startPos + Vector3.up * upwardDistance;
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
