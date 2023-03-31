using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 primitiveVec;

    public void OnMove( InputValue value )
    {
        primitiveVec = value.Get<Vector2>();

        Debug.Log( primitiveVec );
    }
}
