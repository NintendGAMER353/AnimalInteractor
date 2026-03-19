using UnityEngine;
using UnityEngine.AI;

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
        Vector3 randomDirection = Random.insideUnitSphere * 10;

        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 10, 1);
        Vector3 finalPosition = new Vector3(hit.position.x, transform.position.y, hit.position.z);

        animal.agent.destination = finalPosition;//WalkPoints[Random.Range(0, WalkPoints.Length)].position;
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
                animal.animator.Play(AnimalAnimations.WalkBack.ToString());
                break;
            //faltan animaciones por meter
            case Animal.AnimalOrientation.LEFT:
                animal.animator.Play(AnimalAnimations.WalkLeft.ToString());
                break;
            case Animal.AnimalOrientation.RIGHT:
                animal.animator.Play(AnimalAnimations.WalkRight.ToString());
                break;
        }

        if (animal.agent.remainingDistance < 0.5f)
        {
            animal.changeState(IAnimalBehaviour.StateClass.IDLE);
        } 
    
    }

   

}
