using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;
    private int waypointIndex = 0;


    void Start()
    {
        target = Waypoints.points[waypointIndex++];
    }

    void Update()
    {
        if (waypointIndex >= Waypoints.points.Length+1)
        {
            Destroy(gameObject);
        }
        else if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            // snap to target and update target
            transform.position = target.position;
            try
            {
                target = Waypoints.points[waypointIndex++];
            }
            catch
            {
                return;
            }
        }
        else
        {
            // get direction and move in that direction
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}
