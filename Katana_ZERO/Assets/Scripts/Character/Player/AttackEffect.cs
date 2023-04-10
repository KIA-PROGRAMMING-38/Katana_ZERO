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

    private void OnEnable()
    {
        if ( _data.CursorDirection.x > 0f )
        {
            transform.localRotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.localRotation = Quaternion.Euler( 180f, 180f, -_data.AttackAngle );
        }
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == 8 )
        {
            collision.transform.root.SendMessage( "OnDamaged" );
        }
    }
}
