using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float cameraSpeed;
    
    
    
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineTrackedDolly _cinemachineDolly;
    private float pathPosition;
    

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachineDolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        pathPosition = 0f;
    }

    private void Update()
    {
        float amount = Input.GetAxisRaw("Horizontal");
        pathPosition += amount * Time.deltaTime * cameraSpeed;
        _cinemachineDolly.m_PathPosition = pathPosition;
    }
}
