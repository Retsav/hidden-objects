using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public event EventHandler OnClockFinished;
    public static Clock Instance { get; private set; }
    
    
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerLabel;
    [SerializeField] private CanvasGroup _timerCanvasGroup;
    
    
    private TimeSpan _timeSpan = new TimeSpan();
    
    private string _timerText;
    
    private bool _isRunning;
    private float _clockTimeMax;
    private float _clockTime;
    
    
    public void ChangeClockState(bool isRunning) => _isRunning = isRunning;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Clock Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetClockTimer(float timeInSeconds)
    {
        _clockTimeMax = timeInSeconds;
        _clockTime = _clockTimeMax;
        UpdateClockText(_clockTimeMax);
        ShowTimer();
    }

    public void ResetClockTimer()
    {
        _clockTimeMax = 0f;
        _clockTime = _clockTimeMax;
        UpdateClockText(_clockTime);
        _isRunning = false;
        OnClockFinished?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateClockText(float timeInSeconds)
    {
        _timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        _timerText = string.Format("{0:D2}:{1:D2}", _timeSpan.Minutes, _timeSpan.Seconds);
        timerLabel.SetText(_timerText);
    }

    private void HideTimer()
    {
        _timerCanvasGroup.alpha = 0f;
    }
    
    private void ShowTimer()
    {
        _timerCanvasGroup.alpha = 1f;
    }
    
    private void Update()
    {
        if (!_isRunning && _clockTimeMax > 0)
            return;
        if (_clockTime >= 0)
        {
            UpdateClockText(_clockTime);
            _clockTime -= Time.deltaTime;
            return;
        }
        ResetClockTimer();
        HideTimer();
    }
    
}
