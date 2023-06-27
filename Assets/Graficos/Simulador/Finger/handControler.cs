using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handControler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
