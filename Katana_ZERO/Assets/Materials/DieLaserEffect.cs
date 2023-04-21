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

    private void Awake()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
        _sprite = GetComponent<SpriteRenderer>();
        _renderer = GetComponent<Renderer>();
        _renderer.material = _mtrlPhase;
        _setActiveFalseTimer = new WaitForSeconds( SetActiveFalseTime );


        gameObject.SetActive( false );
    }

    private void OnEnable()
    {
        _particle.Play();
        Dofade( 0.18f, -3f, _fadeTime );

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

    private void Dofade(float start, float dest, float time)
    {
        iTween.ValueTo( gameObject, iTween.Hash( "from", start, "to", dest, "time", time,
            "onupdatetarget", gameObject, 
            "onupdate", "TweenOnUpdate", 
            "easetype", iTween.EaseType.easeInOutCubic ) );
    }

    private void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat( "_SplitValue", value );
    }

    public void SetPoolRef( IObjectPool<DieLaserEffect> pool )
    {
        _pool = pool;
    }
}
