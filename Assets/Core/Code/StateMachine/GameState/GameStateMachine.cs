using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float exploringStateTimer;

    
    public static GameStateMachine Instance { get; private set; }

    private IGameState _currentState;

    public ExploringState exploringState = new ExploringState();
    public SearchingState searchingState = new SearchingState();


    private void OnDisable() => Unsubscribe();
    

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one GameStatesMachine Instance!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _currentState = exploringState;
    }

    private void Start()
    {
        Clock.Instance.SetClockTimer(exploringStateTimer);
        Clock.Instance.ChangeClockState(true);
        Clock.Instance.OnClockFinished += ClockFinished;
    }

    private void ClockFinished(object sender, EventArgs e)
    {
        if (_currentState != exploringState)
            return;
        StartCoroutine(StateChangeCoroutine());
    }

    private void Update()
    {
        _currentState = _currentState.DoState(this);
    }

    private void Unsubscribe()
    {
        Clock.Instance.OnClockFinished -= ClockFinished;
    }

    private IEnumerator StateChangeCoroutine()
    {
        FadeManager.Instance.FadeIn(1f);
        yield return new WaitForSeconds(4f);
        DioramaManager.Instance.LoadChangedDiorama();
        FadeManager.Instance.FadeOut(1f);
        _currentState = searchingState;
        yield return null;
    }
}
