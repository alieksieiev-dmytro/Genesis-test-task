using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float destructionDelay;
    
    private bool m_IsGrounded;
    
    public Action OnPickingUp;
    public Action OnDestroy;
    
    private void Update()
    {
        if (m_IsGrounded)
        {
            Rotate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPickingUp?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            m_IsGrounded = true;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}
