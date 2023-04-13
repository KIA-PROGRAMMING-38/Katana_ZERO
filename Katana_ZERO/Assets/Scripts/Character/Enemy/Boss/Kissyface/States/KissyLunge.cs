using UnityEngine;
using LiteralRepository;

public class KissyLunge : BossStateMachine
{
    private Vector2 _controlPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        controller.PrevState = KissyfaceAnimeHash.s_Lunge;
        moveVec = Vector3.zero;
 
        float middleX = startPos.x + direction * ( Mathf.Abs( startPos.x - playerPos.x ) / 2f );
        float middleY = startPos.y + 2f;

        _controlPos = new Vector2( middleX, middleY );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        moveVec = SecondBezier( startPos, _controlPos, playerPos, stateInfo.normalizedTime );

        rigid.MovePosition( moveVec );
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    private Vector2 FirstBezier( Vector2 p0, Vector2 p1, float t )
    {
        return Vector3.Lerp( p0, p1, t );
    }
    private Vector2 SecondBezier( Vector2 p0, Vector2 p1, Vector2 p2, float t )
    {
        Vector2 m0 = FirstBezier( p0, p1, t );
        Vector2 m1 = FirstBezier( p1, p2, t );
        return FirstBezier( m0, m1, t );
    }
}
