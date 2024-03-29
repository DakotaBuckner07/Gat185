﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentCamera : MonoBehaviour
{
    public Transform targetTransform;
    [Range(0, 0.5f)] public float sensitivity = 0.1f;
    [Range(1, 10)] public float rate = 5;

    Vector3 direction;
    float distance = 1;

    void Start()
    {
        direction = transform.position - targetTransform.position;
    }

    void Update()
    {
        distance -= Input.mouseScrollDelta.y * sensitivity;
        distance = Mathf.Clamp(distance, 0.2f, 1.0f);

        Vector3 target = targetTransform.position + direction * distance;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * rate);
    }
}
