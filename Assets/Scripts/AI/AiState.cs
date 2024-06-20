using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiState
{
    protected AIController controller;
    
    public abstract void OnStateEnter();

    public abstract void OnStateRun();

    public abstract void OnStateExit();

    public AiState(AIController aicontroller)
    {
        controller = aicontroller;
    }

}
