using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class StageRecorder : MonoBehaviour
{
    public int captureWidth = 1024;
    public int captureHeight = 680;
    public int captureFrameRate = 30;
    public string outputFolder = @"C:\Users\82103\Videos";
    public string currentString = default;
    public string fileName = "ScreenRecording.mp4";

    private RenderTexture renderTexture;
    private Texture2D texture;
    private bool isRecording = false;

    private void Start()
    {
        Time.captureFramerate = captureFrameRate;
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            StartRecording();
        }

        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            StopRecording();
        }
    }

    private int _index;
    private void FixedUpdate()
    {
        UnityEngine.Debug.Log( isRecording );
        if ( isRecording )
        {
            ScreenCapture.CaptureScreenshotIntoRenderTexture( renderTexture );
            RenderTexture.active = renderTexture;
            texture.ReadPixels( new Rect( 0, 0, captureWidth, captureHeight ), 0, 0 );
            texture.Apply();
            RenderTexture.active = null; 

            currentString = $"frame{_index}.png";
            File.WriteAllBytes( Path.Combine( outputFolder, currentString ), texture.EncodeToPNG() );
            ++_index;
        }
    }

    public void StartRecording()
    {
        renderTexture = new RenderTexture( captureWidth, captureHeight, 1, RenderTextureFormat.ARGB32 );
        texture = new Texture2D( captureWidth, captureHeight, TextureFormat.RGBA32, false );
        isRecording = true;

        if ( File.Exists( Path.Combine( outputFolder, fileName ) ) )
        {
            File.Delete( Path.Combine( outputFolder, fileName ) );
        }
    }

    public void StopRecording()
    {
        isRecording = false;
        Destroy( renderTexture );
        Destroy( texture );

        // Construct FFmpeg command-line arguments
        string inputPattern = Path.Combine( outputFolder, "frame%d.png" );
        string outputFileName = Path.Combine( outputFolder, fileName );
        string arguments = $"-framerate {captureFrameRate} -i {inputPattern} -c:v libx264 -pix_fmt yuv420p -crf 23 -y {outputFileName}";

        Process process = new Process();
        process.StartInfo.FileName = @"C:\ffmpeg\bin\ffmpeg.exe";
        process.StartInfo.Arguments = arguments;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        process.WaitForExit();

        for ( int i = 1; i <= captureFrameRate; i++ )
        {
            File.Delete( Path.Combine( outputFolder, $"frame{i}.png" ) );
        }
    }
}
