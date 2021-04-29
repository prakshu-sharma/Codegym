using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantContainer : MonoBehaviour
{
    public bool isFull;
    public GameManager gameManger;
    public Image BackGroundImage;
    public Spawn_points spwanpoint;
    public void Start()
    {
        gameManger = GameManager.instance;
    }
    public void OnTriggerEnter2D(Collider2D Collision)
    { 
        if(gameManger.Drag_Plant !=null && isFull==false)
        {
            gameManger.CurrContainer = this.gameObject;
            BackGroundImage.enabled = true;

        }
    }

    public void OnTriggerExit2D(Collider2D Collision)
    {
        gameManger.CurrContainer = null;
        BackGroundImage.enabled = false;
    }

}
