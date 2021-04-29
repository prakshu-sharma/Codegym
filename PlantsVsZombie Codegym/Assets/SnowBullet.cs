using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class SnowBullet : MonoBehaviour
{
    public float movementSp;
    public int DamageVal = 100;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementSp, 0, 0));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<ZombieController>().RecieveDamage(DamageVal);
            collision.gameObject.GetComponent<ZombieController>().SpeedChange();
            Destroy(this.gameObject);
        }
    }
}
