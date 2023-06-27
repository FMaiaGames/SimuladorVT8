using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;


public class WireController : MonoBehaviour
{
    public GameObject pointInWire;

    public void CreateWire2(GameObject FirstPort, GameObject SecondPort, float duration, GameObject FirstPlug, GameObject SecondPlug)
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


        FirstPort.GetComponent<PortObj>().connectedTo.Add(completewire);
        SecondPort.GetComponent<PortObj>().connectedTo.Add(completewire);
      
        //Delete uneeded obj
        Destroy(CentralSpawner);
        Destroy(spawnPos);

    }


}
