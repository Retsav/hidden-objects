using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploringState : IGameState
{
    public IGameState DoState(GameStateMachine gsm)
    {
        return gsm.exploringState;
    }
}
