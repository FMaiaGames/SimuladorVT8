using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;

public class ChaveGeralCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    private GameObject _manopla;

    // --- Transform ---
    private Quaternion originalRot;
    private Quaternion newRot;

    // --- Logic ---
    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    public bool isOn = false;

    private void Awake()
    {
        _inputCtrl = InputCtrl.Instance;
        _manopla = this.gameObject;
        originalRot = _manopla.transform.rotation;

        newRot = Quaternion.Euler(new Vector3(0, 0, 90f));

        SimulationManager.OnStateChanged += OnStateChanged;
    }

    private GameState _gameState;
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state) { _gameState = state; }


    void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            //Check is the previous logic point is active first
            if(_disjuntorCtrl.isOn)
            {
                if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
                {
                    if (isOn == false)
                    {
                        isOn = true;
                        _manopla.transform.localRotation = newRot;
                    }
                    else
                    {
                        isOn = false;
                        _manopla.transform.rotation = originalRot;
                    }
                }
            }
            else
            {
                isOn = false;
                _manopla.transform.rotation = originalRot;
            }
        }
    }

}
