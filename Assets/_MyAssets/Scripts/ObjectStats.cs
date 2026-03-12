using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public GiftSO giftData;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out Animal an))
        {
            Debug.Log("HitAnimal");
            if (!an.currentBehaviour.IsInterrumpible)
                return;
            an.GetComponentInChildren<GivePresentBehaviour>().actualPresent = this;
            an.changeState(IAnimalBehaviour.StateClass.GIVE_PRESENT);
        }
    }

}



