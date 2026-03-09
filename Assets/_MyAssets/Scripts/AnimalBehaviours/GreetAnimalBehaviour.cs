using UnityEngine;

public class GreetAnimalBehaviour : AnimalBehaviourBase
{
    private Timer timer;

    public float GreetDuration;


    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.GREET;
        }
    }

    public override void Enter()
    {
        timer = new(GreetDuration);
        //Cambiar a animacion de greet
    }

    public override void UpdateState() {
        
        if (timer.Finished)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
