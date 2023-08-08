using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;
using static UnityEngine.XR.OpenXR.Features.Interactions.HTCViveControllerProfile;

public class CableCtrl : MonoBehaviour
{
    [Header("---Logic---")]
    [SerializeField] private InputCtrl _inputCtrl;
    [SerializeField] private GameObject _currentObj;

    [Header("---Prefabs---")]
    [SerializeField] private GameObject _plugPrefab;
    [SerializeField] private GameObject _wirePointPrefab;

    [Header("---Ports---")]
    [SerializeField] private GameObject _firstPort;
    [SerializeField] private GameObject _secondPort;

    [Header("---Plugs---")]
    [SerializeField] public GameObject FirstPlug;
    [SerializeField] private GameObject _secondPlug;

    // Game State subscription 
    private GameState _gameState;
    private void Awake(){SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy(){SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state){_gameState = state;}

    void Update()
    {
        //First check if it is the correct phase to set wires
        if(_gameState == GameState.WirePlacement)
        {
            //Assign the _inputCtrl.currentObject into a local variable to save processing
            _currentObj = _inputCtrl.currentObject;

            if (_inputCtrl.isPressed == true) 
            {
                if (_currentObj != null && _currentObj.CompareTag("ports") && _firstPort == null)
                {
                    _firstPort = _currentObj;
                    FirstPlug = Instantiate(_plugPrefab, _firstPort.transform.position, Quaternion.identity);
                    FirstPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                    FirstPlug.GetComponent<MeshRenderer>().material = _firstPort.GetComponent<MeshRenderer>().material;
                }
            }
            else
            {
                if (_currentObj != null && _firstPort != null && _currentObj.CompareTag("ports") )
                {
                    _secondPort = _currentObj;
                    _secondPlug = Instantiate(_plugPrefab, _secondPort.transform.position, Quaternion.identity);
                    _secondPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                    _secondPlug.GetComponent<MeshRenderer>().material = _firstPort.GetComponent<MeshRenderer>().material;

                    if ( _firstPort != _secondPort &&  _firstPort.GetComponent<PortObj>()?.portClasses == _secondPort.GetComponent<PortObj>()?.portClasses)
                    {
                        CreateWire(_firstPort, _secondPort, 50.0f, FirstPlug, _secondPlug);
                    }
                    else
                    {
                        Destroy(FirstPlug);
                        Destroy(_secondPlug);
                    }

                    _firstPort = null;
                    _secondPort = null;
                    FirstPlug = null;
                    _secondPlug = null;

                }
                else
                {
                    _firstPort = null;
                    _secondPort = null;

                    if (FirstPlug != null)
                        Destroy(FirstPlug);

                    if (_secondPlug != null)
                        Destroy(_secondPlug);

                    FirstPlug = null;
                    _secondPlug = null;

                }
            }


        }


    }


    public void CreateWire(GameObject _firstPort, GameObject _secondPort, float duration, GameObject FirstPlug, GameObject _secondPlug)
    {

        //Finds the midpoint from the two positions and the radius 
        Vector3 midPoint = Vector3.Lerp(_firstPort.transform.position, _secondPort.transform.position, 0.5f);
        float radius = Vector3.Distance(_firstPort.transform.position, _secondPort.transform.position) / 2; //Finds the radius of the circle

        //Instantiates the centerSpawner to calculate all the positions from
        GameObject CentralSpawner = Instantiate(_wirePointPrefab, midPoint, Quaternion.identity);
        CentralSpawner.transform.LookAt(_secondPort.transform.position);
        CentralSpawner.name = "Axis";
        CentralSpawner.tag = "Wire";

        //Creates the wire parent object to store all the prefabs and form the wire
        GameObject completewire = new GameObject();
        completewire.name = "Wire";
        completewire.tag = "Wire";
        completewire.transform.position = CentralSpawner.transform.position;

        //Creates a temporary position to rotate around the CentralSpawner to spawn the points
        GameObject spawnPos = new GameObject();
        spawnPos.name = "spanwPos";
        spawnPos.tag = "Wire";
        spawnPos.transform.position = CentralSpawner.transform.position;
        spawnPos.transform.rotation = CentralSpawner.transform.rotation;
        spawnPos.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z + radius);

        for (int i = 0; i <= 360; i++)
        {
            spawnPos.transform.RotateAround(CentralSpawner.transform.position, Vector3.up, 1);

            GameObject wirePoint = Instantiate(_wirePointPrefab, spawnPos.transform.position, Quaternion.identity);
            wirePoint.name = "Point";
            wirePoint.transform.parent = completewire.transform;
            wirePoint.transform.localPosition = new Vector3(wirePoint.transform.localPosition.x, 0, wirePoint.transform.localPosition.z);

            wirePoint.GetComponent<MeshRenderer>().material = _firstPort.GetComponent<MeshRenderer>().material ;
        }

        //rotate the wire to match the CentralSpawner
        completewire.transform.position = CentralSpawner.transform.position;
        completewire.transform.rotation = CentralSpawner.transform.rotation;
        Vector3 relativePos = completewire.transform.position - _secondPort.transform.position;
        completewire.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.right);

        //Add the _plugPrefabs
        FirstPlug.transform.parent = completewire.transform;
        _secondPlug.transform.parent = completewire.transform;

        //Add the properties to each wire
        completewire.AddComponent<WireOBj>();
        completewire.GetComponent<WireOBj>().SetFirstPort(_firstPort);
        completewire.GetComponent<WireOBj>().SetSecondPort(_secondPort);
        completewire.tag = "Wire";

        if(_firstPort.GetComponent<PortObj>() == true && _secondPort.GetComponent<PortObj>() == true)
        {
            _firstPort.GetComponent<PortObj>().connectedTo.Add(completewire);
            _secondPort.GetComponent<PortObj>().connectedTo.Add(completewire);
        }

        //Delete unneeded objects
        Destroy(CentralSpawner);
        Destroy(spawnPos);

    }





}
