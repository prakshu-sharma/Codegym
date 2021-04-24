using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Zombie 
{
    public int spawnTime;
    public ZombieType zombieType;
}
public enum ZombieType
{
    Zombie_Basic,
    Zombie_Cone,
    Zombie_Bucket
}
