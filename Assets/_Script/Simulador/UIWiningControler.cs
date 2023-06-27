using UnityEngine;
using UnityEngine.SceneManagement;

public class UIWiningControler : MonoBehaviour
{



    public GameObject[] wires;
    public int conditions = 0;

    public GameObject winingDisplay;
    public GameObject losingDisplay;

    [SerializeField] private LigDesligCtrl _ligDesligCtrl;
    public bool powerOn = false;

    [SerializeField] private DisjuntorCtrl _disjuntorCtrl;
    public bool wereWiresAddedFirst = false;

    private void Update()
    {
        /*
        if(wires != null && wires.Length >= 6 && powerOn == false)
        {
            wereWiresAddedFirst=true;
        }
        */
    }



    public void WinConditions()
    {
        conditions = 0;

        wires = null;
        wires = GameObject.FindGameObjectsWithTag("Wire");

        if(wires != null && wires.Length >= 1 && powerOn == true)
        {
            foreach(GameObject wire in wires)
            {
                if(wire != null && wire.GetComponent<WireOBj>() != null)
                {
                    if (wire.GetComponent<WireOBj>().FirstPort.name == "L1" && wire.GetComponent<WireOBj>().SecondPort.name == "L1")
                        conditions++;

                    if (wire.GetComponent<WireOBj>().FirstPort.name == "L2" && wire.GetComponent<WireOBj>().SecondPort.name == "L2")
                        conditions++;

                    if (wire.GetComponent<WireOBj>().FirstPort.name == "PE" && wire.GetComponent<WireOBj>().SecondPort.name == "PE")
                        conditions++;

                    if ( (wire.GetComponent<WireOBj>().FirstPort.name == "24vcc" && wire.GetComponent<WireOBj>().SecondPort.name == "24v") || (wire.GetComponent<WireOBj>().FirstPort.name == "24v" && wire.GetComponent<WireOBj>().SecondPort.name == "24vcc"))
                        conditions++;

                    if ( (wire.GetComponent<WireOBj>().FirstPort.name == "10vcc" && wire.GetComponent<WireOBj>().SecondPort.name == "10v") || (wire.GetComponent<WireOBj>().FirstPort.name == "10v" && wire.GetComponent<WireOBj>().SecondPort.name == "10vcc"))
                        conditions++;
                   
                    if ( (wire.GetComponent<WireOBj>().FirstPort.name == "0vcc" && wire.GetComponent<WireOBj>().SecondPort.name == "0v") || (wire.GetComponent<WireOBj>().FirstPort.name == "0v" && wire.GetComponent<WireOBj>().SecondPort.name == "0vcc"))
                        conditions++;
                }
            }
        }
        else
        {
            losingDisplay.SetActive(true);
            _disjuntorCtrl.isOn = false;
            return;
        }


        if (_ligDesligCtrl.isOn == true)
        {
            if (conditions == 6 && wires.Length == 6) 
            {
                winingDisplay.SetActive(true);
                losingDisplay.SetActive(false);

            }
            else
            {
                winingDisplay.SetActive(false);
                losingDisplay.SetActive(true);
                _disjuntorCtrl.isOn = false;
            }
        }
        else
        {
            losingDisplay.SetActive(true);
            _disjuntorCtrl.isOn = false;
        }


    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() 
    {
        SceneManager.LoadScene("MainMenu");
    }

}
