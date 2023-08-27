using UnityEngine;
using static SimulationManager;

public class ChaveCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    private WinLogic _winLogic;

    [SerializeField] private GameObject _lever;
    [SerializeField] private bool isOn = false;

    //Original off position
    private Vector3 originalPos;
    private Quaternion originalRot;

    //New On position
    [SerializeField] private Vector3 newPos;
    [SerializeField] private Quaternion newRot;

    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Start()
    {
        _inputCtrl = InputCtrl.Instance;
        _winLogic = WinLogic.Instance;

        _lever = this.gameObject;
        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_gameState == GameState.ParameterPhase)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
            {
                if (isOn == false)
                {
                    isOn = true;
                    _lever.transform.SetLocalPositionAndRotation(newPos, newRot);
                    _winLogic.WinConditions();
                }
                else
                {
                    isOn = false;
                    _lever.transform.SetPositionAndRotation(originalPos, originalRot);
                }
            }
        }
    }

    public bool IsOn()
    {
        return isOn;
    }

    public void TurnOff()
    {
        isOn = false;
        _lever.transform.SetPositionAndRotation(originalPos, originalRot);
    }




}
