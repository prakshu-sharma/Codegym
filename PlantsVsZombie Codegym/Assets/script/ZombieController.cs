using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    //public Vector3 FinalDestination;
    public int Health;
    public int Damage;
    public float movementSpeed;
    private bool isStopped;
    public int DamageValue;
    public float DamageCooldown;
    private gameover go;
    public void Start()
    {
        go = gameover.instance;
    }
    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(new Vector3(movementSpeed * Time.timeScale * -1, 0, 0));
            Vector3 position_Zom = transform.position;
            //gameObject.GetComponentInParent<s>
            //Debug.Log(gameObject.GetComponent<Spawn_points>().Destination.x);
            if (position_Zom.x <= transform.parent.GetComponent<Spawn_points>().Destination.x)
            {
                //   GameObject.Find("GameOver").GetComponent<gameover>().GameOver();
                go.GameOver();

            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null)
        {
            isStopped = false;
        }
        else
        {
            collision.gameObject.GetComponent<PlantController>().RecieveDamage(DamageValue);
            yield return new WaitForSeconds(DamageCooldown);
            StartCoroutine(Attack(collision));
        }
    }
    public void RecieveDamage(int Damage)
    {
        if (Health <= Damage)
        {
            transform.parent.GetComponent<Spawn_points>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Health = Health - Damage;
        }
    }

    public void SpeedChange()
    {
        movementSpeed = movementSpeed * 3 / 4;
    }


}
