using UnityEngine;

public abstract class Enemy : NonPlayableChacter
{
    public Rigidbody2D rigid;
    protected new AudioSource audio;

    protected SpriteRenderer spriteRender;

    public Transform TargetTransform;
    public Animator BodyAnimator;

    public GameObject ThisIsPlayer;

    [Header( "Basic Controller" )]
    public float FacingDirection;
    public bool FlipIsRight;
    public bool OnDamageable;
    public int PrevState;
    public int NextState;

    public enum CommonEnemyType
    {
        Knife,
        Gun,
        Grunt
    }

    public enum BossEnemyType
    {
        Kissyface
    }

    public virtual void Awake()
    {
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
}
