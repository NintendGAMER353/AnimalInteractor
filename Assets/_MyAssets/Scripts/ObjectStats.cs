using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public Dictionary<Animal, int> likes = new();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Animal an))
        {
            Debug.Log("HitAnimal");
            an.GetComponentInChildren<GivePresentBehaviour>().actualPresent = this;
            an.changeState(IAnimalBehaviour.StateClass.GIVE_PRESENT);
        }
    }

}



