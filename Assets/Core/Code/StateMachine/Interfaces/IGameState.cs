using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    IGameState DoState(GameStateMachine gsm);
}
