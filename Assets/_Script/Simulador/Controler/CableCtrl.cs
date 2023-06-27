using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.XR.OpenXR.Features.Interactions.HTCViveControllerProfile;

public class CableCtrl : MonoBehaviour
{
    [SerializeField] private InputCtrl inputCtrl;
    [SerializeField] private WireController wireController;


    [SerializeField] private GameObject currentObj;
    [SerializeField] private GameObject Plug;
    [SerializeField] private GameObject pointInWire;

    [SerializeField] private GameObject FirstPort;
    [SerializeField] private GameObject SecondPort;

    public  GameObject  FirstPlug { get; private set; }
    [SerializeField] private GameObject SecondPlug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Assign the inputCtrl.currentObject into a local variable to save processing
        currentObj = inputCtrl.currentObject;

        if (inputCtrl.isPressed && currentObj != null) 
        {
            if (currentObj.CompareTag("ports") && FirstPort == null)
            {
                FirstPort = currentObj;
                FirstPlug = Instantiate(Plug, FirstPort.transform.position, Quaternion.identity);
                FirstPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                FirstPlug.GetComponent<MeshRenderer>().material = FirstPort.GetComponent<MeshRenderer>().material;
            }
        }
        else
        {
            if (currentObj && currentObj != FirstPort && FirstPort != null && FirstPlug != null)
            {
                SecondPort = currentObj;
                SecondPlug = Instantiate(Plug, SecondPort.transform.position, Quaternion.identity);
                SecondPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                SecondPlug.GetComponent<MeshRenderer>().material = FirstPort.GetComponent<MeshRenderer>().material;

                if (FirstPort.GetComponent<PortObj>()?.portClasses == SecondPort.GetComponent<PortObj>()?.portClasses)
                {
                    CreateWire(FirstPort, SecondPort, 50.0f, FirstPlug, SecondPlug);
                }
                else
                {
                    Destroy(FirstPlug);
                    Destroy(SecondPlug);
                }

                FirstPort = null;
                SecondPort = null;
                FirstPlug = null;
                SecondPlug = null;
            }
            else
            {
                FirstPort = null;
                SecondPort = null;

                if (FirstPlug != null && FirstPlug.activeSelf == true)
                    Destroy(FirstPlug);

                if (SecondPlug != null && SecondPlug.activeSelf == true)
                    Destroy(SecondPlug);

                FirstPlug = null;
                SecondPlug = null;

            }
        }
    }


    public void CreateWire(GameObject FirstPort, GameObject SecondPort, float duration, GameObject FirstPlug, GameObject SecondPlug)
    {

        //Finds the midpoint from the two positions and theradius 
        Vector3 midPoint = Vector3.Lerp(FirstPort.transform.position, SecondPort.transform.position, 0.5f);
        float radius = Vector3.Distance(FirstPort.transform.position, SecondPort.transform.position) / 2; //Finds the radius of the circle

        //Instantiates the centerSpawner to calculate all the positions from
        GameObject CentralSpawner = Instantiate(pointInWire, midPoint, Quaternion.identity);
        CentralSpawner.transform.LookAt(SecondPort.transform.position);
        CentralSpawner.name = "eixo";
        CentralSpawner.tag = "Wire";

        //Creates the wire parent object to store all the prefabs and form the wire
        GameObject completewire = new GameObject();
        completewire.name = "Wire";
        completewire.tag = "Wire";
        completewire.transform.position = CentralSpawner.transform.position;

        //Creates a temporary position to rotate around the CentralSpawner to spawn the points
        GameObject spawnPos = new GameObject();
        spawnPos.name = "spanwpos";
        spawnPos.tag = "Wire";
        spawnPos.transform.position = CentralSpawner.transform.position;
        spawnPos.transform.rotation = CentralSpawner.transform.rotation;
        spawnPos.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z + radius);

        for (int i = 0; i <= 360; i++)
        {
            spawnPos.transform.RotateAround(CentralSpawner.transform.position, Vector3.up, 1);

            GameObject wirePoint = Instantiate(pointInWire, spawnPos.transform.position, Quaternion.identity);
            wirePoint.name = "ponto";
            wirePoint.transform.parent = completewire.transform;
            wirePoint.transform.localPosition = new Vector3(wirePoint.transform.localPosition.x, 0, wirePoint.transform.localPosition.z);

            wirePoint.GetComponent<MeshRenderer>().material = FirstPort.GetComponent<MeshRenderer>().material;
        }

        //rotate the wire to match the CentralSpawner
        completewire.transform.position = CentralSpawner.transform.position;
        completewire.transform.rotation = CentralSpawner.transform.rotation;
        Vector3 relativePos = completewire.transform.position - SecondPort.transform.position;
        completewire.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.right);

        //Add the plugs
        FirstPlug.transform.parent = completewire.transform;
        SecondPlug.transform.parent = completewire.transform;

        //Add the properties to each wire
        completewire.AddComponent<WireOBj>();
        completewire.GetComponent<WireOBj>().FirstPort = FirstPort;
        completewire.GetComponent<WireOBj>().SecondPort = SecondPort;
        completewire.tag = "Wire";

        if(FirstPort.GetComponent<PortObj>() == true && SecondPort.GetComponent<PortObj>() == true)
        {
            FirstPort.GetComponent<PortObj>().connectedTo.Add(completewire);
            SecondPort.GetComponent<PortObj>().connectedTo.Add(completewire);
        }

        //Delete uneeded obj
        Destroy(CentralSpawner);
        Destroy(spawnPos);

    }





}
