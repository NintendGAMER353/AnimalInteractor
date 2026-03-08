using UnityEngine;
using System;
public abstract class AnimalBehaviourBase : MonoBehaviour, IAnimalBehaviour
{
    public abstract IAnimalBehaviour.StateClass StateName { get; }

    [HideInInspector]
    public Animal animal;

    public enum AnimalAnimations
    {
        IdleBack,
        IdleFront,
    }

    protected void Awake()
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
