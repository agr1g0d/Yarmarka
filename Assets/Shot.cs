using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody.isKinematic = true;
    }

    public void Shoot(Vector3 force)
    {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(force, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
