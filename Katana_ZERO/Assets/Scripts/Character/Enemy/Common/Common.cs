using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : Enemy
{
    [SerializeField]
    public float walkSpeed;
    public float runSpeed;

    [Header( "Patrol" )]
    public float patrolMaxSec;
    public float patrolMinSec;

    // ��ȸ�� ����Ʈ ����
    public Transform[] PatrolPoints;

    [Header( "Idle" )]
    public float idleMaxSec;
    public float idleMinSec;

    [Header( "Track" )]
    public float trackMaxSec;

    [Header( "Attack" )]
    public float attackCooltime;
}
