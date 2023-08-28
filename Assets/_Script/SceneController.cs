using UnityEngine;
using UnityEngine.SceneManagement;
using static QRManager;


public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public static string openWindow;

    [Header("--- Static Variables ---")]
    public static QrResult qrResult;
    public static VideoType videoType;

    public enum VideoType { Servoacionamento, Aplicação, Robo, Tutorial};

    public void Awake(){ Instance = this; }

    public void Start()
    {
        /*
        DateTime expirationDate = new DateTime(2023, 9, 1);
        if(DateTime.Now >= expirationDate){Application.Quit();}
        */
    }

    public void MainMenu(){SceneManager.LoadScene("MainMenu");}

    public void MainMenu(QrResult qrr) {SceneManager.LoadScene("MainMenu"); qrResult = qrr; }

    public void PDF(){SceneManager.LoadScene("PDF");}

    public void Video(){SceneManager.LoadScene("Video");}

    public void QR(){SceneManager.LoadScene("QR");}

    public void Simulation(){SceneManager.LoadScene("Simulation");}

    // -- VÍDEOS -- 

    public void VideoServoacionamento()
    {
        videoType = VideoType.Servoacionamento;
        SceneManager.LoadScene("Video");
    }

    public void VideoAplicação()
    {
        videoType = VideoType.Aplicação;
        SceneManager.LoadScene("Video");
    }

    public void VideoRobo()
    {
        videoType = VideoType.Robo;
        SceneManager.LoadScene("Video");
    }

    public void VideoTutorial()
    {
        videoType = VideoType.Tutorial;
        SceneManager.LoadScene("Video");
    }

}
