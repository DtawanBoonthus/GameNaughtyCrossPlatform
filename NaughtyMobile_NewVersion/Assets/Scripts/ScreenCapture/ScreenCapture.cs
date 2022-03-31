using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCapture : MonoBehaviour
{
    public int CaptureWidth = 1920;
    public int CaptureHeight = 1080;

    public enum Format
    {
        RAW,
        JPG,
        PNG,
        PPM
    }

    public Format FormatImage = Format.JPG;
    
    private string outputFolder;

    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenShot;
    //private byte[] currentTexture;

    public bool IsProcressing;

    //private Image showImage;
    
    private void Start()
    {
        outputFolder = Application.persistentDataPath + "/Screenshots";

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
            Debug.Log($"Save Path will be : {outputFolder}");
        }
    }

    private string CreateFile(int width, int height)
    {
        string timestamp = DateTime.Now.ToString("yyyMMddTHHmmss");

        var filename =
            string.Format($"{outputFolder}/screen_{width}x{height}_{timestamp}.{FormatImage.ToString()}");
        return filename.ToLower();
    }

    private void CaptureScreenshot()
    {
        IsProcressing = true;

        if (renderTexture == null)
        {
            rect = new Rect(0, 0, CaptureWidth, CaptureHeight);
            renderTexture = new RenderTexture(CaptureWidth, CaptureHeight, 24);
            screenShot = new Texture2D(CaptureWidth, CaptureHeight, TextureFormat.RGB24, false);
        }

        Camera camera = Camera.main;
        camera.targetTexture = renderTexture;
        camera.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);

        camera.targetTexture = null;
        RenderTexture.active = null;

        string filename = CreateFile((int) rect.width, (int) rect.height);

        byte[] fileHeader = null;
        byte[] fileData = null;

        if (FormatImage == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (FormatImage == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (FormatImage == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else
        {
            string headerStr = string.Format($"P6\n{rect.width} {rect.height}\n255\n");
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }

        //currentTexture = fileData;
        
        new System.Threading.Thread(() =>
        {
            var file = File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log(string.Format($"Screenshot saved {filename}, size {fileData.Length}"));
            IsProcressing = false;
        }).Start();

        //StartCoroutine(ShowImage(filename));
        
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
    }

    public void TakeScreenShot()
    {
        if (!IsProcressing)
        {
            CaptureScreenshot();
        }
        else
        {
            Debug.Log("Currently Processing");
        }
    }

    /*public IEnumerator ShowImage(string filename)
    {
        yield return new WaitForEndOfFrame();
        showImage.material.mainTexture = null;
        Texture2D tex;
        tex = new Texture2D(CaptureWidth, CaptureHeight, TextureFormat.RGB24, false);
        Debug.Log(filename);
        yield return filename;

        WWW www = new WWW(filename);
        yield return www;
        tex.LoadImage(currentTexture);
        showImage.material.mainTexture = tex;

        showImage.gameObject.SetActive(true);
    }*/
}
