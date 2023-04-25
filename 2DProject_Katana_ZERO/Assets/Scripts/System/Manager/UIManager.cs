using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;
    [SerializeField]
    private Image _gameProgressTimer;
    [SerializeField]
    private GameObject[] _batteryComponents;

    private Stack<Image> _alreadyUsedbatterySprite = new Stack<Image>();
    private Stack<Image> _unUsedbatterySprite = new Stack<Image>();

    private float _maxSlowTimeValue = 8;
    private float _maxBatteryCount = 11;

    private float _defaultMod;
    private float _elapsedTime;

    private void Awake()
    {
        _defaultMod = _maxSlowTimeValue / _maxBatteryCount;

        foreach ( GameObject elem in _batteryComponents )
        {
            _unUsedbatterySprite.Push( elem.GetComponent<Image>() );
        }

        _timeManager.AllUsedSlowTime -= UseBattery;
        _timeManager.AllUsedSlowTime += UseBattery;
    }
  

    private void Update()
    {
        float deltaTime = Time.unscaledDeltaTime;

        float remainingNormalize = _timeManager.RemainingTime / 100f;
        _gameProgressTimer.fillAmount = remainingNormalize;

        if ( _timeManager.IsPressed )
        {
            _elapsedTime += deltaTime;

            if ( _elapsedTime >= _defaultMod )
            {
                UseBattery();
            }
        }
        else if ( !_timeManager.IsPressed && 
            _timeManager.PossibleSlowTime < _timeManager.MaxElapsedTime )
        {
            _elapsedTime -= deltaTime;

            if ( _elapsedTime <= 0f )
            {
                //ReturnBattery();
            }
        }

        if ( _alreadyUsedbatterySprite.Count != 0 && 
            _timeManager.PossibleSlowTime == _timeManager.MaxElapsedTime )
        {
            ReturnBattery();
        }
    }

    private void UseBattery()
    {
        Image currentBatteryComponent = _unUsedbatterySprite.Pop();
        currentBatteryComponent.color = Color.red;
        _alreadyUsedbatterySprite.Push( currentBatteryComponent );
        _elapsedTime = 0f;
    }

    private void ReturnBattery()
    {
        Image currentBatteryComponent = _alreadyUsedbatterySprite.Pop();
        currentBatteryComponent.color = Color.white;
        _unUsedbatterySprite.Push( currentBatteryComponent );
        _elapsedTime = _defaultMod;
    }
}
