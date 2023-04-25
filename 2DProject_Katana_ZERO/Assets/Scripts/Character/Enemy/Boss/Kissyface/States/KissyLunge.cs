using UnityEngine;
using HelperFuncRepository;
using static KissyfaceAnimInvoker;

public class KissyLunge : BossStateMachine
{
    private Vector2 _controlPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        moveVec = Vector3.zero;
 
        float middleX = startPos.x + direction * ( Mathf.Abs( startPos.x - playerPos.x ) / 2f );
        float middleY = startPos.y + 2f;

        currentKissyState = KissyState.Lunge;
        controller.PrevState = (int)KissyState.Lunge;
        _controlPos = new Vector2( middleX, middleY );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        moveVec = HelperFunc.SecondBezier( startPos, _controlPos, playerPos, stateInfo.normalizedTime );

        rigid.MovePosition( moveVec );
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
