using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlate : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] LineRenderer _rope;

    private void Start()
    {
       // _rope.gameObject.SetActive(false);
    }

    public void Drop()
    {

    }
}
