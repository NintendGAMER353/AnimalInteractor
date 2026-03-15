using NUnit.Framework;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class PresentSpawnController : MonoBehaviour
{
    private Timer timer;

    public GameObject PresentPrefab;
    public float genFrequency = 1;
    public int maxSpawnedPresents = 3;
    public List<GameObject> presentsSpawned = new();
    NavMeshSurface navMesh;
 

    private void Start()
    {
        timer = new(genFrequency);
        
    }

    private void Update()
    {
        if (!timer.Finished)
            return;

        timer.Reset();

        if (presentsSpawned.Count >= maxSpawnedPresents)
            return;

        Vector3 randomDirection = Random.insideUnitSphere * 5;

        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 5, 1);
        Vector3 finalPosition = hit.position;

        GameObject present = Instantiate(PresentPrefab,finalPosition,Quaternion.identity);
        presentsSpawned.Add(present);
        
        
    }
}
