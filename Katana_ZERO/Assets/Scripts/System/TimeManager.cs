using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _slowTimeEffectPanel;
    [SerializeField]
    private CanvasGroup _cg;
    [SerializeField][Range(0f, 1f)]
    private float _duration = 0.15f;

    private IEnumerator _initialCoroutine;
    private IEnumerator _endCoroutine;

    private float _elapsedTime;

    // InGame Default Value = 8sec;
    [SerializeField]
    [Range(0f, 10f)]
    private float _maxElapsedTime;

    private bool _isPressed;

    private void Awake()
    {
        _elapsedTime = _maxElapsedTime;
    }

    private void Update()
    {
        float elapsedTime = Time.unscaledDeltaTime;

        if ( _elapsedTime >= _maxElapsedTime )
            _elapsedTime = _maxElapsedTime;

        if ( (Input.GetKeyUp( KeyCode.LeftShift ) || _elapsedTime <= 0f) && _isPressed )
        {
            EndCoroutine();
            _isPressed = false;
        }

        if ( Input.GetKeyDown( KeyCode.LeftShift ) && _elapsedTime >= 0f && !_isPressed )
        {
            StartCouroutine();
            _isPressed = true;
        } 

        if ( Input.GetKey( ( KeyCode.LeftShift ) ) && _elapsedTime >= 0f && _isPressed )
        {
            _elapsedTime -= elapsedTime;

            if ( _elapsedTime <= 0f )
            {
                EndCoroutine();
                _isPressed = false;
            }
        }
        else
        {
            _elapsedTime += elapsedTime;
        }
    }

    private void StartCouroutine()
    {
        Time.timeScale = 0.2f;

        if ( null != _initialCoroutine )
        {
            StopCoroutine( _endCoroutine );
        }

        _initialCoroutine = ElapsedTime();
        StartCoroutine( _initialCoroutine );
    }

    private void EndCoroutine()
    {
        Time.timeScale = 1f;

        if ( null != _endCoroutine )
        {
            StopCoroutine( _initialCoroutine );
        }

        _endCoroutine = EscapeTime();
        StartCoroutine( _endCoroutine );
    }

    private float _panelControlTime;
    private IEnumerator ElapsedTime()
    {
        _panelControlTime = 0f;

        while ( _cg.alpha < 1f )
        {
            _cg.alpha = Mathf.Lerp( 0f, 1f, _panelControlTime / _duration );
            _panelControlTime += Time.unscaledDeltaTime;

            yield return null;
        }
    }

    private IEnumerator EscapeTime()
    {
        _panelControlTime = 0f;

        while ( _cg.alpha >= 0f )
        {
            _cg.alpha = Mathf.Lerp( 1f, 0f, _panelControlTime / _duration );
            _panelControlTime += Time.unscaledDeltaTime;

            yield return null;
        }
    }

}


