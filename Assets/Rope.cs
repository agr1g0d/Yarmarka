using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public LineRenderer _rope;
    public float ShotPower = 10;
    [SerializeField] Transform _slingshot;
    [SerializeField] Transform _start;

    private bool _startedLaunch;


    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody != null 
            && other.attachedRigidbody.TryGetComponent(out Shot shot)
            && !shot.Released)
        {
            if (shot.Launched && !_startedLaunch)
            {
                StartCoroutine(Launch(shot));
                _startedLaunch = true;
            }
            else if (!shot.Launched)
            {
                _startedLaunch = false;
                transform.position = shot.transform.position;
                _rope.SetPosition(1, transform.localPosition);
            }
        }
    }

    IEnumerator Launch(Shot shot)
    {
        Vector3 launchPosition = transform.position;
        float timer = 0;
        shot.Force = CalculateForce();
        print(shot.Force);
        while(transform.position != _start.position)
        {
            transform.position = Vector3.Lerp(launchPosition, _start.position, timer * ShotPower);
            timer += Time.deltaTime;
            _rope.SetPosition(1, transform.localPosition);
            yield return null;
        }
        shot.Released = true;
    }

    public Vector3 CalculateForce()
    {
        return _start.position - transform.position;
    }
}
