using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static SimulationManager;

public class LigDesligCtrl : MonoBehaviour
{
    [Header("--- Logical --- ")]
    [SerializeField] private InputCtrl _inputCtrl;
    [SerializeField] private LogicalCtrl _logicalCtrl;
    [SerializeField] private EmergencyStopCtrl _emergencyStopCtrl;
    [SerializeField] private bool _isOn = false;

    [Header("--- Position & Rotation--- ")]
    [SerializeField] private GameObject _lever;

    //Original off position
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Quaternion originalRot;

    //New On position
    [SerializeField] private Vector3 newPos;
    [SerializeField] private Quaternion newRot;


    private void Awake()
    {
        SimulationManager.OnStateChanged += OnStateChanged;

        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);
    }
    // Game State subscription 
    private GameState _gameState;
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state) { _gameState = state; }

    void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            //Check is the previous logic point is active first
            if (_logicalCtrl.GetTrioStatus() && _emergencyStopCtrl.GetEmergencyStatus() == false)
            {
                if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
                {
                    if (_isOn == false)
                    {
                        _isOn = true;
                        _lever.transform.SetLocalPositionAndRotation(newPos, newRot);
                    }
                    else
                    {
                        _isOn = false;
                        _lever.transform.SetPositionAndRotation(originalPos, originalRot);
                    }
                }
            }
            else
            {
                _isOn = false;
                _lever.transform.SetPositionAndRotation(originalPos, originalRot);
            }
        }
    }

    public bool IsOn()
    {
        return _isOn;
    }

    public void TurnOff()
    {
        _isOn = false;
        _lever.transform.SetPositionAndRotation(originalPos, originalRot);
    }


}
