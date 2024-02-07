using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] Transform _rightBrace;
    [SerializeField] Transform _leftBrace;
    [SerializeField] Transform _ropeStratching;
    [SerializeField] LineRenderer _rope;
    [SerializeField] float _shotPower;
    [SerializeField] float _lerpMultiplier;
    [SerializeField] float _stratchDivider;
    [SerializeField] Shot _shotPrefab;
    private float _stratchPower;
    private bool _instantiated;
    private Shot _shot;

    private void Update()
    {
        _rope.SetPosition(0, _leftBrace.localPosition);
        _rope.SetPosition(2, _rightBrace.localPosition);

        Vector3 stratching = _ropeStratching.localPosition;
        if (Input.GetMouseButton(0))
        {
            _stratchPower = Mathf.Lerp(_stratchPower, 1, Time.deltaTime * _lerpMultiplier);
            stratching = _ropeStratching.localPosition - Vector3.forward * _stratchPower / _stratchDivider;
            if (!_instantiated)
            {
                _instantiated = true;
                _shot = Instantiate(_shotPrefab, stratching, Quaternion.identity, transform);
            }
        } else
        {
            if (_instantiated)
            {
                _shot.Shoot(transform.forward * _stratchPower * _shotPower);
                _stratchPower = 0;
                _instantiated = false;
                _shot = null;
            }
        }
        if (_instantiated)
        {
            _shot.transform.localPosition = stratching;
        }
        _rope.SetPosition(1, stratching);
    }
}
