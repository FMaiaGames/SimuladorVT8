using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LigDesligCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    public bool isOn = false;

    [SerializeField] private ChaveGeralCtrl _chaveGeralCtrl;

    void Awake()
    {
        _inputCtrl = InputCtrl.Instance;
    }

    void Update()
    {

        //Check is the previous logic point is active first
        if (_chaveGeralCtrl.isOn)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
            {
                if (isOn == false)
                {
                    isOn = true;
                    StartCoroutine(press(8.6e-05f));
                }
                else
                {
                    isOn = false;
                    StartCoroutine(press(8.6e-05f));
                }
            }
        }
        else
        {
            isOn = false;
        }

    }

    public IEnumerator press(float pressDepth)
    {
        Transform trans = this.gameObject.transform;
        while (trans.localPosition.y <= pressDepth)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            trans.Translate(0, 0 + 240.0e-06f, 0, Space.Self);
            yield return null;
        }
            StartCoroutine(release(trans));
    }

    public IEnumerator release(Transform trans)
    {
        while (trans.localPosition.y >= 0f)
        {
            trans.Translate(0, 0 - 240.0e-06f, 0, Space.Self);
            yield return null;
        }
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

}
