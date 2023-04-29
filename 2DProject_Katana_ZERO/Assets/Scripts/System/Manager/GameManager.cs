using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action SetGameOverEffect;

    private AudioSource _audio;
    private List<AudioClip> _bgmClips;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _audio = GetComponent<AudioSource>();
        _bgmClips = new List<AudioClip>();

        SetBGMClips();
        PlayStageBGM( 0 );
    }

    private void PlayStageBGM(int index)
    {
        _audio.clip = _bgmClips[index];
        AudioPlay();
    }

    private void SetBGMClips()
    {
        _bgmClips.Add( DataHelper.LoadBGMClipHelper( "Hit_the_Floor" ));
        _bgmClips.Add( DataHelper.LoadBGMClipHelper( "Meat_Grinder" ));
    }

    private void AudioPlay()
    {
        _audio.playOnAwake = true;
        _audio.Play();
    }

    public static void GetGameOverState()
    {
        SetGameOverEffect?.Invoke();
    }
}
