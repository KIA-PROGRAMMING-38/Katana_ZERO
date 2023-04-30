using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyAnimInvoker : AnimationManager
{
    [SerializeField]
    private GameObject _attackPoint;
    private CommonEnemyController _controller;

    public override void Awake()
    {
        base.Awake();

        _controller = transform.root.GetComponent<CommonEnemyController>();
    }

    public void SetActiveAttackEffect()
    {
        _attackPoint.SetActive( true );
    }

    public override int GetAnimationStateHash( int state )
    {
        switch ( state ) 
        {
            case 0:
                return EnemyAnimationHash.s_Idle;

            case 1:
                return EnemyAnimationHash.s_Walk;

            case 2:
                return EnemyAnimationHash.s_Run;

            case 3:
                return EnemyAnimationHash.s_Aim;

            case 4:
                return EnemyAnimationHash.s_Attack;

            case 5:
                return EnemyAnimationHash.s_KnockDown;
        }

        return 0;
    }

    public override void SetNextAnimation( int state )
    {
        int prevStateHashCode = GetAnimationStateHash( (int)_controller.PrevState );
        int nextStateHashCode = GetAnimationStateHash( state );

        animator.SetBool( prevStateHashCode, false );
        animator.SetBool( nextStateHashCode, true );
    }

    public override void SetAnimationTrigger( string state )
    {
        int prevStateHashCode = GetAnimationStateHash( (int)_controller.PrevState );

        animator.SetBool( prevStateHashCode, false );
        animator.SetTrigger( state );
    }
}
