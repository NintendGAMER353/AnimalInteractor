using UnityEngine;

public class ReturnPresentBehaviour : AnimalBehaviourBase
{


    private void Start()
    {
        IsInterrumpible = false;
    }
    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.RETURN_PRESENT;
        }
    }

    public override void Enter()
    {
        
        Instantiate(animal.animalData.GiftsWhenHappy.prefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3f), Quaternion.identity);
        animal.changeState(IAnimalBehaviour.StateClass.IDLE);
    }
}
