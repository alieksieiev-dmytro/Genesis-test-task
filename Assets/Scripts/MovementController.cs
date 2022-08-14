using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 1f;
    private Vector2 rotation;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetMouseButton(0))
        {
            // rotation.x += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            // var target = Quaternion.Euler(0, rotation.x, 0);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
            var rotationAxis = new Vector3(0, Input.GetAxis("Mouse X"));
            var r = rotationAxis * (rotationSpeed * Time.deltaTime);
            transform.Rotate(r);
        }
    }
}
