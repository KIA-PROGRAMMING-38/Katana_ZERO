using UnityEngine;
using static KissyfaceAnimInvoker;

public class BossStateMachine : StateMachineBehaviour
{
    protected Rigidbody2D rigid;
    protected KissyfaceController controller;
    protected KissyfaceAnimInvoker kissyfaceAnimInvoker;

    protected float elapsedTime;
    protected float direction;

    protected Vector2 moveVec;
    protected Vector2 startPos;
    protected Vector2 playerPos;

    protected int getNextStateHash;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        rigid = animator.gameObject.transform.root.GetComponent<Rigidbody2D>();
        controller = animator.gameObject.transform.root.GetComponent<KissyfaceController>();
        kissyfaceAnimInvoker = animator.GetComponent<KissyfaceAnimInvoker>();
        
        currentKissyState = KissyState.Default;
        startPos = animator.transform.position;
        playerPos = controller.TargetTransform.position;

        direction = Mathf.Sign( playerPos.x - startPos.x );

        moveVec = Vector3.zero;
        controller.OnDamageable = false;
        getNextStateHash = 0;
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

    protected void SetTrigger( Animator animator, int currentHash , int setTriggerHash )
    {
        animator.SetBool( currentHash, false );
        animator.SetTrigger( setTriggerHash );
    }

    protected void CheckedDirection()
    {
        if ( direction > 0f )
        {
            controller.gameObject.transform.rotation = Quaternion.Euler( 0f, 0f, 0f );
        }
        else if ( direction < 0f )
        {
            controller.gameObject.transform.rotation = Quaternion.Euler( 0f, 180f, 0f );
        }
    }
}
