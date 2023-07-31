using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SimulationManager;

public class WireOBj : MonoBehaviour
{
    public GameObject FirstPort;
    public GameObject SecondPort;
    public Material wireColor;
    public string wireName;

    public float Clock;


    private void Awake()
    {
        FirstPort = null;
        SecondPort = null;
        Clock = 0.0f;
        SimulationManager.OnStateChanged += OnStateChanged;
    }

    // Game State subscription 
    private GameState _gameState;
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    public void OnStateChanged(GameState state) { _gameState = state; }

    void Update()
    {
        if(_gameState == GameState.WirePlacement)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - Clock <= 0.3f)
                {
                    DestroyOnTouch();
                }
                Clock = Time.time;
            }
        }

    }

      void DestroyOnTouch()
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
            if(hit.collider.gameObject.name == "Wire" ) 
            {

                FirstPort.GetComponent<PortObj>().isConnected = false;
                FirstPort.GetComponent<PortObj>().connectedTo.Clear();

                SecondPort.GetComponent<PortObj>().isConnected = false;
                SecondPort.GetComponent<PortObj>().connectedTo.Clear();

                Destroy(hit.collider.gameObject);
            }

            if(hit.collider.gameObject.transform.parent.gameObject.name == "Wire")
            {
                FirstPort.GetComponent<PortObj>().isConnected = false;
                FirstPort.GetComponent<PortObj>().connectedTo.Clear();

                SecondPort.GetComponent<PortObj>().isConnected = false;
                SecondPort.GetComponent<PortObj>().connectedTo.Clear();


                Destroy(hit.collider.gameObject.transform.parent.gameObject);
            }
        }
    }


}
