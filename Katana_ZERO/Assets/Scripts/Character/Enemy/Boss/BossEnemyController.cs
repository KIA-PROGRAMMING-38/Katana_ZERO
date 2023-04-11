using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : Enemy
{
    public Transform TargetTransform;

    [Header( "Speed" )]
    public float attackSpeed;
    public float runSpeed;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }
}
