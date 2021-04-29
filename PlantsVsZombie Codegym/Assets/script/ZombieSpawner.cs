using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public List<Zombie> zombies;
    public List<GameObject> zombiesPrefabs;
    private void Update()
    {
       // Debug.Log(Time.time);
        foreach(Zombie zombie in zombies)
        {
            if(zombie.isSpwaned == false  && zombie.spawnTime <Time.time)
            {
                if (zombie.RandomSpawn)
                {
                    zombie.Spawner = Random.Range(0, transform.childCount);
                }
                GameObject zombieInstance = Instantiate( zombiesPrefabs[(int)zombie.zombieType] , transform.GetChild(zombie.Spawner).transform);
                transform.GetChild(zombie.Spawner).GetComponent<Spawn_points>().zombies.Add(zombieInstance);
                //zombieInstance.GetComponent<ZombieController>().FinalDestination = transform.GetChild(zombie.Spawner).GetComponent<Spawn_points>().Destination;
                zombie.isSpwaned = true;
            }
        }
    }
    
}
