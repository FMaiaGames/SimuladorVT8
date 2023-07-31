using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;
using static UnityEngine.GraphicsBuffer;

public class DisjuntorCtrl : MonoBehaviour
{
    private InputCtrl inputCtrl;

    [Header("--- Logic ---")]
    private DRCtrl _drCtrl; //Previous logic node
    public bool isOn = false;

    [Header("--- Lever ---")]
    [SerializeField] private GameObject _lever;

    private Vector3 originalPos;
    private Quaternion originalRot;

    private Vector3 newPos;
    private Quaternion newRot;

    // Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state) { _gameState = state; }

    private void Start()
    {
        inputCtrl = InputCtrl.Instance;
        _drCtrl = FindObjectOfType<DRCtrl>();
 
        _lever = this.gameObject.transform.GetChild(0).gameObject;
        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);

        newPos = new Vector3(0, -0.000193999993f, 0);
        newRot = Quaternion.Euler(new Vector3(-1.70732858e-06f, 1.29647461e-07f, 179.804337f));
    }

    void Update()
    {
        if (_gameState == GameState.PowerConnection) 
        {
            if(_drCtrl.isOn == true)
            {
                if (inputCtrl.click && inputCtrl.currentObject == this.gameObject)
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

            }
            else
            {
                isOn = false;
                _lever.transform.SetPositionAndRotation(originalPos, originalRot);
            }
        }
    }








}
