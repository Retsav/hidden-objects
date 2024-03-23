using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ReactToPointer : MonoBehaviour
{

    private Camera mainCam;
    private Transform currentPointedObject;
    
    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        currentPointedObject = TryGetTransformFromPointedObject();
        if (Input.GetMouseButtonDown(0) && currentPointedObject != null)
        {
            Debug.Log($"Clicked: {currentPointedObject.gameObject.name}");
        } 
    }

    private Transform TryGetTransformFromPointedObject()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Physics.Raycast(mainCam.ScreenPointToRay(mousePos), out RaycastHit hit, 100))
        {
            return hit.transform;
        }
        return null;
    }
}
