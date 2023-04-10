using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class KnifeController : Common
{
    public Vector3 OriginPoint { get; private set; }

    [Header( "Knife Controller" )]
    public float FacingDirection;
    public float ShotCooltime;
    public bool FlipIsRight;
    public bool TrackActive;
    public bool AttackActive;


    public override void Awake()
    {
        base.Awake();

        OriginPoint = transform.position;
    }

    private void Update()
    {
        CheckedFlip();

        if ( ShotCooltime <= 0f )
        {
            ShotCooltime = attackCooltime;
        }
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
