using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKey( KeyCode.Alpha3 ) )
        {
            Time.timeScale = 1f;

            Debug.Log( $"TimeScale : {Time.timeScale}" );
        }

        if ( Input.GetKey( KeyCode.Alpha4 ) )
        {
            Time.timeScale = 0.2f;

            Debug.Log( $"TimeScale : {Time.timeScale}" );
        }
    }
}
