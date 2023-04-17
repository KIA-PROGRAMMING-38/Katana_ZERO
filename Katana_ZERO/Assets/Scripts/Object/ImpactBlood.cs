using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBlood : MonoBehaviour
{
    [Header("Prefaps")]
    public GameObject[] ImpactBloodPrefaps;
    public List<GameObject> TargetObject;

    private int _bloodCounts;

    private void Awake()
    {
        _bloodCounts = ImpactBloodPrefaps.Length - 1;
        TargetObject = new List<GameObject>();
    }

    public void ImpactCall( int index )
    {
        int randomPick = UnityEngine.Random.Range( 0, _bloodCounts );
        Vector2 normal = TargetObject[index].transform.position - transform.position;
        float reflectAngle = Mathf.Atan2
            ( normal.y, normal.x ) * Mathf.Rad2Deg;
        GameObject gameObject = Instantiate( ImpactBloodPrefaps[randomPick] );
        gameObject.transform.SetPositionAndRotation
            ( TargetObject[index].transform.position, Quaternion.Euler( 0f, 0f, reflectAngle ) );
    }
}
