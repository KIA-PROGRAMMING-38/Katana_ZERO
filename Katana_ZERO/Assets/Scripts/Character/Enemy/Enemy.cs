using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NonPlayableChacter
{
    public Rigidbody2D rigid;
    protected SpriteRenderer spriteRender;

    [Header( "Basic Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool OnDamageable;
    public int PrevState;
    public int NextState;

    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Update()
    {
        CheckedFlip();
    }

    private void CheckedFlip()
    {
        if ( FlipIsRight && rigid.velocity.x < 0f )
        {
            Flip();
        }
        else if ( FlipIsRight == false && rigid.velocity.x > 0f )
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1f;
        FlipIsRight = !FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }
}
