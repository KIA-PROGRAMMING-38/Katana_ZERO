using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffectController : MonoBehaviour
{
    [SerializeField]
    private EffectManager _effectManager;

    public GameObject _tmpDieEffect;

    private void Awake()
    {
        _effectManager = transform.root.GetComponent<EffectManager>();
        _effectManager.SetActiveLaserBurnEffect -= PlayEffect;
        _effectManager.SetActiveLaserBurnEffect += PlayEffect;
    }

    private void PlayEffect( Transform targetTransfrom, SpriteRenderer targetSpriteRenderer )
    {
        _tmpDieEffect.GetComponent<SpriteRenderer>().sprite = targetSpriteRenderer.sprite;
        _tmpDieEffect.transform.position = targetTransfrom.position;
        _tmpDieEffect.SetActive( true );
        _tmpDieEffect.SetActive( true );
    }
}
