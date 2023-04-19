using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLaserEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _mtrlOrg;
    [SerializeField] private Material _mtrlPhase;
    [SerializeField] private float _fadeTime;


    private ParticleSystem _particle;
    public SpriteRenderer _sprite;

    private void Awake()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
        _sprite = GetComponent<SpriteRenderer>();
        _renderer = GetComponent<Renderer>();
        _renderer.material = _mtrlPhase;
        
        gameObject.SetActive( false );
    }

    private void OnEnable()
    {
        _particle.Play();
        Dofade( 0.18f, -3f, _fadeTime );
    }


    void Dofade(float start, float dest, float time)
    {
        iTween.ValueTo( gameObject, iTween.Hash( "from", start, "to", dest, "time", time,
            "onupdatetarget", gameObject, 
            "onupdate", "TweenOnUpdate", 
            "easetype", iTween.EaseType.easeInOutCubic ) );
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat( "_SplitValue", value );
    }
}
