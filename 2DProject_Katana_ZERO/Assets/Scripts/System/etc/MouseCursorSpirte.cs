using UnityEngine;
using Util;

public class MouseCursorSpirte : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = GlobalData.MouseWorldPos;
    }
}
