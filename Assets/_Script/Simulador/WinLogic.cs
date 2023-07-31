using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using static SimulationManager;

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

    [Header("--- Dispositivos --- ")]
    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    public bool powerOn = false;
    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
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
    public void OnStateChanged(GameState state) { _gameState = state; }


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

    void WireResult()
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

                    if (wObjt.FirstPort.name == "L1" && wObjt.SecondPort.name == "L1")
                        _conditions++;

                    if (wObjt.FirstPort.name == "L2" && wObjt.SecondPort.name == "L2")
                        _conditions++;

                    if (wObjt.FirstPort.name == "PE" && wObjt.SecondPort.name == "PE")
                        _conditions++;

                    if ((wObjt.FirstPort.name == "24vcc" && wObjt.SecondPort.name == "24v") || (wObjt.FirstPort.name == "24v" && wObjt.SecondPort.name == "24vcc"))
                        _conditions++;

                    if ((wObjt.FirstPort.name == "10vcc" && wObjt.SecondPort.name == "10v") || (wObjt.FirstPort.name == "10v" && wObjt.SecondPort.name == "10vcc"))
                        _conditions++;

                    if ((wObjt.FirstPort.name == "0vcc" && wObjt.SecondPort.name == "0v") || (wObjt.FirstPort.name == "0v" && wObjt.SecondPort.name == "0vcc"))
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

    void PowerResult()
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

    void ParameterResult()
    {
        //Retrieve the 15 parameters needed for winning state
        int winningParams = _parameterObj.CheckWinningParams();

        if (winningParams == 15)
            ShowMotorScreen();
        else
            LoseDisplay();
    }

    async void WinDisplay()
    {
        _winingDisplay.SetActive(true);
        await Task.Delay(2000);
        _winingDisplay.SetActive(false);
    }

    async void LoseDisplay()
    {
        _losingDisplay.SetActive(true);
        await Task.Delay(2000);
        SceneController.Instance.Simulation();
    }

    public async void ShowMotorScreen()
    {
        _cameraMovement.enabled = false;
        _motor.SetActive(true);
        _mainCanvas.SetActive(false);
        _congratulationsCanvas.SetActive(true);

        float timer = Time.timeSinceLevelLoad + 2.1f;
        
        while(Time.timeSinceLevelLoad <= timer)
        { 
            _disco.transform.Rotate(Vector3.forward * 600f * Time.deltaTime);

            await Task.Yield();
        }

        await Task.Delay(3000);


        _sceneController.MainMenu();
    }








}
