using Unity.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Transform GroundCheck;
    public Transform WallCheck;
    public GameObject AttackEffect;

    private PlayerInput _input;
    private Rigidbody2D _rigid;

    [SerializeField][Range( 1f, 100f )] private float _moveSpeed;
    [SerializeField][Range( 1f, 100f )] public float jumpPower;

    [Header("Vector")]
    public Vector2 MoveVec;
    public Vector2 CursorDirection;
    public Vector2 CapturedCatchDirection;

    [Header("Global Data")]
    public float DefaultGravityScale;
    public float FallingBoostForce;
    public float FacingDirection = 1f;
    public float GroundCheckRadius;

    [Header("Wall States")]
    public float WallCheckDistance;
    public float WallSlideSpeed;
    public float HoldAWallTime;
    public float HoldAWallForce;
    public float WallFlipHorizontalForce;
    public float WallFlipVerticalForce;

    [Header("Roll State")]
    public float RollHorizontalForce;

    [Header("Attack State")]
    public float AttackForce;
    public float AttackAnimElapsedTime;
    public float AfterAttackVelocity;
    public float AttackAngle;
    public float AttackRadius;

    [Header("Boolean Data")]
    public bool OnGround;
    public bool IsTouchingWall;
    public bool IsWallSliding;
    public bool FlipIsRight = true;
    public bool OnLeftWall;
    public bool PrevStateisGrab;


    public float tmpValue;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveVec = new Vector2( _input.PrimitiveMoveVec.x * _moveSpeed, _rigid.velocity.y );
        CursorDirection = _input.PrimitiveMouseWorldPos - (Vector2)transform.position;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( GroundCheck.position, GroundCheckRadius );

        Gizmos.DrawLine( WallCheck.position,
            new Vector3( WallCheck.position.x + WallCheckDistance * FacingDirection, WallCheck.position.y, WallCheck.position.z ) );
    }
}

