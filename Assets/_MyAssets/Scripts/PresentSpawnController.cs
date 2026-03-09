using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PresentSpawnController : MonoBehaviour
{
    private Timer timer;

    public GameObject PresentPrefab;
    public float genFrequency = 1;
    public int maxSpawnedPresents = 3;
    public List<GameObject> presentsSpawned = new();

    private void Start()
    {
        timer = new(genFrequency);
    }

    private void Update()
    {
        if (!timer.Finished)
            return;

        if (presentsSpawned.Count >= maxSpawnedPresents)
            return;
        
        
        GameObject present = Instantiate(PresentPrefab,transform.position + Vector3.back,Quaternion.identity);
        presentsSpawned.Add(present);
        timer.Reset();
        
    }
}
