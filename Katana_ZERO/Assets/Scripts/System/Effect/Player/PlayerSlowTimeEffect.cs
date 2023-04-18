using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerSlowTimeEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private PlayerData _playerData;
    [SerializeField]
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _effectSprite;
    private Light2D _light;

    private void Awake()
    {
        _effectSprite = GetComponent<SpriteRenderer>();
        _playerData = _player.GetComponent<PlayerData>();
        _light = GetComponent<Light2D>();
        gameObject.SetActive( false );
    }

    private void Update()
    {
        _effectSprite.sprite = _playerSprite.sprite;
        transform.position = _player.transform.position;
        transform.rotation = _player.transform.rotation;
        _light.lightCookieSprite = _effectSprite.sprite;
    }
}
