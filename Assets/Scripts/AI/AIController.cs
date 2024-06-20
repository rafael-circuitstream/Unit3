using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private AiState currentState;
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new PatrolState(this));
    }

    // Update is called once per frame
    void Update()
    {
        // NO SIGHT OF PLAYER, NOT CLOSE TO PLAYER
        if(currentState != null)
        {
            currentState.OnStateRun();
        }
    }

    public void ChangeState(AiState state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }


        currentState = state;

        currentState.OnStateEnter();
    }

    public Transform GetWaypoint(int index)
    {
        return targets[index];
    }
    public int TotalAmounOfWaypoints()
    {
        return targets.Length;
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
}
