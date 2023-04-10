using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class KnifeController : Common
{
    public Transform TargetTransform;

    [Header( "Knife Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool TrackActive;
    public bool AttackActive;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
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
