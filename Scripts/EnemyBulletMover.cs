﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMover : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
    }
}