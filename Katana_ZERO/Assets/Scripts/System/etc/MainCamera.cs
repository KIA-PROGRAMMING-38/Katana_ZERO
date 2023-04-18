using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    private Vector3 _cameraPos;

    [SerializeField]
    private float _offsetY;

    [SerializeField]
    private float _offsetZ;

    private void LateUpdate()
    {
        _cameraPos =
            new Vector3( _targetTransform.position.x, 
            _targetTransform.position.y + _offsetY,
            _targetTransform.position.z + _offsetZ );

        transform.position = _cameraPos;
    }
}
