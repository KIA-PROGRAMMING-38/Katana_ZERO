using UnityEngine;

public class KnifeState : StateMachineBehaviour
{
    protected KnifeController controller;
    protected Rigidbody2D rigid;

    protected float elapsedTime;
    
    protected Vector2 _trackVec;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        controller = animator.gameObject.transform.root.GetComponent<KnifeController>();
        rigid = animator.gameObject.transform.root.GetComponent<Rigidbody2D>();

        elapsedTime = 0f;
        controller.OnDamageable = true;
    }

    protected void ChangeState( Animator animator, string currentState, string nextState )
    {
        animator.SetBool( currentState, false );
        animator.SetBool( nextState, true );
    }
}
