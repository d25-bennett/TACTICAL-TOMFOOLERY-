using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public Transform[] SpawnPoints;

    public GameObject Paper;

    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(Paper, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }
}
