using UnityEngine;

public class IdleAnimalBehaviour : AnimalBehaviourBase
{

    private float idleStartTime;
    
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
        idleStartTime = Time.time;
        switch (animal.orientation)
        {
            case Animal.AnimalOrientation.FRONT:
                animal.animator.Play(AnimalAnimations.IdleFront.ToString());
                break;
            case Animal.AnimalOrientation.BACK:
                animal.animator.Play(AnimalAnimations.IdleBack.ToString());
                break;
            //faltan animaciones por meter
            case Animal.AnimalOrientation.LEFT:
                
                break;
            case Animal.AnimalOrientation.RIGHT:
                break;
        }
        
        
        
    }
    public override void UpdateState()
    {
        
        if (idleStartTime + idleDuration < Time.time) {
            animal.changeState(IAnimalBehaviour.StateClass.WALK);
        }
    }


}
