using Unity.Collections;
using UnityEngine;
using Util;

public class PlayerData : MonoBehaviour
{

    public GameObject Item;
    public Transform ThrowPoint;

    public Transform GroundCheck;
    public Transform WallCheck;

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
    public bool HasItem;
    public bool IsDie;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GlobalData.PlayerTransform = gameObject.transform;
        GlobalData.PlayerGameObject = gameObject;

        MoveVec = new Vector2( _input.PrimitiveMoveVec.x * _moveSpeed, _rigid.velocity.y );

        CursorDirection = GlobalData.GetDirectionBetweenTargetToMouse( transform.position );
        AttackAngle = GlobalData.GetAngleBetweenPlayerToMouse( transform.position );

        if ( CursorDirection.x > 0f )
        {
            ThrowPoint.localRotation = Quaternion.Euler( 0f, 0f, AttackAngle );
        }
        else
        {
            ThrowPoint.localRotation = Quaternion.Euler( 180f, 180f, -AttackAngle );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere( GroundCheck.position, GroundCheckRadius );

        Gizmos.DrawLine( WallCheck.position,
            new Vector3( WallCheck.position.x + WallCheckDistance * FacingDirection, WallCheck.position.y, WallCheck.position.z ) );
    }
}

