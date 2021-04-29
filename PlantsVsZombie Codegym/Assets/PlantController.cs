using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public List<GameObject> zombies;
    public GameObject toAttack;
    public float attackCooldown;
    private float AttackTime;
    public GameObject bullets;
    public bool isAttacking;
    public int Damagevalue;
    public int Health;

    // Update is called once per frame
    private void Update()
    {
        if (zombies.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
        }
        else if (zombies.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }
        if (zombies.Count>0 && AttackTime <= Time.time)
            {
                GameObject bulletinstance= Instantiate(bullets, transform);
            //bulletinstance.GetComponents<Bullet>().DamageValue = Damagevalue;
                AttackTime = Time.time + attackCooldown;
            }
    }
    public void RecieveDamage(int Damage)
    {
        if (Health <= Damage)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Health = Health - Damage;
        }
    }
}
