using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    [SerializeField]
    protected Transform body;

    protected Rigidbody2D rigid;
    protected Animator animator;

    [SerializeField]
    protected GameObject player;
    protected PlayerController controller;

    public bool alreadyUsed;
    public bool flyingAway;

    [SerializeField]
    [Range(1f, 10f)]
    public float flyingSpeed;

    [SerializeField]
    [Range(1f, 10f)]
    protected float rotationSpeed;

    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = body.GetComponent<Animator>();
        controller = player.GetComponent<PlayerController>();
    }

    protected void ChangeState( Animator animator, string currentState, string nextState )
    {
        animator.SetBool( currentState, false );
        animator.SetBool( nextState, true );
    }
}
