using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Camera _camera;
    public float Speed;
    public float Sensivity;

    private void FixedUpdate()
    {
        Vector3 movement = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;

        movement *= Speed;
        _rigidbody.AddForce(movement, ForceMode.VelocityChange);

        Vector3 xRotation = Vector3.up * Input.GetAxis("Mouse X") * Sensivity;
        Vector3 yRotation = -Vector3.right * Input.GetAxis("Mouse Y") * Sensivity;
        

        transform.Rotate(xRotation);
        _camera.transform.Rotate(yRotation);
    }
}
