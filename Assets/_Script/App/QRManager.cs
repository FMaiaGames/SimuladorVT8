using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QRManager : MonoBehaviour
{
    public enum QrResult { None, Aplication, Simulation, Disjuntor, Driver, Encoder, Servo, Fonte };

    [SerializeField] private AndroidCodeReaderSample _androidCodeReaderSample;
    [SerializeField] private SceneController _sceneController;

    [SerializeField] private GameObject _popUp;
    [SerializeField] private TMP_Text _componente;
    [SerializeField] private QrResult _qrResult;

    void Update()
    {
        if (_popUp.activeInHierarchy == false && _androidCodeReaderSample.lastResult != null && _androidCodeReaderSample.lastResult.Length > 3)
        {

            _androidCodeReaderSample.enabled = false;
            print("QR: " + _androidCodeReaderSample.lastResult);

            if (string.Compare("VT8/2023005/APLICACAO", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Aplicação";
                _qrResult = QrResult.Aplication;
            }

            if (string.Compare("VT8/2023005/DISJUNTOR", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Disjuntor";
                _qrResult = QrResult.Disjuntor;
            }

            if (string.Compare("VT8/2023005/DRIVER", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Driver";
                _qrResult = QrResult.Driver;
            }

            if (string.Compare("VT8/2023005/ENCODER", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Encoder";
                _qrResult = QrResult.Encoder;
            }

            if (string.Compare("VT8/2023005/SERVO", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Servo Motor";
                _qrResult = QrResult.Servo;
            }

            if (string.Compare("VT8/2023005/FONTE", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Fonte";
                _qrResult = QrResult.Fonte;
            }


            if (string.Compare("VT8/2023005/SIMULADOR", _androidCodeReaderSample.lastResult) == 0)
            {
                _popUp.SetActive(true);
                _componente.text = "Simulador";
                _qrResult = QrResult.Simulation;
            }

        }
    }

    public void LoadQRCode()
    {
        switch (_qrResult)
        {
            case QrResult.Aplication:
                _sceneController.MainMenu(QrResult.Aplication);
                break;

            case QrResult.Disjuntor:
                _sceneController.MainMenu(QrResult.Disjuntor);
                break;

            case QrResult.Driver:
                _sceneController.MainMenu(QrResult.Driver);
                break;

            case QrResult.Encoder:
                _sceneController.MainMenu(QrResult.Encoder);
                break;

            case QrResult.Servo:
                _sceneController.MainMenu(QrResult.Servo);
                break;

            case QrResult.Fonte:
                _sceneController.MainMenu(QrResult.Fonte);
                break;

             case QrResult.Simulation:
                _sceneController.Simulation();
                break;
    }
    }

    public void LoadQRCode2()
    {
        _sceneController.MainMenu(QrResult.Disjuntor);
    }

    public void ClosePopup()
    {
        _popUp.SetActive(false);
        _androidCodeReaderSample.enabled = true;

        if (_androidCodeReaderSample.lastResult != null)
            _androidCodeReaderSample.lastResult = null;

    }


}
