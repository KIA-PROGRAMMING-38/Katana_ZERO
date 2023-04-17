using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private AttackEffect _attackEffect;
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private GameObject _playerAttackEffect;

    public void OnEnableAttackEffect()
    {
        _playerAttackEffect.SetActive( true );
    }

    public void OnDisableAttackEffect()
    {
        _playerAttackEffect.SetActive( false );
    }
}
