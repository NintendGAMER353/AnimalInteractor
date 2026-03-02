using UnityEngine;
using UnityEngine.EventSystems;

public class Animal : MonoBehaviour
{
    IAnimalBehaviour currentBehaviour;
    public void changeState(IAnimalBehaviour behaviour)
    {
        Debug.Log("Changing state to: " + behaviour.ToString());
        currentBehaviour.Exit();
        currentBehaviour = behaviour;
        currentBehaviour.Enter();
    }

    private void Update()
    {
        if (currentBehaviour != null)
        {
            currentBehaviour.UpdateState();
        }
    }
}
