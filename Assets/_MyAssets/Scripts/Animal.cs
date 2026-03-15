using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public IAnimalBehaviour currentBehaviour;

    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Dictionary <IAnimalBehaviour.StateClass, IAnimalBehaviour> states = new();

    public AnimalSO animalData;
    public enum AnimalOrientation
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT
    }
    public float happiness = 0;
    public AnimalOrientation orientation = AnimalOrientation.FRONT;
 
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
        animator = GetComponentInChildren<Animator>();
        
        foreach (IAnimalBehaviour state in stateList)
        {
            states.Add(state.StateName,state);
        }
        currentBehaviour = states.Values.First();
        Debug.Log(currentBehaviour.StateName);
        
    }

    private void Start()
    {
        //Instantiate(uniquePresent, new Vector3(0, 0, 0), Quaternion.identity);
        currentBehaviour.Enter();
    }

    private void Update()
    {

        if (currentBehaviour != null)
        {
            currentBehaviour.UpdateState();
            //Debug.Log(currentBehaviour.StateName);
        }
    }


    public void AgentOrientation()
    {

            float maxDot = -Mathf.Infinity;
            Vector3 ret = Vector3.zero;

        foreach (Vector3 dir in new Vector3[]{ Vector3.forward,Vector3.back,Vector3.left,Vector3.right})
            {
                float t = Vector3.Dot(agent.velocity, dir);
                if (t > maxDot)
                {
                    ret = dir;
                    maxDot = t;
                }
            }

        if (ret == Vector3.back)
            orientation = AnimalOrientation.FRONT;
        else if (ret == Vector3.left)
            orientation = AnimalOrientation.LEFT;
        else if (ret == Vector3.right)
            orientation = AnimalOrientation.RIGHT;
        else if (ret == Vector3.forward)
            orientation = AnimalOrientation.BACK;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animal component)) {

            if (currentBehaviour.IsInterrumpible) 
                changeState(IAnimalBehaviour.StateClass.GREET);
        }
    }
}
