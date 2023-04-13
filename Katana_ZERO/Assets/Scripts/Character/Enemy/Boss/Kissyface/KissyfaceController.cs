using LiteralRepository;
using System;
using UnityEngine;

public class KissyfaceController : Enemy
{
    public event Action<bool> SetNextBehaviour;
    public GameObject TargetGameObject;

    public GameObject Weapon;

    public bool IsJumping;
    public bool IsThrow;

    // Throw Animation에서 도끼가 사출된 상태
    public bool IsEjection;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDamaged()
    {
        SetNextBehaviour?.Invoke( OnDamageable );
    }
}
