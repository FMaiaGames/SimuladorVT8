using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    public void Awake(){ Instance = this; }

    public void Start()
    {
        /*
        DateTime expirationDate = new DateTime(2023, 9, 1);
        if(DateTime.Now >= expirationDate){Application.Quit();}
        */
    }

    public void MainMenu(){SceneManager.LoadScene("MainMenu");}

    public void PDF(){SceneManager.LoadScene("PDF");}

    public void Video(){SceneManager.LoadScene("Video");}

    public void QR(){SceneManager.LoadScene("QR");}

    public void Simulation(){SceneManager.LoadScene("Simulador");}

    public void OnCollisionExit(Collision collision){Application.Quit();}
}
