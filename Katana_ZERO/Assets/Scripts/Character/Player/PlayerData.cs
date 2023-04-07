using Unity.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Transform groundCheck;
    public Transform wallCheck;
    public GameObject AttackEffect;

    private PlayerInput _input;
    private Rigidbody2D _rigid;

    [SerializeField][Range( 1f, 100f )] private float _moveSpeed;
    [SerializeField][Range( 1f, 100f )] public float jumpPower;

    [Header("Vector")]
    public Vector2 moveVec;
    public Vector2 cursorDirection;
    public Vector2 CapturedCatchDirection;

    [Header("Global Data")]
    public float DefaultGravityScale;
    public float FallingBoostForce;
    public float facingDirection = 1f;
    public float groundCheckRadius;

    [Header("Wall States")]
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float HoldAWallTime;
    public float HoldAWallForce;
    public float wallFlipHorizontalForce;
    public float wallFlipVerticalForce;

    [Header("Roll State")]
    public float RollHorizontalForce;

    [Header("Attack State")]
    public float AttackForce;
    public float AttackAnimElapsedTime;
    public float AfterAttackVelocity;
    public float AttackAngle;
    public float AttackRadius;

    [Header("Boolean Data")]
    public bool isGrounded;
    public bool isTouchingWall;
    public bool isWallSliding;
    public bool FlipIsRight = true;
    public bool onLeftWall;


    public float tmpValue;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveVec = new Vector2( _input.primitiveMoveVec.x * _moveSpeed, _rigid.velocity.y );
        cursorDirection = _input.PrimitiveMouseWorldPos - (Vector2)transform.position;
        AttackAngle = Mathf.Atan2( cursorDirection.y, cursorDirection.x ) * Mathf.Rad2Deg;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( groundCheck.position, groundCheckRadius );

        Gizmos.DrawLine( wallCheck.position,
            new Vector3( wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y, wallCheck.position.z ) );
    }
}

