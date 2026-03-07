using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public Dictionary<Animal, int> likes = new();

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Animal an))
        {
            Debug.Log("HitAnimal");
            an.actualPresent = this;
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

}



