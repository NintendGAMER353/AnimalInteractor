using UnityEngine;
using System;
public interface IAnimalBehaviour
{
    //bool IsInterrumpible { get; set; }
    public enum StateClass
    {
        IDLE,
        WALK,
        GREET,
        GOOD_PRESENT,
        BAD_PRESENT,
        GIVE_GIFT
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
