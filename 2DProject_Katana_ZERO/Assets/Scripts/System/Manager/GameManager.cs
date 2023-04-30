using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public event Action SetGameOverEffect;
    public event Action SetGameClearEffect;

    private int _currentStageIndex;
    private bool _isGameOver;
    public bool IsGameClear;

    private AudioSource _audio;
    public static List<AudioClip> _bgmClips;
    public static bool IsFirstStage = true;

    protected override void Awake()
    {
        base.Awake();

        Instance._audio = GetComponent<AudioSource>();
        _bgmClips = new List<AudioClip>();
        SetBGMClips();
    }

    private void FixedUpdate()
    {
        if ( IsGameClear )
        {
            SetGameClearEffect?.Invoke();

            if ( Input.GetMouseButtonDown( 0 ) )
            {
                IsGameClear = false;
                Instance.MoveToNextScene();
            }
        }
    }

    public void MoveToNextScene()
    {
        ++Instance._currentStageIndex;
        SceneManager.LoadScene( Instance._currentStageIndex );

        if ( Instance._currentStageIndex == 1  && IsFirstStage )
        {
            IsFirstStage = false;
            Instance.PlayStageBGM( 0 );
        }

        if ( Instance._currentStageIndex == 5 )
        {
            Instance.PlayStageBGM( 1 );
        }
    }

    private void Update()
    {
        if ( Instance._isGameOver )
        {
            if ( Input.GetMouseButtonDown( 0 ) )
            {
                Instance._isGameOver = false;
                SceneManager.LoadScene( _currentStageIndex);
            }
        }
    }

    private void PlayStageBGM(int index)
    {
        Instance._audio.clip = _bgmClips[index];
        AudioPlay();
    }

    private void SetBGMClips()
    {
        _bgmClips.Add( DataHelper.LoadBGMClipHelper( "Hit_the_Floor" ));
        _bgmClips.Add( DataHelper.LoadBGMClipHelper( "Meat_Grinder" ));
    }

    private void AudioPlay()
    {
        Instance._audio.playOnAwake = true;
        Instance._audio.Play();
    }

    public static void GetGameOverState()
    {
        Instance.SetGameOverEffect?.Invoke();
        Instance._isGameOver = true;
    }
}
