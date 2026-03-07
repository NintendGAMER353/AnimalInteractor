using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Animal : MonoBehaviour
{
    IAnimalBehaviour currentBehaviour;

    [HideInInspector]
    public NavMeshAgent agent;

    [HideInInspector]
    public Dictionary <IAnimalBehaviour.StateClass, IAnimalBehaviour> states = new();
    public void changeState(IAnimalBehaviour.StateClass behaviourName)
    {   
        IAnimalBehaviour behaviour = states[behaviourName];
        Debug.Log("Changing state to: " + behaviour.ToString());
        currentBehaviour.Exit();
        currentBehaviour = behaviour;
        currentBehaviour.Enter();
    }

    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        IAnimalBehaviour[] stateList = GetComponentsInChildren<IAnimalBehaviour>();
        foreach (IAnimalBehaviour state in stateList)
        {
            states.Add(state.StateName,state);
            
        }
        currentBehaviour = states.Values.First();
        Debug.Log(currentBehaviour.StateName);
        currentBehaviour.Enter();
    }

    private void Update()
    {
        if (currentBehaviour != null)
        {
            currentBehaviour.UpdateState();
        }
    }
}
