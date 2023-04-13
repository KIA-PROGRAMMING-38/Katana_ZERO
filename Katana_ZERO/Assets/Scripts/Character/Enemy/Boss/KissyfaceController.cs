using LiteralRepository;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class KissyfaceController : Enemy
{
    public GameObject TargetGameObject;
    public float BossDirection;
    public bool OnStruggle;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDamaged()
    {

    }
}
