using StringLiteral;
using UnityEngine;

public class CommonEnemyController : Enemy
{
    public Transform TargetTransform;

    [Header( "Speed" )]
    public float walkSpeed;
    public float runSpeed;

    [Header( "Patrol" )]
    public float patrolMaxSec;
    public float patrolMinSec;

    // 순회할 포인트 저장
    public Transform[] PatrolPoints;

    [Header( "Idle" )]
    public float idleMaxSec;
    public float idleMinSec;

    [Header( "Attack" )]
    public float attackCooltime;

    [Header( "Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool TrackActive;
    public bool AttackActive;
    public bool OnDamageable;
    public string PrevState;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        CheckedFlip();
    }

    private void CheckedFlip()
    {
        if ( FlipIsRight && rigid.velocity.x < 0f )
        {
            Flip();
        }
        else if ( FlipIsRight == false && rigid.velocity.x > 0f )
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1f;
        FlipIsRight = !FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }
}
