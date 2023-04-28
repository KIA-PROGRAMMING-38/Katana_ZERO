using System.Collections;
using UnityEngine;

public class DieLaserEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _mtrlPhase;
    [SerializeField][Range(0f,20f)] 
    private float _fadeTime;

    public float SetActiveFalseTime;

    private ParticleSystem _particle;

    private IEnumerator _setActiveFalseCoroutine;

    private void OnEnable()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
        _renderer = GetComponent<Renderer>();
        _renderer.material = _mtrlPhase;

        _particle.Play();

        // StartCoroutine(  );
        SetCoroutine(2, -1, _fadeTime);
    }

    private void SetCoroutine(float start, float dest, float time)
    {
        if ( _setActiveFalseCoroutine != null )
        {
            StopCoroutine( _setActiveFalseCoroutine );
        }

        _setActiveFalseCoroutine = DoFadeHelper( start, dest, time );
        StartCoroutine( _setActiveFalseCoroutine );
    }

    private float _elapsedFadeTime;
    private static readonly int SPLIT_VALUE = Shader.PropertyToID( "_SplitValue" );
    IEnumerator DoFadeHelper(float start, float dest, float time)
    {
        _elapsedFadeTime = 0f;

        while ( _elapsedFadeTime <= time )
        {
            float newValue = EaseUtil.Linear( start, dest, _elapsedFadeTime / time );
            _renderer.material.SetFloat( SPLIT_VALUE, newValue );

            _elapsedFadeTime += Time.deltaTime;

            yield return null;
        }
    }
}