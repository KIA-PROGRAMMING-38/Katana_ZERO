using UnityEngine;
using StringLiteral;

public class KnifeController : Common
{
    private Animator _animator;

    public Transform TargetTransform;
    public LayerMask KnifeLayer;

    [Header( "Knife Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool TrackActive;
    public bool AttackActive;
    public bool OnDamageable;
    public string PrevState;

    public override void Awake()
    {
        base.Awake();

        _animator = GetComponentInChildren<Animator>();
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

    private void OnDamaged()
    {
        Debug.Log( OnDamageable );

        if ( OnDamageable )
        {
            rigid.velocity = Vector2.zero;
            _animator.SetBool( PrevState, false );
            _animator.SetTrigger( "isDie" );
            ChangeLayer(gameObject.transform, 9);
        }
        else
        {
            _animator.SetBool( EnemyAnimationLiteral.ATTACK, false );
            _animator.SetBool( EnemyAnimationLiteral.KNOCKDOWN, true );
        }
    }

    private void ChangeLayer(Transform transform, int newLayer )
    {
        transform.gameObject.layer = newLayer;

        foreach (Transform child in transform )
        {
            ChangeLayer( child, newLayer );
        }
    }
}
