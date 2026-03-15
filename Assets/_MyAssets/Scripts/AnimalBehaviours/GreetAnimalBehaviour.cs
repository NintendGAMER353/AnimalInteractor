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
        
        animal.animator.Play(AnimalAnimations.Greet.ToString());
    }

    public override void UpdateState() {
        
        if (animal.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
