using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEffect : MonoBehaviour
{
    private OutSideEffect _outSideEffect;

    private void Awake()
    {
        _outSideEffect = transform.GetComponentInParent<OutSideEffect>();
    }

    public void Release()
    {
        _outSideEffect.EffectObjects.Push( gameObject );
        gameObject.SetActive( false );
    }
}
