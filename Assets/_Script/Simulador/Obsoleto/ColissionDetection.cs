using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ColissionDetection : MonoBehaviour
{

    public WireController wireController;
    public CameraMovement cameraMovement;
 
    public GameObject CurrentTarget;
    public GameObject Plug;

    public int maxConnections;

    public GameObject FirstPort;
    public Vector3 FirstPortStartPoint;
    public Transform FirstPortEndPoint;
    public GameObject SecondPort;

    public GameObject FirstPlug;
    public GameObject SecondPlug;

    RaycastHit[] allHits = new RaycastHit[100];


    private void Start()
    {


    }


    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            if (GetPort() != null && FirstPort == null) {

                FirstPort = GetPort();

                FirstPlug = Instantiate(Plug, FirstPort.transform.position, Quaternion.identity);

                FirstPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                FirstPlug.GetComponent<MeshRenderer>().material = FirstPort.GetComponent<MeshRenderer>().material;
            }
           
        }
        else
        {
            if (GetPort() != null && GetPort() != FirstPort && FirstPort != null && FirstPlug != null)
            {
                SecondPort = GetPort();

                SecondPlug = Instantiate(Plug, SecondPort.transform.position, Quaternion.identity);
                SecondPlug.transform.rotation = Quaternion.Euler(70.0f, 0.0f, 0.0f);
                SecondPlug.GetComponent<MeshRenderer>().material = FirstPort.GetComponent<MeshRenderer>().material;

                if(FirstPort.GetComponent<PortObj>().portClass == SecondPort.GetComponent<PortObj>().portClass)
                {
                    wireController.CreateWire2(FirstPort, SecondPort, 50.0f, FirstPlug, SecondPlug);
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

                if(FirstPlug != null && FirstPlug.activeSelf == true)
                    Destroy(FirstPlug);

                if (SecondPlug != null && SecondPlug.activeSelf == true)
                    Destroy(SecondPlug);

                FirstPlug = null;
                SecondPlug = null;

            }            
        }

        if(FirstPlug == null)
        {
            //cameraMovement.TouchCamera();
        }
    }


   
    GameObject GetPort()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        allHits = Physics.RaycastAll(ray, 10000.0F);

        if (allHits != null && allHits.Length != 0)
        {
            for (int i = 0; i < allHits.Length; i++)
            {
                if (allHits[i].collider.gameObject.CompareTag("ports"))
                {
                    CurrentTarget = allHits[i].collider.gameObject;
                    return allHits[i].collider.gameObject;
                }
                else
                {
                    CurrentTarget = null;
                }
            }
        }
        else
        {
            CurrentTarget = null;
            return null;
        }

        return null;

       
    }
 /*
    GameObject GetPorts()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        allHits = Physics.RaycastAll(ray, 100.0F);


        if (allHits != null && allHits.Length != 0)
        {
            for (int i = 0; i < allHits.Length; i++)
            {
                if (allHits[i].collider.gameObject.CompareTag("ports") )
                {
                    Debug.Log("Hit " + allHits[i].collider.gameObject.name);
                    return allHits[i].collider.gameObject;
                }
            }
        }
        
        return null;
    }
 */

}
