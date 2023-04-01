using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 primitiveMoveVec;
    public Vector2 primitiveJumpPower;

    public void OnMove( InputValue value )
    {
        primitiveMoveVec = value.Get<Vector2>();
    }

    public void OnJump( InputValue value )
    {
        primitiveJumpPower = value.Get<Vector2>();
    }
}
