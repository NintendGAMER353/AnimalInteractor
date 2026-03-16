using UnityEngine;

public class ReadAnimalBehaviour : AnimalBehaviourBase
{
    public override IAnimalBehaviour.StateClass StateName => IAnimalBehaviour.StateClass.READ;

    public override void Enter()
    {
        animal.orientation = Animal.AnimalOrientation.FRONT;
        animal.animator.Play(AnimalAnimations.ReadStart.ToString());
    }

    public override void UpdateState()
    {
        animal.boredom--;

        if (animal.boredom < 0)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        }
    }

}
