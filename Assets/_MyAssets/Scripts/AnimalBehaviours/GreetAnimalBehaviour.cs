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
        animal.orientation = Animal.AnimalOrientation.FRONT;
        animal.animator.Play(AnimalAnimations.Greet.ToString());
        animal.boredom -= 200;
    }

    public override void UpdateState() {
        
        if (animal.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
