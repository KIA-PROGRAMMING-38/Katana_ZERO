using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KissyfaceProperty;

public class BossStateMachine : StateMachineBehaviour
{
    protected Rigidbody2D rigid;
    protected BossEnemyController controller;
    protected InvokeAnimation invokeAnimation;

    protected float elapsedTime;

    protected Vector2 trackVec;

    protected int getNextStateHash;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        rigid = animator.gameObject.transform.root.GetComponent<Rigidbody2D>();
        controller = animator.gameObject.transform.root.GetComponent<BossEnemyController>();
        invokeAnimation = animator.GetComponent<InvokeAnimation>();

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
}
