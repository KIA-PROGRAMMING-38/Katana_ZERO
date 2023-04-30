using LiteralRepository;
using System;
using UnityEngine;

public class KissyfaceController : Enemy
{
    public static event Action KissyDieInvoke;
    public static event Action KissyCountInvoke;

    public event Action<bool> SetNextBehaviour;
    public GameObject TargetGameObject;
    public GameObject Weapon;

    public CapsuleCollider2D _capsule;
    public BoxCollider2D[] _boxes;

    public bool IsJumping;
    public bool IsThrow;

    // Throw Animation에서 도끼의 사출을 담당
    // true일 경우 사출 된 상태, false일 경우 되돌아오는 상태
    public bool IsEjection;

    private AudioSource _audio;

    public override void Awake()
    {
        base.Awake();

        KissyCountInvoke?.Invoke();
        _audio = GetComponent<AudioSource>();
    }

    public override void OnDamaged()
    {
        SetNextBehaviour?.Invoke( OnDamageable );
    }

    public void CheckedKissyDie()
    {
        KissyDieInvoke?.Invoke();
        _audio.playOnAwake = true;
        _audio.Play();
    }
}
