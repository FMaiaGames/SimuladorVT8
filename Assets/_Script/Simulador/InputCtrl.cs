using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    public static InputCtrl Instance;

    RaycastHit[]  allHits = new RaycastHit[100];
    public  bool wireHit;


    public GameObject currentObject;

    public List<GameObject> currentObjects = new List<GameObject>();

    public bool click = false;
    public bool isButtonReleased = false;

    public bool isPressed = false;
    public bool isReleased = false;
    public bool isDraging = false;
    public bool doubleClick = false;
    float doubleClickTime = 0f;

    public Vector3 pressedPos = Vector3.zero;
    public Vector3 releasePos = Vector3.zero;
    public Vector3 currentPos = Vector3.zero;

    Ray ray;
    Camera cam;

    private void Awake() => Instance = this;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            TouchInput();
        else
            MouseInput();
        
        DetecObjects();
    }

    void MouseInput()
    {
        //Detect single click in one frame
        if (Input.GetMouseButtonDown(0)) { click = true; } else { click = false; }

        //Detect a button press
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            pressedPos = Input.mousePosition;

            //Detects double clicks
            if (Time.time - doubleClickTime <= 0.3f) { doubleClick = true; } else { doubleClick = false; }
            doubleClickTime = Time.time;

        }

        //Release button
        if (Input.GetMouseButtonUp(0) && click == false)
        {
            click = false;
            isButtonReleased = true;
            isPressed = false;
            releasePos = Input.mousePosition;
        }

        //Detects dragging
        if (isPressed && pressedPos != currentPos) { isDraging = true; } else { isDraging = false; }
    }

    void TouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) { click = true; } else { click = false; }

            //Detect a button press
            if (touch.phase == TouchPhase.Stationary)
            {
                isPressed = true;
                currentPos = Input.GetTouch(0).position;
                pressedPos = currentPos;

                //Detects double clicks
                if (Time.time - doubleClickTime <= 0.3f) { doubleClick = true; } else { doubleClick = false; }
                doubleClickTime = Time.time;

            }

            //Release button
            if (touch.phase == TouchPhase.Ended && click == false)
            {
                click = false;
                isButtonReleased = true;
                isPressed = false;
                releasePos = pressedPos;
            }

            //Detects dragging
            if (touch.phase == TouchPhase.Moved) { isDraging = true; } else { isDraging = false; }

        }

    }


    void DetecObjects()
    {
        //Cleans the previous objects

        currentObject = null;
        currentObjects = null;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
                currentPos = Input.GetTouch(0).position;
        }
        else
        {
            currentPos = Input.mousePosition;
        }

        ray = cam.ScreenPointToRay(currentPos);

        allHits = Physics.RaycastAll(ray, 10000.0F);

        if (allHits != null && allHits.Length != 0)
        {
            for (int i = 0; i < allHits.Length; i++)
            {
                if (allHits[i].collider.gameObject.CompareTag("Wire"))
                {
                    wireHit = true;
                }
                else
                {
                    currentObject = allHits[i].collider.gameObject;
                }
            }
        }


        //print("CurrentPos: " + currentPos);

        /*
        if(currentObject != null) 
            print("Current OBJ: " + currentObject.name);
        */

    }



}
