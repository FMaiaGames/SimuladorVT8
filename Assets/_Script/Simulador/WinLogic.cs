using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLogic : MonoBehaviour
{
    private GameObject[] _wires;
    private int _conditions = 0;

    [Header("--- UI --- ")]
    [SerializeField] private GameObject _winingDisplay;
    [SerializeField] private GameObject _losingDisplay;

    [Header("--- Dispositivos --- ")]
    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    public bool powerOn = false;

    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    public bool were_wiresAddedFirst = false;
    [SerializeField] private ParameterObj _parameterObj;

    public void WinConditions()
    {
        _conditions = 0;

        _wires = null;
        _wires = GameObject.FindGameObjectsWithTag("Wire");

        if(_wires != null && _wires.Length >= 1 && powerOn == true)
        {
            // CHECK WIRES CONNECTIONS
            foreach(GameObject wire in _wires)
            {
                if(wire != null && wire.GetComponent<WireOBj>() != null)
                {
                    var wObjt = wire.GetComponent<WireOBj>();

                    if (wObjt.FirstPort.name == "L1" && wObjt.SecondPort.name == "L1")
                        _conditions++;

                    if (wObjt.FirstPort.name == "L2" && wObjt.SecondPort.name == "L2")
                        _conditions++;

                    if (wObjt.FirstPort.name == "PE" && wObjt.SecondPort.name == "PE")
                        _conditions++;

                    if ( (wObjt.FirstPort.name == "24vcc" && wObjt.SecondPort.name == "24v") || (wObjt.FirstPort.name == "24v" && wObjt.SecondPort.name == "24vcc"))
                        _conditions++;

                    if ( (wObjt.FirstPort.name == "10vcc" && wObjt.SecondPort.name == "10v") || (wObjt.FirstPort.name == "10v" && wObjt.SecondPort.name == "10vcc"))
                        _conditions++;
                   
                    if ( (wObjt.FirstPort.name == "0vcc" && wObjt.SecondPort.name == "0v") || (wObjt.FirstPort.name == "0v" && wObjt.SecondPort.name == "0vcc"))
                        _conditions++;
                }
            }

            // CHECK PARAMETERS
            int winningParams = _parameterObj.CheckWinningParams();

            if(winningParams == 15)
                _conditions++;
            else
                _conditions = 0;

        }
        else
        {
            _losingDisplay.SetActive(true);
            _disjuntorCtrl.isOn = false;
            return;
        }

        if (_ligDesligCtrl.isOn == true)
        {
            if (_conditions == 7 && _wires.Length == 6) 
            {
                _winingDisplay.SetActive(true);
                _losingDisplay.SetActive(false);
            }
            else
            {
                _winingDisplay.SetActive(false);
                _losingDisplay.SetActive(true);
                _disjuntorCtrl.isOn = false;
            }
        }
        else
        {
            _losingDisplay.SetActive(true);
            _disjuntorCtrl.isOn = false;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() 
    {
        SceneManager.LoadScene("MainMenu");
    }

}
