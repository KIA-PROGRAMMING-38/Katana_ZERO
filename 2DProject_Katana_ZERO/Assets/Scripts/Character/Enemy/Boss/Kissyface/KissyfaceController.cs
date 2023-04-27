using LiteralRepository;
using System;
using UnityEngine;

public class KissyfaceController : Enemy
{
    public event Action<bool> SetNextBehaviour;
    public GameObject TargetGameObject;
    public GameObject Weapon;

    public CapsuleCollider2D _capsule;
    public BoxCollider2D[] _boxes;

    public bool IsJumping;
    public bool IsThrow;

    // Throw Animation���� ������ ������ ���
    // true�� ��� ���� �� ����, false�� ��� �ǵ��ƿ��� ����
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
