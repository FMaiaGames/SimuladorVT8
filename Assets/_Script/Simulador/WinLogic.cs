using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SimulationManager;
using System.Collections;

public class WinLogic : MonoBehaviour
{
    private GameObject[] _wires;
    private int _conditions = 0;

    [Header("--- Logic --- ")]
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private SceneController _sceneController;

    [Header("--- UI --- ")]
    [SerializeField] private GameObject _winingDisplay;
    [SerializeField] private GameObject _losingDisplay;

    [Header("--- Devices --- ")]
    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    [SerializeField] private DRCtrl _dRCtrl;
    [SerializeField] private ParameterObj _parameterObj;

    [Header("--- WinLogic --- ")]
    [SerializeField] private GameObject _motor;
    [SerializeField] private GameObject _disco;
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _congratulationsCanvas;

    // Game State subscription 
    private GameState _gameState;

    private void Awake(){ SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    public void WinConditions()
    {
        switch (_gameState)
        {
            case GameState.WirePlacement:
                WireResult();
                break;
            case GameState.PowerConnection:
                PowerResult();
                break;
            case GameState.ParameterPhase:
                ParameterResult();
                break;
            case GameState.EndGame:
                break;
        }

    }

    private void WireResult()
    {
        _conditions = 0;
        _wires = null;
        _wires = GameObject.FindGameObjectsWithTag("Wire");

        if (_wires != null && _wires.Length >= 1)
        {
            // CHECK WIRES CONNECTIONS
            foreach (GameObject wire in _wires)
            {
                if (wire != null && wire.GetComponent<WireOBj>() != null)
                {
                    var wObjt = wire.GetComponent<WireOBj>();

                    if (wObjt.GetFirstPort().name == "L1" && wObjt.GetSecondPort().name == "L1")
                        _conditions++;

                    if (wObjt.GetFirstPort().name == "L2" && wObjt.GetSecondPort().name == "L2")
                        _conditions++;

                    if (wObjt.GetFirstPort().name == "PE" && wObjt.GetSecondPort().name == "PE")
                        _conditions++;

                    if ((wObjt.GetFirstPort().name == "24vcc" && wObjt.GetSecondPort().name == "24v") || (wObjt.GetFirstPort().name == "24v" && wObjt.GetSecondPort().name == "24vcc"))
                        _conditions++;

                    if ((wObjt.GetFirstPort().name == "10vcc" && wObjt.GetSecondPort().name == "10v") || (wObjt.GetFirstPort().name == "10v" && wObjt.GetSecondPort().name == "10vcc"))
                        _conditions++;

                    if ((wObjt.GetFirstPort().name == "0vcc" && wObjt.GetSecondPort().name == "0v") || (wObjt.GetFirstPort().name == "0v" && wObjt.GetSecondPort().name == "0vcc"))
                        _conditions++;
                }
            }

            //SHOW RESULT
            if (_conditions == 6)
            {
                WinDisplay();
                SimulationManager.Instance.UpdateGameState(GameState.PowerConnection);
            }
            else
                LoseDisplay();
        }
        else
        {
            LoseDisplay(); 
        }
    }

    private void PowerResult()
    {
        //Check is the main power node is powered and ready
        if (_ligDesligCtrl.isOn == true)
        {
            WinDisplay();
            SimulationManager.Instance.UpdateGameState(GameState.ParameterPhase);
        }
        else
            LoseDisplay();
    }

    private void ParameterResult()
    {
        if (_parameterObj.CheckWinningParams() == true)
            FinalWin();
        else
            LoseDisplay();
    }

    private async void WinDisplay()
    {
        _winingDisplay.SetActive(true);
        await Task.Delay(2000);
        _winingDisplay.SetActive(false);
    }

    private async void LoseDisplay()
    {
        _losingDisplay.SetActive(true);
        await Task.Delay(2000);

        //SceneController.Instance.Simulation();

        switch (_gameState)
        {
            case GameState.WirePlacement:
                SceneController.Instance.Simulation();
                _losingDisplay.SetActive(false);
                break;
            case GameState.PowerConnection:
                _dRCtrl.isOn = false;
                _losingDisplay.SetActive(false);
                break;
            case GameState.ParameterPhase:
                _parameterObj.DeleteParameters();
                _losingDisplay.SetActive(false);
                break;
            case GameState.EndGame:
                _losingDisplay.SetActive(false);
                break;
        }
    }

    public void FinalWin(){ StartCoroutine(ShowMotorScreen()); }

    public IEnumerator ShowMotorScreen()
    {
        _cameraMovement.enabled = false;
        _motor.SetActive(true);
        _mainCanvas.SetActive(false);
        _congratulationsCanvas.SetActive(true);

        float timer = Time.timeSinceLevelLoad + 2.1f;

        while (Time.timeSinceLevelLoad <= timer)
        {
            _disco.transform.Rotate(Vector3.forward * 600f * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(3f);

        _sceneController.MainMenu();
    }






}
