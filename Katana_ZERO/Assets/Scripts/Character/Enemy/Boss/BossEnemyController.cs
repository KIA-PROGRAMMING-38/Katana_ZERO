using UnityEngine;

public class BossEnemyController : Enemy
{
    public Transform TargetTransform;
    public GameObject TargetGameObject;
    public float BossDirection;
    public bool OnStruggle;

    public override void Awake()
    {
        base.Awake();
    }
}
