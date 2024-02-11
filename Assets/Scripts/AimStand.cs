using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStand : MonoBehaviour
{
    [SerializeField] const int _platesCount = 3;
    [SerializeField] Transform[] _startPoints = new Transform[_platesCount];
    [SerializeField] Transform[] _endPoints = new Transform[_platesCount];
    [SerializeField] ShootingPlate[] _plates = new ShootingPlate[_platesCount];
    [SerializeField] float _speed;

    private void FixedUpdate()
    {
        for (int i = 0; i < _platesCount; i++)
        {
            _plates[i].transform.position = Vector3.Lerp(_startPoints[i].position, 
                _endPoints[i].position, 
                Mathf.Sin(Time.time * _speed + i * 0.5f) * 0.5f + 0.5f);
        }
    }
}
