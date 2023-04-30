using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoCollector : MonoBehaviour
{
    public int CurrentEnemyCount;

    private void Awake()
    {
        CommonEnemyController.SetCurrentEnemyCount -= CountEnemy;
        CommonEnemyController.SetCurrentEnemyCount += CountEnemy;
        KissyfaceController.KissyCountInvoke -= CountEnemy;
        KissyfaceController.KissyCountInvoke += CountEnemy;
        GunProperty.GunEnemyDieInvoke -= DieEnemyCount;
        GunProperty.GunEnemyDieInvoke += DieEnemyCount;
        KnifeProperty.KnifeEnemyDieInvoke -= DieEnemyCount;
        KnifeProperty.KnifeEnemyDieInvoke += DieEnemyCount;
        GruntProperty.GruntEnemyDieInvoke -= DieEnemyCount;
        GruntProperty.GruntEnemyDieInvoke += DieEnemyCount;
        KissyfaceController.KissyDieInvoke -= DieEnemyCount;
        KissyfaceController.KissyDieInvoke += DieEnemyCount;
    }

    private void CountEnemy()
    {
        ++CurrentEnemyCount;
    }

    private void DieEnemyCount()
    {
        --CurrentEnemyCount;

        if ( CurrentEnemyCount == 0 )
        {
            GameManager.Instance.IsGameClear = true;
        }
    }

    private void OnDestroy()
    {
        CommonEnemyController.SetCurrentEnemyCount -= CountEnemy;
        KissyfaceController.KissyCountInvoke -= CountEnemy;
        GunProperty.GunEnemyDieInvoke -= DieEnemyCount;
        KnifeProperty.KnifeEnemyDieInvoke -= DieEnemyCount;
        GruntProperty.GruntEnemyDieInvoke -= DieEnemyCount;
        KissyfaceController.KissyDieInvoke -= DieEnemyCount;
    }
}
