using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static QRManager;


public class MainMenu : MonoBehaviour
{
    private SceneController _sceneController;
    [SerializeField] private GameObject[] _windows;

    private void Start()
    {
        _sceneController = SceneController.Instance;

        QrResult qrResult = SceneController.qrResult;

        switch (qrResult)
        {
            case QrResult.Disjuntor:
                SceneController.qrResult = QrResult.None;
                OpenWindow(_windows[1]);
                break;
            case QrResult.Driver:
                SceneController.qrResult = QrResult.None;
                OpenWindow(_windows[3]);
                break;
            case QrResult.Encoder:
                SceneController.qrResult = QrResult.None;
                OpenWindow(_windows[5]);
                break;
            case QrResult.Servo:
                SceneController.qrResult = QrResult.None;
                OpenWindow(_windows[7]);
                break;
            case QrResult.Fonte:
                SceneController.qrResult = QrResult.None;
                OpenWindow(_windows[9]);
                break;
        }

    }

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
