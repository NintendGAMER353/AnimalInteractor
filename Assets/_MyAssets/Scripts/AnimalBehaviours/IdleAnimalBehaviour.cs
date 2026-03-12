using UnityEngine;

public class IdleAnimalBehaviour : AnimalBehaviourBase
{

    private Timer timer;
    
    public float idleDuration;
    

    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.IDLE;
        }
    }

    public override void Enter()
    {
        timer = new(idleDuration);
        switch (animal.orientation)
        {
            case Animal.AnimalOrientation.FRONT:
                animal.animator.Play(AnimalAnimations.IdleFront.ToString());
                break;
            case Animal.AnimalOrientation.BACK:
                animal.animator.Play(AnimalAnimations.IdleBack.ToString());
                break;
            case Animal.AnimalOrientation.LEFT:
                animal.animator.Play(AnimalAnimations.IdleLeft.ToString());
                break;
            case Animal.AnimalOrientation.RIGHT:
                animal.animator.Play(AnimalAnimations.IdleRight.ToString());
                break;
        }
        
        
        
    }
    public override void UpdateState()
    {
        
        if (timer.Finished) {
            animal.changeState(IAnimalBehaviour.StateClass.WALK);
        }
    }


}
