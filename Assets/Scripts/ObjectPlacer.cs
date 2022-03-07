﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private Transform _objectPlace;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _container;

    private ARRaycastManager _arRaycastManager;
    private GameObject _installedObject;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>(); 

    private void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        UpdatePlacmentPose();

        if (Input.touchCount == 0)
        {
            SetObject();
        }
    }

    private void UpdatePlacmentPose()
    {
        Vector2 screenCenter = _camera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        var ray = _camera.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            SetObjectPosition(hit.point);
        }
        else if (_arRaycastManager.Raycast(screenCenter, _hits, TrackableType.PlaneWithinPolygon))
        {
            SetObjectPosition(_hits[0].pose.position);
        }    
    }

    private void SetObject()
    {
        _installedObject.GetComponent<Collider>().enabled = true;
        _installedObject.transform.parent = _container.transform;
        _installedObject = null;
    }

    private void SetObjectPosition(Vector3 position)
    {
        _objectPlace.position = position;

        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRotation = new Vector3(cameraForward.x, 0, cameraForward.z);

        _objectPlace.rotation = Quaternion.Euler(cameraRotation); 
    }

    public void SetInstalledObject(ItemData item)
    {
        if (_installedObject != null)
            Destroy(_installedObject);

        _installedObject = Instantiate(item.Template, _objectPlace);
        _installedObject.GetComponent<Collider>().enabled = false;
    }
}