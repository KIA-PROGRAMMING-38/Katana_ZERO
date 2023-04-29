using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataHelper
{
 

    public static AudioClip LoadBGMClipHelper( string soundName )
    {
        string filePath = Path.Combine( "Audio", $"{soundName}" );

        return Resources.Load<AudioClip>( filePath );
    }
}
