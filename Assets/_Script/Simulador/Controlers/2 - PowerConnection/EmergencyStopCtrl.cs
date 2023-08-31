using System.Threading.Tasks;
using UnityEngine;
using static SimulationManager;

public class EmergencyStopCtrl : MonoBehaviour
{
    [Header("--- Logical --- ")]
    private InputCtrl _inputCtrl;
    [SerializeField] private LogicalCtrl _logicalCtrl;
    [SerializeField] private LigDesligCtrl _ligDesligCtrl;

    [Header("--- Misc --- ")]
    [SerializeField] private float _pressDepth;
    [SerializeField] private Light _emergencyLight;

    [SerializeField] private bool _isPressed;

    // Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Start()
    {
        _inputCtrl = InputCtrl.Instance;
        _emergencyLight.enabled = false;
    }

    private void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            if (_logicalCtrl.GetTrioStatus() == true)
            {
                if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
                {
                    if (_isPressed == false)
                        PressStay(_pressDepth);
                    else
                        ReleaseStay();
                }
            }
            else
            {
                ReleaseStay();
            }
        }
    }

    async void PressStay(float pressDepth)
    {
        Transform trans = this.gameObject.transform;
        while (trans.localPosition.z >= pressDepth)
        {
            trans.Translate(0, 0, 0 - 0.0005f, Space.Self);
            await Task.Yield();
        }
        _isPressed = true;
        _emergencyLight.enabled = true;
    }

    async void ReleaseStay()
    {
        _isPressed = false;
        _emergencyLight.enabled = false;

        Transform trans = this.gameObject.transform;
        while (trans.localPosition.y < 0f)
        {
            trans.Translate(0, 0, 0 + 0.0005f, Space.Self);
            await Task.Yield();
        }
    }

    public bool GetEmergencyStatus()
    {
        return _isPressed;
    }

}
