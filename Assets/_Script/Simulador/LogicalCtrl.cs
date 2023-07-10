using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LogicalCtrl : MonoBehaviour
{
    [Header("--- Logical --- ")]
    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    [SerializeField] private ChaveGeralCtrl _chaveGeralCtrl;
    [SerializeField] public LigDesligCtrl _ligDesligCtrl;
    [SerializeField] public WinLogic _winLogic;

    [Header("--- Btn Desligado --- ")]
    [SerializeField] private GameObject _btnDesligado;
    [SerializeField] private Material _verdeLigado;
    [SerializeField] private Material _verdeDesligado;
    
    [Header("--- 24Vcc --- ")]
    [SerializeField] private GameObject _24vcc;
    [SerializeField] private Material _brancoLigado;
    [SerializeField] private Material _brancoDesligado;

    [Header("--- Btn Ligado --- ")]
    [SerializeField] private GameObject _Ligado;
    [SerializeField] private Material _vermelhoLigado;
    [SerializeField] private Material _vermelhorDesligado;

    [Header("--- LigDeslig --- ")]
    [SerializeField] private GameObject _LigDeslig;

    

    private void Start()
    {

    }

    private void Update()
    {
        if(_disjuntorCtrl.isOn)
        {
            if(_chaveGeralCtrl.isOn) 
            {
                Activate(_btnDesligado, _verdeLigado);
                Activate(_24vcc, _brancoLigado);

                //Check the wining 
                if(_ligDesligCtrl.isOn)
                {
                    Activate(_Ligado, _vermelhoLigado);
                    _winLogic.powerOn = true;
                }
                else
                {
                    DeActivate(_Ligado, _vermelhorDesligado);
                }
            }
        }

        //Turn everything off
        if(!_chaveGeralCtrl.isOn || !_disjuntorCtrl.isOn) 
        {
            _btnDesligado.GetComponent<Renderer>().material = _verdeDesligado;
            _24vcc.GetComponent<Renderer>().material = _brancoDesligado;
            _Ligado.GetComponent<Renderer>().material = _vermelhorDesligado;
            
        }

        void Activate( GameObject obj, Material mat)
        {
            obj.GetComponent<Renderer>().material = mat;
        }

        void DeActivate(GameObject obj, Material mat)
        {
            Activate(obj, mat);
        }

    }



}
