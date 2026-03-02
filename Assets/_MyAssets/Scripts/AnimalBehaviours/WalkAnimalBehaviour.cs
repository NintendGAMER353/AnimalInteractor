using UnityEngine;

public class WalkAnimalBehaviour : AnimalBehaviourBase
{
    public Transform[] WalkPoints;

    public override void Enter()
    {
       WalkPoints = GameManager.Instance.WalkPoints;
    }

    public override void UpdateState() {
        
    }
}
