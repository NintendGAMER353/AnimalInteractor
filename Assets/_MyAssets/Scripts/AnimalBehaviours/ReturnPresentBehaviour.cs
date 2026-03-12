using UnityEngine;

public class ReturnPresentBehaviour : AnimalBehaviourBase
{
    public GameObject uniquePresent;


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
        Instantiate(uniquePresent, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3f), Quaternion.identity);
        animal.changeState(IAnimalBehaviour.StateClass.IDLE);
    }
}
