using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortObj : MonoBehaviour
{
    public bool isConnected = false;
    public string portClass;
    public List<GameObject> connectedTo;
    public Material portColor;
    public string portName;

    public enum PortClasses { None, LP}

    public PortClasses portClasses;

    private void Awake()
    {
        connectedTo = null;
        portColor = this.gameObject.GetComponent<MeshRenderer>().material;
        portName = this.gameObject.name;

        connectedTo = new List<GameObject>();

        
    }

    private void Update()
    {
        if(connectedTo == null)
        {
            isConnected = false;
        }
    }

}
