using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private CanvasGroup _fadeManagerCanvasGroup;
    
    public static FadeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one FadeManager Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void FadeIn(float duration)
    {
        _fadeManagerCanvasGroup.DOFade(1f, duration);
    }
    
    public void FadeOut(float duration)
    {
        _fadeManagerCanvasGroup.DOFade(0f, duration);
    }
}
