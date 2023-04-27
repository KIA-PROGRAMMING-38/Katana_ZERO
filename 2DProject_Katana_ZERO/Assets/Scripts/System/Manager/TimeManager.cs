using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public event Action OnActiveSlowTime;
    public event Action DeActiveSlowTime;

    public event Action AllUsedSlowTime;

    public float RemainingTime = 100f;

    [SerializeField]
    private GameObject _slowTimeEffectPanel;
    [SerializeField]
    private CanvasGroup _cg;
    [SerializeField][Range(0f, 1f)]
    private float _duration = 0.15f;

    private IEnumerator _initialCoroutine;
    private IEnumerator _endCoroutine;


    // InGame Default Value = 8sec;
    [SerializeField]
    [Range(0f, 10f)]
    public float MaxElapsedTime;

    public float PossibleSlowTime;
    public bool IsPressed;


    private void Awake()
    {
        PossibleSlowTime = MaxElapsedTime;
    }

    private void Update()
    {
        float elapsedTime = Time.unscaledDeltaTime;

        RemainingTime -= elapsedTime;

        if ( PossibleSlowTime >= MaxElapsedTime )
            PossibleSlowTime = MaxElapsedTime;

        if ( (Input.GetKeyUp( KeyCode.LeftShift ) || PossibleSlowTime <= 0f) && IsPressed )
        {
            EndCoroutine();
            DeActiveSlowTime?.Invoke();
            IsPressed = false;
        }

        if ( Input.GetKeyDown( KeyCode.LeftShift ) && PossibleSlowTime >= 0f && !IsPressed )
        {
            StartCouroutine();
            OnActiveSlowTime?.Invoke();
            IsPressed = true;
        } 

        if ( Input.GetKey( ( KeyCode.LeftShift ) ) && PossibleSlowTime >= 0f && IsPressed )
        {
            PossibleSlowTime -= elapsedTime;

            if ( PossibleSlowTime <= 0f )
            {
                EndCoroutine();
                DeActiveSlowTime?.Invoke();
                AllUsedSlowTime?.Invoke();
                IsPressed = false;
            }
        }
        else
        {   
            PossibleSlowTime += elapsedTime;
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


