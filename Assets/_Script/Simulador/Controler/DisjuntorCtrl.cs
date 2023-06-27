using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DisjuntorCtrl : MonoBehaviour
{
    private InputCtrl inputCtrl;
    [SerializeField] private GameObject _alavanca;

    private Vector3 originalPos;
    private Quaternion originalRot;

    private Vector3 newPos;
    private Quaternion newRot;

    public bool isOn = false;

    private void Start()
    {
        inputCtrl = InputCtrl.Instance;

        _alavanca = this.gameObject.transform.GetChild(0).gameObject;
        _alavanca.transform.GetPositionAndRotation(out originalPos, out originalRot);

        newPos = new Vector3(0, -0.000193999993f, 0);
        newRot = Quaternion.Euler(new Vector3(-1.70732858e-06f, 1.29647461e-07f, 179.804337f));
    }

    void Update()
    {
        if (inputCtrl.click && inputCtrl.currentObject == this.gameObject)
        {
            if (isOn == false)
            {
                isOn = true;
                _alavanca.transform.SetLocalPositionAndRotation(newPos, newRot);
            }
            else
            {
                isOn = false;
                _alavanca.transform.SetPositionAndRotation(originalPos, originalRot);
            }
        }
    }








}
