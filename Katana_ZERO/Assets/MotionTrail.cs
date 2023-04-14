using System.Collections;
using UnityEngine;

public class MotionTrail : MonoBehaviour
{
    public float activeTime = 2f;

    [Header("Mesh Related")]
    public float meshRefreshRate = 0.1f;
    public float meshDestroyDelay = 3f;
    public Transform PositionToSpawn;

    [Header( "Shader Related" )]
    public Material Mat;

    private bool _isTrailActive;

    private SkinnedMeshRenderer[] _skinnedMeshRenderers;

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) && !_isTrailActive )
        {
            // _isTrailActive = true;
            StartCoroutine( ActivateTrail( activeTime ) );
        }
    }

    IEnumerator ActivateTrail(float activeTime )
    {
        while ( activeTime > 0 )
        {
            activeTime -= meshRefreshRate;

            if ( _skinnedMeshRenderers == null )
            {

                _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
                Debug.Log( GetComponentsInChildren<SkinnedMeshRenderer>() );
            }

            for ( int i = 0; i < _skinnedMeshRenderers.Length; ++i )
            {
                GameObject gameObject = new GameObject();
                gameObject.transform.SetPositionAndRotation( PositionToSpawn.position, PositionToSpawn.rotation );

                MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
                MeshFilter mf =  gameObject.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                _skinnedMeshRenderers[i].BakeMesh( mesh );

                mf.mesh = mesh;
                mr.material = Mat;

                Destroy( gameObject, meshDestroyDelay );
            }

            yield return new WaitForSeconds( meshRefreshRate );
        }
    }
}