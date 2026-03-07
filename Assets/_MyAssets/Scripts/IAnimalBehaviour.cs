using UnityEngine;
using System;
public interface IAnimalBehaviour
{
    //bool IsInterrumpible { get; set; }
    public enum StateClass
    {
        IDLE,
        WALK
    }
    void Enter();

    void Exit();

    void UpdateState();

    StateClass StateName
    {
        get;
    }

    //void Interact(RaycastHit hit);
}
