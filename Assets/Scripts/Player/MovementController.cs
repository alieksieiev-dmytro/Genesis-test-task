using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward();
        HandleRotate();
    }

    private void MoveForward()
    {
        var direction = rb.rotation * Vector3.forward;
        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
    }

    private void HandleRotate()
    {
        if (Input.GetMouseButton(0))
        {
            var rotationAxis = new Vector3(0, Input.GetAxis("Mouse X"));
            var r = rotationAxis * (rotationSpeed * Time.deltaTime);
            transform.Rotate(r);
        }
    }
}
