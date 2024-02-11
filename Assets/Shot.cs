using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class Shot : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    private Rope _rope = null;
    private XRGrabInteractable _interactable;

    public bool Released;
    public bool Launched;
    public Vector3 Force;

    private void Start()
    {
        _rigidbody.isKinematic = true;
        _interactable = GetComponent<XRGrabInteractable>();
        _interactable.selectExited.AddListener(SelectExitedListener);
    }

    

    private void SelectExitedListener(SelectExitEventArgs arg0)
    {
        if (_rope != null)
        {
            StartCoroutine(Launch());
        }
    }

    IEnumerator Launch()
    {
        transform.SetParent(_rope.transform);
        Launched = true;
        while (!Released)
        {
            yield return null;
        }
        Shoot();
    }

    public void Shoot()
    {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Force * _rope.ShotPower, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rope rope))
        {
            _rope = rope;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
