using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected PlayerInput input;
    protected PlayerData data;
    protected PlayerAudio audio;
    protected PlayerController controller;
    protected PlayerAnimInvoker animInvoker;
    protected Rigidbody2D rigid;
    protected ParticleSystem footParticle;
    protected ParticleSystem wallParticle;
    protected EffectManager effectManager;

    public override void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        input = animator.GetComponent<PlayerInput>();
        data = animator.GetComponent<PlayerData>();
        controller = animator.GetComponent<PlayerController>();
        rigid = animator.GetComponent<Rigidbody2D>();
        animInvoker = animator.GetComponent<PlayerAnimInvoker>();
        audio = animator.GetComponent<PlayerAudio>();

        effectManager = controller.EffectManager.GetComponent<EffectManager>();
        footParticle = controller.FootParticle.GetComponent<ParticleSystem>();
        wallParticle = controller.WallParticle.GetComponent<ParticleSystem>();
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

    protected void SetTrigger( Animator animator, int currentHash, int setTriggerHash )
    {
        animator.SetBool( currentHash, false );
        animator.SetTrigger( setTriggerHash );
    }
}



