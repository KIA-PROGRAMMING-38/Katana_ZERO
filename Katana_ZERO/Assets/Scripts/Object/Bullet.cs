using StringLiteral;
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

    private void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.CompareTag( TagLiteral.FRONTIER ) )
        {
            Destroy( gameObject );
        }

        if ( other.gameObject.CompareTag( TagLiteral.PLAYER ) )
        {
            Destroy( gameObject );
        }
    }
}
