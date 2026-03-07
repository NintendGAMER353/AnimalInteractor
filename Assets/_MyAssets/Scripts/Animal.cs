using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    IAnimalBehaviour currentBehaviour;

    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Dictionary <IAnimalBehaviour.StateClass, IAnimalBehaviour> states = new();
    public float happiness = 0;

    public void changeState(IAnimalBehaviour.StateClass behaviourName)
    {   
        IAnimalBehaviour behaviour = states[behaviourName];
        Debug.Log("Changing state to: " + behaviour.ToString());
        currentBehaviour.Exit();
        currentBehaviour = behaviour;
        currentBehaviour.Enter();
    }

    public ObjectStats actualPresent;
    public GameObject uniquePresent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        IAnimalBehaviour[] stateList = GetComponentsInChildren<IAnimalBehaviour>();
        animator = GetComponentInChildren<Animator>();
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

    private void GivePresent()
    {
        if(happiness >= 10)
        {

        }
    }
}
