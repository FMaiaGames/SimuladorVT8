using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static SimulationManager;

public class EmergencyStopCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    [SerializeField] private float _pressDepth;
    [SerializeField] private Light _emergencyLight;

    bool isPressed;


    // Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }


    void Start()
    {
        _inputCtrl = InputCtrl.Instance;
        _emergencyLight.enabled = false;
    }

    void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
            {
                if (isPressed == false)
                {
                    isPressed = true;
                    PressStay(_pressDepth);
                }
                else
                {
                    isPressed = false;
                    ReleaseStay();
                }
            }

            if(isPressed == true)
            {
                _ligDesligCtrl.isOn = false;
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
        _emergencyLight.enabled = true;
    }

    async void ReleaseStay()
    {
        _emergencyLight.enabled = false;

        Transform trans = this.gameObject.transform;
        while (trans.localPosition.y < 0f)
        {
            trans.Translate(0, 0, 0 + 0.0005f, Space.Self);
            await Task.Yield();
        }
    }


}
