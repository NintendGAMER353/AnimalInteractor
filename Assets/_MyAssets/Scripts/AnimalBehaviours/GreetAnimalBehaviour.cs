using UnityEngine;

public class GreetAnimalBehaviour : AnimalBehaviourBase
{
    private float StartTime;

    public float Duration;



    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.GREET;
        }
    }

    public override void Enter()
    {
        StartTime = Time.time;
        animal.agent.isStopped = true;
        //Cambiar a animacion de greet
    }

    public override void UpdateState() {
        
        if (StartTime + Duration < Time.time)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
