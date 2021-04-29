using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerPlant : MonoBehaviour
{
    public float SunTime;
    //public int Health;
    private SunPoints sunman;
    //public List<GameObject> zombies;

    //private GameManager gameManager;


    // Update is called once per frame
    public void Start()
    {
        sunman = SunPoints.instance;
    }

    void Update()
    {
        if(SunTime <= Time.time)
        {
            //sunman.sunPoint_value += 50;
            sunman.GetComponent<SunPoints>().sunPoint_value += 50;
            //GetComponent<SunPoints>().sunPoint_value += 50;
            //GameObject.Find("canvas").GetComponent<SunPoints>.sunPoint_value += 50;
            SunTime = SunTime + Time.time;
        }
    }
    /*public void RecieveDamage(int Damage)
    {
        if (Health <= Damage)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Health = Health - Damage;
        }
    }*/
}
