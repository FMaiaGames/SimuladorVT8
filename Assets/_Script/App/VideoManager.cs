using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using static QRManager;
using static SceneController;

public class VideoManager : MonoBehaviour
{
    [Header("--- Logic ---")]
    public VideoPlayer videoPlayer;
    public Slider slider;
    public float progress;

    [Header("--- Buttons ---")]
    public GameObject btnPlay;
    public GameObject btnPause;

    private void Start()
    {
        btnPause.SetActive(true);
        btnPlay.SetActive(false);

        switch (SceneController.videoType)
        {
            case VideoType.Servoacionamento:
                videoPlayer.url = "https://www.filipemaia.com/acervo/entrega/vt8/videos/Servoacionamento.mp4";
                break;

            case VideoType.Aplicação:
                videoPlayer.url = "https://www.filipemaia.com/acervo/entrega/vt8/videos/aplica.mp4";
                break;

            case VideoType.Robo:
                videoPlayer.url = "https://www.filipemaia.com/acervo/entrega/vt8/videos/robo.mp4";
                break;
 
            case VideoType.Tutorial:
                videoPlayer.url = "https://www.filipemaia.com/acervo/entrega/vt8/videos/video.mp4";
                break;
        }

    }
    private void Update()
    {
        if (videoPlayer.isPlaying)
        {
            slider.maxValue = videoPlayer.frameCount;
            progress = (float)videoPlayer.frame;
            slider.value = (float)videoPlayer.frame;
        }
    }

    public void ScrollBackward() { videoPlayer.frame -= (long)120f; }

    public void ScrollForward() { videoPlayer.frame += (long)120f; }
    
    public void ExitScene() { SceneManager.LoadScene(0); }

    public void VideoStop()
    {
        videoPlayer.Pause();
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    public void VideoPlay()
    {
        videoPlayer.Play();
        btnPause.SetActive(true);
        btnPlay.SetActive(false);
    }






}
