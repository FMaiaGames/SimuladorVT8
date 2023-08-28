using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static SimulationManager;

public class LigDesligCtrl : MonoBehaviour
{
    [Header("--- Logical --- ")]
    private InputCtrl _inputCtrl;
    [SerializeField] private LogicalCtrl _logicalCtrl;
    [SerializeField] private EmergencyStopCtrl _emergencyStopCtrl;

    [Header("--- Position & Rotation--- ")]
    [SerializeField] private GameObject _lever;

    //Original off position
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Quaternion originalRot;

    //New On position
    [SerializeField] private Vector3 newPos;
    [SerializeField] private Quaternion newRot;

    [Header("--- Misc --- ")] 
    [SerializeField] private bool _isOn = false;

    void Awake()
    {
        _inputCtrl = InputCtrl.Instance;
        SimulationManager.OnStateChanged += OnStateChanged;

        _lever = this.gameObject;
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
                        StartCoroutine(Press(8.6e-05f));
                    else
                        StartCoroutine(Press(8.6e-05f));
                }
            }
            else
            {
                _isOn = false;
            }
        }
    }

    //Press a button down and call the opposite movement later
    public IEnumerator Press(float PressDepth)
    {
        Transform trans = this.gameObject.transform;
        while (trans.localPosition.y <= PressDepth)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            trans.Translate(0, 0 + 240.0e-06f, 0, Space.Self);
            yield return null;
        }

        if (_isOn == false)
            _isOn = true;
        else
            _isOn = false;

        StartCoroutine(Release(trans));
    }

    public IEnumerator Release(Transform trans)
    {
        while (trans.localPosition.y >= 0f)
        {
            trans.Translate(0, 0 - 240.0e-06f, 0, Space.Self);
            yield return null;
        }
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    public bool IsOn()
    {
        return _isOn;
    }
}
