using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;
    [SerializeField]
    private Image _gameProgressTimer;

    private void Update()
    {
        float remainingNormalize = _timeManager.RemainingTime / 100f;
        _gameProgressTimer.fillAmount = remainingNormalize;
    }
}
