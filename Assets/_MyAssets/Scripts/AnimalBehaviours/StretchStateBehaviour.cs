using UnityEngine;

public class StretchStateBehaviour : AnimalBehaviourBase
{
    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.STRETCH;
        }
    }

    public override void Enter()
    {
        animal.orientation = Animal.AnimalOrientation.FRONT;
        animal.animator.Play(AnimalAnimations.StretchState.ToString());
        animal.boredom -= 2000;
    }
    public override void UpdateState()
    {

        if (animal.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        }

    }
}
