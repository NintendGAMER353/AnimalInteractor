using UnityEngine;

public class GreetAnimalBehaviour : AnimalBehaviourBase
{


    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.WALK;
        }
    }

    public override void Enter()
    {
        
    }

    public override void UpdateState() {
        
        if (animal.agent.remainingDistance < 0.1f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
