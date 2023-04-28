using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using Util;

// Run State == Track
public class CommonEnemyRunState : CommonEnemyState
{
    private Vector2 _moveVec;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
        
        controller.PrevState = EnemyAnimationHash.s_Run;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        _trackVec = ( controller.TargetTransform.position - (Vector3)rigid.position ).normalized;
        _moveVec = _trackVec * controller.runSpeed;

        if ( controller.EnemyOnGround == GlobalData.GroundState.Flat || controller.EnemyOnGround == GlobalData.GroundState.OneWay )
        {
            FlatGroundMovement();
        }
        else if ( controller.EnemyOnGround == GlobalData.GroundState.Slope )
        {
            SlopeGroundMovement();
        }

        if ( controller.AttackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_Run, EnemyAnimationHash.s_Aim );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }

    private void FlatGroundMovement()
    {
        rigid.velocity = new Vector2 ( _moveVec.x, 0f);
    }

    private void SlopeGroundMovement()
    {
        if ( controller.IsClimb )
        {
            Vector2 slopeDirection = Vector2.Perpendicular( controller.belowHit.normal ).normalized;
            Vector2 slopeMovement = new Vector2
                ( slopeDirection.x * -_trackVec.x * controller.slopeForce, 0f );

            _moveVec += slopeMovement;
            rigid.velocity = new Vector2( _moveVec.x, 0f );
        }
        else
        {
            Vector2 slopeDirection = Vector2.Perpendicular( controller.belowHit.normal ).normalized;
            Vector2 slopeMovement = new Vector2
                ( slopeDirection.x * -_trackVec.x * controller.emptyForce, 0f );

            _moveVec += slopeMovement;
            rigid.velocity = new Vector2( _moveVec.x, rigid.velocity.y - controller.downVelocityForce * Time.fixedDeltaTime );
        }
    }
}
