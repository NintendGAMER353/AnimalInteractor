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
    }
    public override void UpdateState()
    {
        
        if (idleStartTime + idleDuration < Time.time) {
            animal.changeState(IAnimalBehaviour.StateClass.WALK);
        }
    }


}
