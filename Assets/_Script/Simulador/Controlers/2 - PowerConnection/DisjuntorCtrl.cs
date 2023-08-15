using UnityEngine;
using static SimulationManager;

public class DisjuntorCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    [SerializeField] private GameObject _lever;
    [SerializeField] private bool isOn = false;

    //Original off position
    private Vector3 originalPos;
    private Quaternion originalRot;

    //New On position
    private Vector3 newPos;
    private Quaternion newRot;

    //Game State subscription 
    private GameState _gameState;
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }
    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }
    private void OnStateChanged(GameState state) { _gameState = state; }

    private void Start()
    {
        _inputCtrl = InputCtrl.Instance;
 
        //Set the original position
        _lever = this.gameObject.transform.GetChild(0).gameObject;
        _lever.transform.GetPositionAndRotation(out originalPos, out originalRot);

        //Set the new position
        newPos = new Vector3(0, -0.000193999993f, 0);
        newRot = Quaternion.Euler(new Vector3(-1.70732858e-06f, 1.29647461e-07f, 179.804337f));
    }

    private void Update()
    {
        if (_gameState == GameState.PowerConnection) 
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

    public bool IsOn()
    {
        return isOn;
    }

    public void TurnOff()
    {
        isOn = true;
        _lever.transform.SetLocalPositionAndRotation(newPos, newRot);
    }




}
