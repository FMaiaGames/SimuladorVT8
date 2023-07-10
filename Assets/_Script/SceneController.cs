using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu(){SceneManager.LoadScene("MainMenu");}

    public void PDF(){SceneManager.LoadScene("PDF");}

    public void Video(){SceneManager.LoadScene("Video");}

    public void QR(){SceneManager.LoadScene("QR");}

    public void Simulation(){SceneManager.LoadScene("Simulador");}

}
