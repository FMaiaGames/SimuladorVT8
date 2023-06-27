using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;

    [SerializeField] private LigDesligCtrl _ligDesligCtrl;

    bool isPressed;


    void Start()
    {
        _inputCtrl = InputCtrl.Instance;
    }

    void Update()
    {

        if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
        {
            if (isPressed == false)
            {
                isPressed = true;
                StartCoroutine(pressStay(-0.000148f));
            }
            else
            {
                isPressed = false;
                StartCoroutine(releaseStay());
            }
        }

        if(isPressed == true)
        {
            _ligDesligCtrl.isOn = false;
        }
    }

    public IEnumerator pressStay(float pressDepth)
    {
        Transform trans = this.gameObject.transform;
        while (trans.localPosition.z >= pressDepth)
        {
            trans.Translate(0, 0, 0 - 0.0005f, Space.Self);
            yield return null;
        }

    }

    public IEnumerator releaseStay()
    {
        Transform trans = this.gameObject.transform;
        while (trans.localPosition.y < 0f)
        {
            trans.Translate(0, 0, 0 + 0.0005f, Space.Self);
            yield return null;
        }
    }

}
