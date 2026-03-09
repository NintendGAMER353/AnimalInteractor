using System;
using UnityEngine;

public class GivePresentBehaviour : AnimalBehaviourBase
{
    
    [HideInInspector]
    public ObjectStats actualPresent;
    public GameObject likeEffectSprite;

    Timer timer;
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


    public override void Enter()
    {
        actualPresent.GetComponent<Collider>().enabled = false;
        timer = new(2);
        animal.happiness++;
        Instantiate(likeEffectSprite, transform,false);

        if (animal.happiness >= 5)
        {
            Debug.Log("Instantiating present");
            animal.changeState(IAnimalBehaviour.StateClass.RETURN_PRESENT);
            
        }
    }
    public override void UpdateState()
    {
        if (timer.Finished)
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);

    }


    public override void Exit()
    {
        GameManager.Instance.presentGen.presentsSpawned.Remove(actualPresent.gameObject);
        Destroy(actualPresent.gameObject);
        actualPresent = null;
    }
}
