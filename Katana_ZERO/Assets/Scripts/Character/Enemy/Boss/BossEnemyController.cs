using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : Enemy
{
    public Transform TargetTransform;
    public float BossDirection;

    public override void Awake()
    {
        base.Awake();
    }
}
