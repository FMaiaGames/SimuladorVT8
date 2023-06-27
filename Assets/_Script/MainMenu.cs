using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string url;
    [SerializeField] private GameObject[] _Windows;

    public void OpenWindow(GameObject newWindow)
    {
        newWindow.SetActive(true);
        newWindow.transform.localScale = Vector3.zero;

        //OpenWindowAnim(newWindow);
        StartCoroutine(OpenWindowAnim(newWindow));
    }

    public IEnumerator  OpenWindowAnim(GameObject newWindow)
    {
        float animTime = 0f;
        while(animTime < 1f)
        {
            animTime += Time.deltaTime*7;
            newWindow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, animTime);
            //newWindow.transform.localScale = new Vector3(animTime, animTime, animTime);
            yield return null;
        }
    }

    public async void CloseWindowAnim(GameObject newWindow)
    {
        for (float animTime = 1; animTime >= 0F; animTime -= (Time.deltaTime * 7))
        {
            newWindow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, animTime);
            await Task.Yield();
        }
            newWindow.SetActive(false);
    }

    public void OpenURL()
    {
        StartCoroutine(OpenURLCoroutine());
    }

    private IEnumerator OpenURLCoroutine()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error opening URL: " + webRequest.error);
        }
        else
        {
            // Handle the successful response here
            Debug.Log("URL opened successfully");
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenQRScene()
    {
        SceneManager.LoadScene("QR");
    }

    public void OpenYoutube()
    {

        //Application.OpenURL("https://youtu.be/jViiS1zddtw");
        OpenApp("com.google.android.youtube");
    }

    public void OpenApp(string packageName )
    {
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_MAIN"));
        intentObject.Call<AndroidJavaObject>("setPackage", packageName);

        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        unityActivity.Call("startActivity", intentObject);
    }



}
