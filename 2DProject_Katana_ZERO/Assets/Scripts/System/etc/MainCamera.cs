using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _center;
    [SerializeField]
    private Vector2 _size;

    private float _cameraZOffset = -10f;
    private float _height;
    private float _width;

    private void Awake()
    {
        _height = Camera.main.orthographicSize;
        _width = _height * Screen.width / Screen.height;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp( transform.position, _targetTransform.position, Time.deltaTime * _speed );

        float lx = _size.x * 0.5f - _width;
        float clampX = Mathf.Clamp( transform.position.x, -lx + _center.x, lx + _center.x );

        float ly = _size.y * 0.5f - _height;
        float clampY = Mathf.Clamp( transform.position.y, -ly + _center.y, ly + _center.y );

        transform.position = new Vector3( clampX, clampY, _cameraZOffset );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube( _center, _size );
    }

}
