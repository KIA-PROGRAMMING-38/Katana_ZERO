using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NonPlayableChacter
{
    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRender;

    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
}
