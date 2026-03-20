using UnityEngine;

public class IdleKittyAnimalBehaviour : IdleAnimalBehaviour
{
    private Timer timer;
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
        animal.boredom++;



        if (timer.Finished)
        {

            if (animal.boredom > animal.boredLimit)
            {
                animal.changeState(IAnimalBehaviour.StateClass.STRETCH);
                return;
            }
            animal.changeState(IAnimalBehaviour.StateClass.WALK);
        }
    }
}
