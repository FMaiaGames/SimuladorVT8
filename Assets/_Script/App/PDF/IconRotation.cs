using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotation : MonoBehaviour
{
     void Update()
    {
        transform.Rotate(0.0f, 0.0f, -1.0f, Space.World);
    }
}
