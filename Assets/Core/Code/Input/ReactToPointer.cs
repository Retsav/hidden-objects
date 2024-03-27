using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ReactToPointer : MonoBehaviour
{
    public static ReactToPointer Instance;
    public event EventHandler<Transform> OnObjectClicked;

    private Camera mainCam;
    private Transform currentPointedObject;

    public static bool IsReactLocked = false;
    private void Awake()
    {
        mainCam = Camera.main;
        if (Instance != null)
        {
            Debug.LogError("There is more than one DioramaManager Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (IsReactLocked)
            return;
        currentPointedObject = TryGetTransformFromPointedObject();
        if (Input.GetMouseButtonDown(0) && currentPointedObject != null)
        {
            Debug.Log($"Clicked: {currentPointedObject.gameObject.name}");
            OnObjectClicked?.Invoke(this, currentPointedObject);
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
