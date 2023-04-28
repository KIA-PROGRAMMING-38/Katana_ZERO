using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SpriteRenderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine( foo( 1f, -2f, 7f ) );
        }
    }

    private float _elapsedFadeTime;
    private static readonly int SPLIT_VALUE = Shader.PropertyToID( "_SplitValue" );
    IEnumerator foo(float start, float dest, float time)
    {
        _elapsedFadeTime = 0f;

        while ( _elapsedFadeTime <= time )
        {
            float newValue = EaseUtil.EaseInOutCubic( start, dest, _elapsedFadeTime / time );
            _renderer.material.SetFloat( SPLIT_VALUE, newValue );

            _elapsedFadeTime += Time.deltaTime;

            yield return null;
        }
    }
}
