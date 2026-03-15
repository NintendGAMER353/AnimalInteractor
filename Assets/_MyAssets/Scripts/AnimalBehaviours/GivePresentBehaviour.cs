using System;
using UnityEngine;

public class GivePresentBehaviour : AnimalBehaviourBase
{
    
    [HideInInspector]
    public ObjectStats actualPresent;
    public GameObject likeEffectSprite;
    public GameObject DislikeEffectSprite;

    Timer timer;
    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.GIVE_PRESENT;
        }
    }

    private void Start()
    {
        IsInterrumpible = false;
    }


    public override void Enter()
    {
        animal.animator.Play(AnimalAnimations.IdleFront.ToString());
        actualPresent.GetComponent<Collider>().enabled = false;
        timer = new(2);
        if (actualPresent.giftData.likedBy.Contains(animal.animalData))
        {
            animal.happiness++;
            Instantiate(likeEffectSprite, transform, false);
        }
        else
        {
            Instantiate(DislikeEffectSprite, transform, false);
        }

       

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
