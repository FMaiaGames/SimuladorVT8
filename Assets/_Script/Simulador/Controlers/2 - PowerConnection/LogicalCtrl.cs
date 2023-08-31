using UnityEngine;
using static SimulationManager;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LogicalCtrl : MonoBehaviour
{
    [Header("--- Logical --- ")]
    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    [SerializeField] private WinLogic _winLogic;

    [Header("--- Trio Alimentação--- ")]
    [SerializeField] private DRCtrl _drCtrl;
    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    [SerializeField] private ChaveGeralCtrl _chaveGeralCtrl;
    [SerializeField] private bool _IsTrioOn = false;

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

    // Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Update()
    {
        if(_gameState == GameState.PowerConnection)
        {
            //are the basic energy switches on
            if (_drCtrl.IsOn() == true && _disjuntorCtrl.IsOn() == true && _chaveGeralCtrl.IsOn() == true)
                _IsTrioOn = true;
            else
                _IsTrioOn = false;

            //If trio on, energize the panel
            if(_IsTrioOn == true) 
            {
                Activate(_btnDesligado, _verdeLigado);
                Activate(_24vcc, _brancoLigado);

                //Check the wining 
                if(_ligDesligCtrl.IsOn() == true)
                    Activate(_Ligado, _vermelhoLigado);
                else
                    DeActivate(_Ligado, _vermelhorDesligado);
            }
            else
            {
                _btnDesligado.GetComponent<Renderer>().material = _verdeDesligado;
                _24vcc.GetComponent<Renderer>().material = _brancoDesligado;
                _Ligado.GetComponent<Renderer>().material = _vermelhorDesligado;
            }

        }

    }
    private void Activate( GameObject obj, Material mat)
    {
        obj.GetComponent<Renderer>().material = mat;
    }

    private void DeActivate(GameObject obj, Material mat)
    {
        Activate(obj, mat);
    }

    public void ResetTrio()
    {
        _drCtrl.TurnOff();
        _disjuntorCtrl.TurnOff();
        _chaveGeralCtrl.TurnOff();
        _IsTrioOn = false;
    }

    public bool GetTrioStatus()
    {
        return _IsTrioOn;
    }
}
