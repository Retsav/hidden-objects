using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingState : IGameState
{
    public IGameState DoState(GameStateMachine gsm)
    {
        return gsm.searchingState;
    }
}
