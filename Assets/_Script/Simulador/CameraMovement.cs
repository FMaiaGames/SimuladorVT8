using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CableCtrl _cableCtrl;

    public float scrollSpeed;
    public float scrollBorderThickness;

    private float screenWidth;
    private float screenHeight;

    private Vector3 newPosition;
    private Camera cam;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        cam = Camera.main;
    }

    void Update()
    {
        //Check if the player is using a mouse or touch
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            if(_cableCtrl.FirstPlug == null) 
                TouchCamera();
        else
            MouseCamera();
    }

    void MouseCamera()
    {
        // Get the current mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Calculate the scroll direction
        float horizontalScroll = 0f;
        float verticalScroll = 0f;

        if (mousePosition.x < scrollBorderThickness)
        {
            horizontalScroll = 1f;
        }
        else if (mousePosition.x > screenWidth - scrollBorderThickness)
        {
            horizontalScroll = -1f;
        }

        if (mousePosition.y < scrollBorderThickness)
        {
            verticalScroll = -1f;
        }
        else if (mousePosition.y > screenHeight - scrollBorderThickness)
        {
            verticalScroll = 1f;
        }

        Vector3 scrollVector = new Vector3(horizontalScroll, verticalScroll, 0f) * scrollSpeed * Time.deltaTime;

        cam.transform.position += scrollVector;

        float clampedX = Mathf.Clamp(cam.transform.position.x, 2.4f, 3.8f);
        float clampedy = Mathf.Clamp(cam.transform.position.y, 0.2f, 0.5f);

        cam.transform.position = new Vector3(clampedX, clampedy, cam.transform.position.z);

        float newFOV = cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 5;
    }

    void TouchCamera()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                newPosition = Vector3.zero;
                newPosition = cam.transform.position - new Vector3(touch.deltaPosition.x * -0.0005f, touch.deltaPosition.y * 0.0005f, 0f);

                float clampedX = Mathf.Clamp(newPosition.x, 2.4f, 3.8f);
                float clampedy = Mathf.Clamp(newPosition.y, 0.2f, 0.5f);

                cam.transform.position = new Vector3(clampedX, clampedy, cam.transform.position.z);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float zoomMagnitude = prevMagnitude - currentMagnitude;
            float zoomAmount = zoomMagnitude * 0.05f;

            float newFOV = cam.fieldOfView + zoomAmount;
            newFOV = Mathf.Clamp(newFOV, 40f, 100f);

            cam.fieldOfView = newFOV;
        }



    }








}
