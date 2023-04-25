using System.Collections;
using UnityEngine;

public class LogoFlash : MonoBehaviour
{
    [SerializeField]
    [Range( 0f, 2f )]
    private float _flashInterval_ZER1;
    [SerializeField]
    [Range( 0f, 2f )]
    private float _flashInterval_ZER2;

    private IEnumerator _flashCoroutineZER;
    private IEnumerator _flashCoroutineO;

    [SerializeField] private GameObject BackGroundElectronicDisplayZER;
    [SerializeField] private GameObject ElectronicDisplayZER;
    [SerializeField] private GameObject BackGroundElectronicDisplayO;
    [SerializeField] private GameObject ElectronicDisplayO;

    private void Awake()
    {
        if ( _flashCoroutineZER != null )
        {
            StopCoroutine( _flashCoroutineZER );
        }

        _flashCoroutineZER = TitleFlashLogo_ZER();
        StartCoroutine( _flashCoroutineZER );

        if ( _flashCoroutineO != null )
        {
            StopCoroutine( _flashCoroutineO );
        }

        _flashCoroutineO = TitleFlashLogo_O();
        StartCoroutine( _flashCoroutineO );
    }

    private IEnumerator TitleFlashLogo_ZER()
    {
        while ( true )
        {
            yield return new WaitForSeconds( _flashInterval_ZER1 );

            BackGroundElectronicDisplayZER.SetActive( false );
            ElectronicDisplayZER.SetActive( false );

            yield return new WaitForSeconds( _flashInterval_ZER2 );

            BackGroundElectronicDisplayZER.SetActive( true );
            ElectronicDisplayZER.SetActive( true );
        }
    }


    private IEnumerator TitleFlashLogo_O()
    {
        yield return new WaitForSeconds( _flashInterval_ZER2 );

    }
}
