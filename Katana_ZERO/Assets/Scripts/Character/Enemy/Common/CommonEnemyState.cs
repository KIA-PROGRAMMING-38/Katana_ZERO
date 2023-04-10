using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CommonEnemyState : StateMachineBehaviour
{
    protected Rigidbody2D rigid;
    protected CommonEnemyController controller;

    protected float elapsedTime;

    protected Vector2 _trackVec;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        rigid = animator.gameObject.transform.root.GetComponent<Rigidbody2D>();
        controller = animator.gameObject.transform.root.GetComponent<CommonEnemyController>();

        controller.OnDamageable = true;
        elapsedTime = 0f;
    }

    protected void ChangeState( Animator animator, string currentState, string nextState )
    {
        animator.SetBool( currentState, false );
        animator.SetBool( nextState, true );
    }

    protected void ChangeState( Animator animator, int currentHash, int nextHash )
    {
        animator.SetBool( currentHash, false );
        animator.SetBool( nextHash, true );
    }
}
