using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{

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

    public void ScrollBackward()
    {
        videoPlayer.frame -= (long)120f;
    }

    public void ScrollForward()
    {
        videoPlayer.frame += (long)120f;
    }

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

    public void ExitScene()
    {
        SceneManager.LoadScene(0);
    }





}
