using System.Collections;
using UnityEngine;

public class PlayerTrailAnimation : MonoBehaviour
{
    [SerializeField]
    private float _activeTime;

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private SpriteRenderer _playerSprite;
    [SerializeField]
    private GameObject[] _illusionBody;
    private SpriteRenderer _emptySprite;

    [SerializeField][Range(0f, 1f)]
    private float meshRefreshRate;
    [SerializeField][Range(0f, 2f)]
    private float meshDestroyDelay;

    private PlayerController _controller;
    private WaitForSeconds _refreshRate;
    private WaitForSeconds _destroyDelay;

    private int _index;
    private int _lastIndex;

    private void Awake()
    {
        _controller = _player.GetComponent<PlayerController>();
        _refreshRate = new WaitForSeconds( meshRefreshRate );
        _destroyDelay = new WaitForSeconds( meshDestroyDelay );

        _controller.OnIllusionEffect -= ActiveCoroutine;
        _controller.OnIllusionEffect += ActiveCoroutine;
    }

    private void ActiveCoroutine() 
    {
        _index = 0;
        _lastIndex = _illusionBody.Length - 1;

        StartCoroutine( ActivateTrail( _activeTime ) );
    }

    private IEnumerator ActivateTrail( float activeTime )
    {
        while ( _index < _illusionBody.Length )
        {
            _illusionBody[_index].SetActive( true );

            _emptySprite = _illusionBody[_index].GetComponent<SpriteRenderer>();
            _emptySprite.sprite = _playerSprite.sprite;
            _illusionBody[_index].transform.SetPositionAndRotation
                ( _player.transform.position, _player.transform.rotation );

            StartCoroutine( SetActiveFalse( _illusionBody[_index] ) );

            ++_index;

            yield return _refreshRate;
        }
    }

    private IEnumerator SetActiveFalse( GameObject childObject )
    {
        yield return _destroyDelay;

        childObject.SetActive( false );
    }
}
