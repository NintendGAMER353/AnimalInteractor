using UnityEngine;

public abstract class AnimalBehaviourBase : MonoBehaviour, IAnimalBehaviour
{
    public Animal animal;

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
