using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerData : MonoBehaviour
{
    public Transform groundCheck;
    public Transform wallCheck;

    private PlayerInput _input;
    private Rigidbody2D _rigid;

    [SerializeField][Range( 1f, 100f )] private float _moveSpeed;
    [SerializeField][Range( 1f, 100f )] public float jumpPower;

    public Vector2 moveVec;

    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;

    public bool isGrounded;
    public bool isTouchingWall;
    public bool isWallSliding;
    public bool FlipIsRight = true;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveVec = new Vector2( _input.primitiveMoveVec.x * _moveSpeed, _rigid.velocity.y );
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( groundCheck.position, groundCheckRadius );

        Gizmos.DrawLine( wallCheck.position,
            new Vector3( wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z ) );
    }
}

