using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QRManager : MonoBehaviour
{
    [SerializeField] private AndroidCodeReaderSample androidCodeReaderSample;

    [SerializeField] private GameObject popUp;
    [SerializeField] private TMP_Text componente;

    // Update is called once per frame
    void Update()
    {
        if (popUp.activeInHierarchy == false && androidCodeReaderSample.lastResult != null && androidCodeReaderSample.lastResult.Length > 3)
        {
            popUp.SetActive(true);
            componente.text = androidCodeReaderSample.lastResult;

        }
    }

    public void ResetCode()
    {

    }

    public void LoadSimulation()
    {
        SceneManager.LoadScene("Simulador");
    }


}
