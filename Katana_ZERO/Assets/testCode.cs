using UnityEngine;

public class testCode : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKey( KeyCode.Alpha1 ) )
        {
            Time.timeScale = Mathf.Clamp( Time.timeScale + 0.01f, 0f, 2f );
        }

        if (Input.GetKey( KeyCode.Alpha2 ) )
        {
            Time.timeScale = Mathf.Clamp( Time.timeScale - 0.01f, 0f, 2f );
        }

        if (Input.GetKey( KeyCode.Alpha3 ) ) 
        {
            Time.timeScale = 1f;
        }

        if ( Input.GetKey( KeyCode.Alpha4 ) )
        {
            Time.timeScale = 0.2f;
        }
    }
}
