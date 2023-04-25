using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class PlayerAnimInvoker : AnimationManager
{
    private PlayerController _controller;

    public enum PlayerState
    {
        Default = 0,
        Idle,
        IdleToRun,
        Run,
        RunToIdle,
        Jump,
        WallGrab,
        WallSlide,
        WallFlip,
        Fall,
        PreCrouch,
        Crouch,
        PostCrouch,
        Roll,
        Attack,
        OnDamaged,
        Die
    }

    public static PlayerState CurrentPlayerState = PlayerState.Default;

    public override void Awake()
    {
        base.Awake();

        _controller = GetComponent<PlayerController>();
    }

    public override void SetNextAnimation( int state )
    {
        int prevStateHashCode = GetAnimationStateHash( (int)CurrentPlayerState );
        int nextStateHashCode = GetAnimationStateHash( state );

        animator.SetBool( prevStateHashCode, false );
        animator.SetBool( nextStateHashCode, true );
    }

    public override void SetAnimationTrigger( string state )
    {
        int prevStateHashCode = GetAnimationStateHash( (int)CurrentPlayerState );

        animator.SetBool( prevStateHashCode, false );
        animator.SetTrigger( state );
    }

    public override int GetAnimationStateHash( int state )
    {
        switch ( state )
        {
            case (int)PlayerState.Idle:
                return PlayerAnimationHash.s_Idle;

            case (int)PlayerState.IdleToRun:
                return PlayerAnimationHash.s_IdleToRun;

            case (int)PlayerState.Run:
                return PlayerAnimationHash.s_Run;

            case (int)PlayerState.RunToIdle:
                return PlayerAnimationHash.s_RunToIdle;

            case (int)PlayerState.Jump:
                return PlayerAnimationHash.s_Jump;

            case (int)PlayerState.WallGrab:
                return PlayerAnimationHash.s_WallGrab;

            case (int)PlayerState.WallSlide:
                return PlayerAnimationHash.s_WallSlide;

            case (int)PlayerState.WallFlip:
                return PlayerAnimationHash.s_WallFlip;

            case (int)PlayerState.Fall:
                return PlayerAnimationHash.s_Fall;

            case (int)PlayerState.PreCrouch:
                return PlayerAnimationHash.s_PreCrouch;

            case (int)PlayerState.Crouch:
                return PlayerAnimationHash.s_Crouch;

            case (int)PlayerState.PostCrouch:
                return PlayerAnimationHash.s_PostCrouch;

            case (int)PlayerState.Roll:
                return PlayerAnimationHash.s_Roll;

            case (int)PlayerState.Attack:
                return PlayerAnimationHash.s_Attack;

            case (int)PlayerState.OnDamaged:
                return PlayerAnimationHash.s_OnDamaged;

            case (int)PlayerState.Die:
                return PlayerAnimationHash.s_Die;
        }

        return 0;
    }
}
