using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;

public class WireOBj : MonoBehaviour
{
    [Header("--- Logic ---")]
    [SerializeField] private InputCtrl _inputCtrl;

    [Header("--- Ports ---")]
    private GameObject _firstPort;
    private GameObject _secondPort;

    private void Awake()
    {
        _firstPort = null;
        _secondPort = null;
        _inputCtrl = InputCtrl.Instance;
        SimulationManager.OnStateChanged += OnStateChanged;
    }

    // Game State subscription 
    private GameState _gameState;
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Update()
    {
        if (_gameState == GameState.WirePlacement)
        {
            if (_inputCtrl.doubleClick == true)
                DestroyOnTouch();
        }

    }

    private void DestroyOnTouch()
    {
        Ray ray;
 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
        }
        else
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject?.name == "Wire" ) 
            {

                _firstPort.GetComponent<PortObj>().isConnected = false;
                _firstPort.GetComponent<PortObj>().connectedTo.Clear();

                _secondPort.GetComponent<PortObj>().isConnected = false;
                _secondPort.GetComponent<PortObj>().connectedTo.Clear();

                Destroy(hit.collider.gameObject);
            }

            if(hit.collider.gameObject.transform.parent?.gameObject.name == "Wire")
            {
                _firstPort.GetComponent<PortObj>().isConnected = false;
                _firstPort.GetComponent<PortObj>().connectedTo.Clear();

                _secondPort.GetComponent<PortObj>().isConnected = false;
                _secondPort.GetComponent<PortObj>().connectedTo.Clear();


                Destroy(hit.collider.gameObject.transform.parent.gameObject);
            }
        }
    }

    public void SetFirstPort(GameObject gameObject){ _firstPort = gameObject; }   

    public void SetSecondPort(GameObject gameObject){ _secondPort = gameObject; }

    public GameObject GetFirstPort() { return  _firstPort; }
    public GameObject GetSecondPort() { return  _secondPort; }

}
