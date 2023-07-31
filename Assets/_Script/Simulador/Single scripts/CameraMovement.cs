using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CableCtrl _cableCtrl;

    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _scrollBorderThickness;

    private float _screenWidth;
    private float _screenHeight;

    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;

    [SerializeField] private float _yMin;
    [SerializeField] private float _yMax;

    private Vector3 _newPosition;
    private Camera _cam;

    [SerializeField] private GameObject _clpScreen;

    void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        _cam = Camera.main;
    }

    void Update()
    {
        //Check if the player is using a mouse or touch
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if(_cableCtrl.FirstPlug == null && _clpScreen.activeInHierarchy == false) 
                Touch_camera();
        }
        else
        {
            if(_clpScreen.activeInHierarchy == false)
                Mouse_camera();
        }
    }

    void Mouse_camera()
    {
        // Get the current mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Calculate the scroll direction
        float horizontalScroll = 0f;
        float verticalScroll = 0f;

        if (mousePosition.x < _scrollBorderThickness)
        {
            horizontalScroll = 1f;
        }
        else if (mousePosition.x > _screenWidth - _scrollBorderThickness)
        {
            horizontalScroll = -1f;
        }

        if (mousePosition.y < _scrollBorderThickness)
        {
            verticalScroll = -1f;
        }
        else if (mousePosition.y > _screenHeight - _scrollBorderThickness)
        {
            verticalScroll = 1f;
        }

        Vector3 scrollVector = new Vector3(horizontalScroll, verticalScroll, 0f) * _scrollSpeed * Time.deltaTime;

        _cam.transform.position += scrollVector;

        float clampedX = Mathf.Clamp(_cam.transform.position.x, _xMin, _xMax);
        float clampedy = Mathf.Clamp(_cam.transform.position.y, _yMin, _yMax);

        _cam.transform.position = new Vector3(clampedX, clampedy, _cam.transform.position.z);

        float newFOV = _cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 5;
    }

    void Touch_camera()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _newPosition = Vector3.zero;
                _newPosition = _cam.transform.position - new Vector3(touch.deltaPosition.x * -0.0005f, touch.deltaPosition.y * 0.0005f, 0f);

                float clampedX = Mathf.Clamp(_newPosition.x, 2.0f, 4.2f);
                float clampedy = Mathf.Clamp(_newPosition.y, 0.1f, 0.4f);

                _cam.transform.position = new Vector3(clampedX, clampedy, _cam.transform.position.z);
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

            float newFOV = _cam.fieldOfView + zoomAmount;
            newFOV = Mathf.Clamp(newFOV, 40f, 100f);

            _cam.fieldOfView = newFOV;
        }

    }



}
