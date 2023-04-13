using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerInput input;
    protected PlayerData data;
    protected PlayerController controller;
    protected Rigidbody2D rigid;
    protected ParticleSystem dustParticle;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        input = animator.GetComponent<PlayerInput>();
        data = animator.GetComponent<PlayerData>();
        controller = animator.GetComponent<PlayerController>();
        rigid = animator.GetComponent<Rigidbody2D>();
        dustParticle = controller.DustParticle.GetComponent<ParticleSystem>();
    }

    protected void ChangeState( Animator animator, string currentState, string nextState )
    {
        animator.SetBool( currentState, false );
        animator.SetBool( nextState, true );
    }
}



