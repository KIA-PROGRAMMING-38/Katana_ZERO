using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKeyUp( KeyCode.LeftShift ) )
        {
            Time.timeScale = 1f;
        }

        if ( Input.GetKey( KeyCode.LeftShift ) )
        {
            Time.timeScale = 0.2f;
        }
    }
}
