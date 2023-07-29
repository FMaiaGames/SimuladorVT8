using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    [SerializeField] private GameObject _lever;

    private Vector3 originalPos;
    private Quaternion originalRot;

    private Vector3 newPos;
    private Quaternion newRot;

    public bool isOn = false;

    // --- THE NEXT LOGIC NODE IS DisjuntorCtrl
  
    void Start()
    {
        _inputCtrl = InputCtrl.Instance;

        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);

        newPos = new Vector3(0.000495f, -0.000166f, 1.4e-05f); 
        newRot = Quaternion.Euler(new Vector3(0f, 0f, -180f) ); 
    }

 
    void Update()
    {
        if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
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
}
