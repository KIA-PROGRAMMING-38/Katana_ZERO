using UnityEngine;
using StringLiteral;

// State == Track
public class Knife_RunStateBehaviour : KnifeState
{
    private float _trackMaxSec;
    private Vector2 _trackVec;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _trackMaxSec = controller.trackMaxSec;

        Debug.Log( "run ÁøÀÔ" );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        float deltaTime = Time.deltaTime;

        _trackVec = new Vector2( controller.runSpeed * controller.FacingDirection, rigid.velocity.y );
        rigid.velocity = _trackVec;

        elapsedTime += deltaTime;
        Debug.Log( controller.TrackActive );

        if ( IsTrackEnd() )
        {
            ChangeState( animator, EnemyAnimationLiteral.RUN, EnemyAnimationLiteral.RETURN );
        }

        if ( controller.TrackActive == false )
        {
            ChangeState( animator, EnemyAnimationLiteral.RUN, EnemyAnimationLiteral.RETURN );
        }
    }

    private bool IsTrackEnd()
    {
        if ( elapsedTime >= _trackMaxSec )
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }

    
}
