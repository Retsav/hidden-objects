using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaManager : MonoBehaviour
{
    public static DioramaManager Instance { get; private set; }
    
    [SerializeField] private DioramaLevel currentDioramaLevel;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one DioramaManager Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadCleanDiorama();
    }

    public void LoadCleanDiorama()
    {
        currentDioramaLevel.exploringDiorama.gameObject.SetActive(true);
        currentDioramaLevel.searchingDiorama.gameObject.SetActive(false);
    }
    
    public void LoadChangedDiorama()
    {
        currentDioramaLevel.exploringDiorama.gameObject.SetActive(false);
        currentDioramaLevel.searchingDiorama.gameObject.SetActive(true);
    }
}
