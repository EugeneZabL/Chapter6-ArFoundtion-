using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.InputSystem;

public class ARCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject _cursorImg, _placedObject;

    [SerializeField]
    private ARRaycastManager _raycastManager;

    private bool _isLock = false;

    void Update()
    {
        if (!_isLock)
        {
            UpdateCursor();

            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                
                _placedObject.transform.position = transform.position;

            }
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

    public void DisableCursor()
    {
        _isLock = true;
        _cursorImg.SetActive(false);

    }

    public void EnableCursor()
    {
        _isLock = false;
        _cursorImg.SetActive(true);
    }
}
