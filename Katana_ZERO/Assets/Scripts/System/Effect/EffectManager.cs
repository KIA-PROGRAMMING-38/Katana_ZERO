using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("Manager")]
    public TimeManager TimeManager;

    [Header("Object")]
    [SerializeField]
    private AttackEffect _attackEffect;
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private GameObject _playerAttackEffect;
    [SerializeField]
    private GameObject _playerSlowTimeEffect;

    private void Start()
    {
        TimeManager.OnActiveSlowTime -= SetActiveTrueSlowTimeEffect;
        TimeManager.OnActiveSlowTime += SetActiveTrueSlowTimeEffect;

        TimeManager.DeActiveSlowTime -= SetActiveFalseSlowTimeEffect;
        TimeManager.DeActiveSlowTime += SetActiveFalseSlowTimeEffect;
    }

    public void OnEnableAttackEffect()
    {
        _playerAttackEffect.SetActive( true );
    }

    public void OnDisableAttackEffect()
    {
        _playerAttackEffect.SetActive( false );
    }

    private void SetActiveTrueSlowTimeEffect()
    {
        _playerSlowTimeEffect.SetActive( true );
    }

    private void SetActiveFalseSlowTimeEffect()
    {
        _playerSlowTimeEffect.SetActive( false );
    }
}
