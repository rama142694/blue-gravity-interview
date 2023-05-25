using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _cameraOffset;

    private void Update()
    {
        transform.position = _target.transform.position + _cameraOffset;
    }
}
