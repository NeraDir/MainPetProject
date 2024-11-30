using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class HiResScreenShots : MonoBehaviour
{
    private bool takeHiResShot = false;

    private Camera cam;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnGetCam;
        DontDestroyOnLoad(gameObject);
    }

    public string ScreenShotName(int width, int height)
    {
        return string.Format($"D:/Screen/IOS/{PlayerSettings.productName}/{width}x{height}/screen_{width}x{height}_{System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.png");
    }

    private void OnGetCam(Scene scene, LoadSceneMode mode)
    {
        cam = FindObjectOfType<Camera>();
    }

    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    private void LateUpdate()
    {
        if(cam == null)
            cam = FindObjectOfType<Camera>();

        if (cam == null)
            return;

        if (Input.GetKeyDown(KeyCode.V))
        {
	        int resWidth = 1320;
            int resHeight = 2868;
            Directory.CreateDirectory($"D:/Screen/IOS/{PlayerSettings.productName}/{resWidth}x{resHeight}");
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            Camera.main.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Camera.main.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            Camera.main.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        }
    }
}