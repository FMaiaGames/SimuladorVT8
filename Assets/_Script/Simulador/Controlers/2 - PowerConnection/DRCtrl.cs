using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;

public class DRCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    [SerializeField] private GameObject _lever;
    public bool isOn = false;

    [Header("--- Positions --- ")]
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Vector3 newPos;
    private Quaternion newRot;


    
    // Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state) { _gameState = state; }

    // --- THE NEXT LOGIC NODE IS DisjuntorCtrl

    void Start()
    {
        _inputCtrl = InputCtrl.Instance;

        // Set the original position and rotation
        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);

        //Set the new position on rotation of the on position 
        newPos = new Vector3(0.000495f, -0.000166f, 1.4e-05f); 
        newRot = Quaternion.Euler(new Vector3(0f, 0f, -180f) ); 
    }

    void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
            {
                if (isOn == false)
                {
                    isOn = true;
                    _lever.transform.SetLocalPositionAndRotation(newPos, newRot);
                }
                else
                {
                    isOn = false;
                    _lever.transform.SetPositionAndRotation(originalPos, originalRot);
                }
            }

            if(isOn == false)
                _lever.transform.SetPositionAndRotation(originalPos, originalRot);

        }
    }
}
