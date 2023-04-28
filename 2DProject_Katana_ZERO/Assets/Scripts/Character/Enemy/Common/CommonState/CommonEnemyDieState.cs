using UnityEngine;

public class CommonEnemyDieState : CommonEnemyState
{
    private bool _isShot = true;
    Transform captureRotation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( rigid.velocity == Vector2.zero )
        {
            controller.DrawBlood.StopDrawBlood();

            if ( _isShot )
            {
                _isShot = false;
                controller.ImpactBlood.TargetObject.Add( animator.gameObject);
                controller.ImpactBlood.ImpactCall( controller.ImpactBlood.TargetObject.Count - 1 );
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
