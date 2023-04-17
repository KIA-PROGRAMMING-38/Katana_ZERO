using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _slowTimeEffectPanel;
    [SerializeField]
    private CanvasGroup _cg;
    [SerializeField][Range(0f, 1f)]
    private float _duration = 0.15f;

    private float _elapsedTime;
    private IEnumerator _initialCoroutine;
    private IEnumerator _endCoroutine;

    private void Update()
    {
        if ( Input.GetKeyUp( KeyCode.LeftShift ) )
        {
            Time.timeScale = 1f;

            EndCoroutine();
        }

        if ( Input.GetKeyDown( KeyCode.LeftShift ))
        {
            StartCouroutine();
        } 
    }

    private void StartCouroutine()
    {
        if ( null != _initialCoroutine )
        {
            StopCoroutine( _endCoroutine );
        }

        _initialCoroutine = ElapsedTime();
        StartCoroutine( _initialCoroutine );
    }

    private void EndCoroutine()
    {
        if ( null != _endCoroutine )
        {
            StopCoroutine( _initialCoroutine );
        }

        _endCoroutine = EscapeTime();
        StartCoroutine( _endCoroutine );
    }

    private IEnumerator ElapsedTime()
    {
        Time.timeScale = 0.2f;
        _elapsedTime = 0f;

        while ( _cg.alpha < 1f )
        {
            _cg.alpha = Mathf.Lerp( 0f, 1f, _elapsedTime / _duration );
            _elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }
    }

    private IEnumerator EscapeTime()
    {
        _elapsedTime = 0f;

        while ( _cg.alpha >= 0f )
        {
            _cg.alpha = Mathf.Lerp( 1f, 0f, _elapsedTime / _duration );
            _elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }
    }

}


