using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action SetGameOverEffect;

    public static void GetGameOverState()
    {
        SetGameOverEffect?.Invoke();
    }
}
