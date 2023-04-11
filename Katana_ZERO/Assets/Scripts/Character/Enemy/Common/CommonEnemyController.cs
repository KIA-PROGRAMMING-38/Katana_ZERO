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
    public bool isShot;

    [Header( "Common Controller" )]
    public bool TrackActive;
    public bool AttackActive;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }
}
