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

    // Throw Animation���� ������ ����� ����
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
