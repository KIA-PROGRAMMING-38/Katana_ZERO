using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(3f, 20f)]
    public float _bulletSpeed = 10f;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private Vector2 _velocity;

    private void Start()
    {
        Initialize();

        _rigid.velocity = _velocity;
    }

    private void Initialize()
    {
        _velocity = transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.FLOOR ) )
        {
            Destroy( gameObject );
        }

        if ( collision.CompareTag( TagLiteral.PLAYER ) )
        {
            Destroy( gameObject );
        }

        if ( gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            if ( collision.CompareTag( TagLiteral.ENEMY ) )
            {
                Destroy( gameObject );
            }
        }

        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) )
        {
            Vector2 normal = collision.transform.right * -1f;
            Vector2 reflectedDirection = Vector2.Reflect( _rigid.velocity.normalized, normal );
            _rigid.velocity = reflectedDirection * _bulletSpeed;

            gameObject.layer = LayerMaskNumber.s_ReflectedBullet;

            float reflectAngle = Mathf.Atan2
            ( reflectedDirection.y, reflectedDirection.x ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler( 0f, 0f, reflectAngle );
        }
    }
}
