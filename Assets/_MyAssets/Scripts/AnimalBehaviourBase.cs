using UnityEngine;
using System;
public abstract class AnimalBehaviourBase : MonoBehaviour, IAnimalBehaviour
{
    public abstract IAnimalBehaviour.StateClass StateName { get; }

    public Animal animal;
    protected void Start()
    {
        animal = GetComponentInParent<Animal>();
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdateState()
    {
        
    }

}
