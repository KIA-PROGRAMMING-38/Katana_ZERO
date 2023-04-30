using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyAnimInvoker : AnimationManager
{
    [SerializeField]
    private GameObject _attackPoint;

    public override void Awake()
    {
        base.Awake();
    }

    public void SetActiveAttackEffect()
    {
        _attackPoint.SetActive( true );
    }

    public override int GetAnimationStateHash( int state )
    {
        throw new System.NotImplementedException();
    }

    public override void SetAnimationTrigger( string state )
    {
        throw new System.NotImplementedException();
    }

    public override void SetNextAnimation( int state )
    {
        throw new System.NotImplementedException();
    }
}
