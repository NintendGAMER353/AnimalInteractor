using UnityEngine;

public class WalkAnimalBehaviour : AnimalBehaviourBase
{



    public Transform[] WalkPoints;

    public override IAnimalBehaviour.StateClass StateName
    {
        get
        {
            return IAnimalBehaviour.StateClass.WALK;
        }
    }

    public override void Enter()
    {
        animal.agent.destination = WalkPoints[Random.Range(0, WalkPoints.Length)].position;
        animal.agent.isStopped = false;
    }

    public override void Exit()
    {
        animal.agent.isStopped = true;
    }

    public override void UpdateState() {
        animal.AgentOrientation();

        //change animations with orientation
        switch (animal.orientation)
        {
            case Animal.AnimalOrientation.FRONT:
                animal.animator.Play(AnimalAnimations.WalkFront.ToString());
                break;
            case Animal.AnimalOrientation.BACK:
                //animal.animator.Play(AnimalAnimations.IdleBack.ToString());
                break;
            //faltan animaciones por meter
            case Animal.AnimalOrientation.LEFT:

                break;
            case Animal.AnimalOrientation.RIGHT:
                break;
        }

        if (animal.agent.remainingDistance < 0.1f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
