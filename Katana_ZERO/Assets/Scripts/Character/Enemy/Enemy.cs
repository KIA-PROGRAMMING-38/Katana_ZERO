using UnityEngine;

public abstract class Enemy : NonPlayableChacter
{
    public Rigidbody2D rigid;
    protected SpriteRenderer spriteRender;

    public Transform TargetTransform;
    public Animator BodyAnimator;

    [Header( "Basic Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool OnDamageable;
    public int PrevState;
    public int NextState;

    public enum CommonEnemyType
    {
        Knife,
        Gun
    }

    public enum BossEnemyType
    {
        Kissyface
    }

    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
}
