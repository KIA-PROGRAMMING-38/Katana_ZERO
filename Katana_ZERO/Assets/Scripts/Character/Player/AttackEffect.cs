using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] private Transform _targetPos;
    [SerializeField] private Transform _collisionPos;
    private PlayerData _data;
    private PlayerController _controller;

    public SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        _data = GetComponentInParent<PlayerData>();
        _controller = GetComponentInParent<PlayerController>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionStay( Collision collision )
    {
        
    }

    private void OnEnable()
    {
        _data.AttackAngle = Mathf.Atan2
            ( _data.cursorDirection.y, _data.cursorDirection.x ) * Mathf.Rad2Deg;

        if ( _data.cursorDirection.x > 0f )
        {
            transform.localRotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.localRotation = Quaternion.Euler( 180f, 180f, -_data.AttackAngle );
        }
    }
}
