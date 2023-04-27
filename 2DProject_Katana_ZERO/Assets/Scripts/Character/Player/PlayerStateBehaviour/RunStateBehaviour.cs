using UnityEngine;
using LiteralRepository;
using static PlayerAnimInvoker;
using JetBrains.Annotations;
using Util;
using System.Data;
using System;

public class RunStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Run;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( data.PlayerOnGround == GlobalData.GroundState.Flat )
        {
            controller.FlatGroundMovement();
        }
        else if ( data.PlayerOnGround == GlobalData.GroundState.Slope )
        {
            controller.SlopeGroundMovement();
        }
        else if ( data.PlayerOnGround == GlobalData.GroundState.Empty )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.FALL );
        }

        if ( input.PrimitiveMoveVec.x == 0f ) 
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.RUN_TO_IDLE );
        }

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.JUMP );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;
    }
}
