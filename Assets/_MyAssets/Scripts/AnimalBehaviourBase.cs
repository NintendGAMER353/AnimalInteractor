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
        IdleLeft,
        IdleRight,
        WalkFront,
        WalkBack,
        WalkLeft,
        WalkRight,
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
