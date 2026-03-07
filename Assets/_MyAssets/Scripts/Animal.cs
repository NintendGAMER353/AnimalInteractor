using System;
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
    public Boolean presentInstantiated = false;


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

    //private void Start()
    //{
    //    Instantiate(uniquePresent, new Vector3(0, 0, 0), Quaternion.identity);
    //}

    private void Update()
    {
        if (currentBehaviour != null)
        {
            currentBehaviour.UpdateState();
            Debug.Log(currentBehaviour.StateName);
            if(!presentInstantiated)
            {
                GivePresent();
            }
        }
        happiness++;
    }

    private void GivePresent()
    {
        if(happiness >= 10)
        {
            Debug.Log("Instantiating present");
            Instantiate(uniquePresent, new Vector3(-1.72000003f, 2.20000005f, -10.4700003f), Quaternion.identity);
            presentInstantiated = true;
        }
    }
}
