﻿using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform plane;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 desiredPosition = plane.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(plane);
    }
}
