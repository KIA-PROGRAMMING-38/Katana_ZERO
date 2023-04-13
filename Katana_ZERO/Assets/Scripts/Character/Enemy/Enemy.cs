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
}
