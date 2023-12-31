using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;

public class ChaveGeralCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    private GameObject _lever;
    [SerializeField] private bool isOn = false;

    //Original off position
    private Quaternion originalRot;

    //New On position
    private Quaternion newRot;

    private void Awake(){ SimulationManager.OnStateChanged += OnStateChanged; }

    private GameState _gameState;
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Start()
    {
        _inputCtrl = InputCtrl.Instance;

        _lever = this.gameObject;

        // Set the original position and rotation
        originalRot = _lever.transform.rotation;

        //Set the new position on rotation
        newRot = Quaternion.Euler(new Vector3(0, 0, 90f));
    }

    private void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
            {
                if (isOn == false)
                {
                    isOn = true;
                    _lever.transform.localRotation = newRot;
                }
                else
                {
                    isOn = false;
                    _lever.transform.rotation = originalRot;
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
        _lever.transform.rotation = originalRot;
    }

}
