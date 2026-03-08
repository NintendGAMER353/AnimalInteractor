using System;
using UnityEngine;

public class GivePresentBehaviour : AnimalBehaviourBase
{
    public float happiness = 0;
    [HideInInspector]
    public ObjectStats actualPresent;
    public Boolean presentInstantiated = false;

    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.GIVE_PRESENT;
        }
    }

    //private void Start()
    //{
    //    Instantiate(uniquePresent, new Vector3(0, 0, 0), Quaternion.identity);
    //}

    public override void UpdateState()
    {
        happiness++;
        if (!presentInstantiated)
        {
            CheckPresent();
        }
    }

    private void CheckPresent()
    {
        if (happiness >= 10)
        {
            Debug.Log("Instantiating present");
            animal.changeState(IAnimalBehaviour.StateClass.RETURN_PRESENT);
            presentInstantiated = true;
        }
    }

    public override void Exit()
    {
        Destroy(actualPresent.gameObject);
        actualPresent = null;
    }
}
