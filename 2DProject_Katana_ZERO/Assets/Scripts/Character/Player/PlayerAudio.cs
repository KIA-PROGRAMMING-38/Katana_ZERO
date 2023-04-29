using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audio;
    private List<AudioClip> _clips = new List<AudioClip>();

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        SetEffectClips();
    }

    private void SetEffectClips()
    {
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.ROLL ) );
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.PLAYER_SLASH1 ) );
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.PLAYER_SLASH2 ) );
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.PLAYER_SLASH3 ) );
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.LASER ) );
    }

    public void PlayEffectSound( int index )
    {
        _audio.clip = _clips[index];
        AudioPlay();
    }

    private void AudioPlay()
    {
        _audio.playOnAwake = true;
        _audio.Play();
    }
}
