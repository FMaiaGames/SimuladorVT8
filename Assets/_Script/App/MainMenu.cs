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

    [SerializeField] private GameObject[] _Windows;

    public void OpenWindow(GameObject newWindow)
    {
        newWindow.SetActive(true);
        newWindow.transform.localScale = Vector3.zero;

        StartCoroutine(OpenWindowAnim(newWindow));
    }

    public IEnumerator  OpenWindowAnim(GameObject newWindow)
    {
        float animTime = 0f;
        while(animTime < 1f)
        {
            animTime += Time.deltaTime*7;
            newWindow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, animTime);
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


}
