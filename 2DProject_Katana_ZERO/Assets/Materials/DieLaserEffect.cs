using System.Collections;
using UnityEngine;
using Util.Pool;

public class DieLaserEffect : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _mtrlPhase;
    [SerializeField][Range(0f,20f)] 
    private float _fadeTime;

    public float SetActiveFalseTime;

    private ParticleSystem _particle;
    private SpriteRenderer _sprite;
    private WaitForSeconds _setActiveFalseTimer;

    private IEnumerator _setActiveFalseCoroutine;
    private IObjectPool<DieLaserEffect> _pool;

    private void OnEnable()
    {
        //_particle = GetComponentInChildren<ParticleSystem>();
        _sprite = GetComponent<SpriteRenderer>();
        _renderer = GetComponent<Renderer>();
        _renderer.material = _mtrlPhase;
        _setActiveFalseTimer = new WaitForSeconds( SetActiveFalseTime );

        //_particle.Play();
        //Dofade( 1f, -2f, _fadeTime );

        StartCoroutine( DoFadeHelper( 1f, -1f, _fadeTime ) );
        Debug.Break();

        SetCoroutine();
    }

    private void SetCoroutine()
    {
        if ( _setActiveFalseCoroutine != null )
        {
            StopCoroutine( _setActiveFalseCoroutine );
        }

        _setActiveFalseCoroutine = SetActiveFalse();
        StartCoroutine( _setActiveFalseCoroutine );
    }

    private IEnumerator SetActiveFalse()
    {
        yield return _setActiveFalseTimer;

        gameObject.SetActive( false );
    }

    private float _elapsedFadeTime;
    private static readonly int SPLIT_VALUE = Shader.PropertyToID( "_SplitValue" );
    IEnumerator DoFadeHelper(float start, float dest, float time)
    {
        _elapsedFadeTime = 0f;

        while ( _elapsedFadeTime <= time )
        {
            float newValue = EaseUtil.EaseInOutCubic( start, dest, _elapsedFadeTime / time );
            _renderer.material.SetFloat( SPLIT_VALUE, newValue );

            _elapsedFadeTime += Time.deltaTime;

            yield return null;
        }
    }

    public void SetPoolRef( IObjectPool<DieLaserEffect> pool )
    {
        _pool = pool;
    }
}
