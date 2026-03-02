using UnityEngine;

public interface IAnimalBehaviour
{
    //bool IsInterrumpible { get; set; }

    void Enter();

    void Exit();

    void UpdateState();

    //void Interact(RaycastHit hit);
}
