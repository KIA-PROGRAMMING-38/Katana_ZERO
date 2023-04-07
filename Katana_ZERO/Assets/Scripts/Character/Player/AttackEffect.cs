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
        if ( _data.cursorDirection.x > 0f )
        {
            transform.rotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.rotation = Quaternion.Euler( 180f, 0f, -_data.AttackAngle );
        }
    }
}
