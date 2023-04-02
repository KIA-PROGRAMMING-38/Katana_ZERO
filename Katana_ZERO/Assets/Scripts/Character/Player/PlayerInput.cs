using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 primitiveMoveVec;
    public Vector2 primitiveJumpVec;

    public void OnMove( InputValue value )
    {
        primitiveMoveVec = value.Get<Vector2>();
    }

    public void OnJump( InputValue value )
    {
        primitiveJumpVec = value.Get<Vector2>();
    }
}
