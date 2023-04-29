using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBlood : MonoBehaviour
{
    [Header("Prefaps")]
    public GameObject[] DrawBloodPrefaps;
    public List<GameObject> TargetObject;

    [Header( "Count Data" )]
    [SerializeField][Range(0f, 2f)]
    private float _intervalTime;

    private WaitForSeconds _drawTime;
    private int _bloodCounts;

    private void Awake()
    {
        _bloodCounts = DrawBloodPrefaps.Length - 1;
        _drawTime = new WaitForSeconds( _intervalTime );
        TargetObject = new List<GameObject>();
    }

    private IEnumerator _initialCoroutine;
    private int _indexRepo;
    public void StartDrawBlood( int index )
    {
        if ( null != _initialCoroutine )
        {
            StopCoroutine( _initialCoroutine );
        }

        _indexRepo = index;
        _initialCoroutine = DrawStart();
        StartCoroutine( _initialCoroutine );
    }

    public void StopDrawBlood()
    {
        if ( _initialCoroutine != null )
        {
            StopCoroutine( _initialCoroutine );
        }
    }

    private IEnumerator DrawStart()
    {
        while ( true )
        {
            int randomPick = UnityEngine.Random.Range( 0, _bloodCounts );
            GameObject gameObject = Instantiate( DrawBloodPrefaps[randomPick] );
            gameObject.transform.SetPositionAndRotation
                ( TargetObject[_indexRepo].transform.position, TargetObject[_indexRepo].transform.rotation );

            yield return _drawTime;
        }
    }
}
