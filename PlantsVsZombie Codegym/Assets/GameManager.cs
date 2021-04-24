using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Drag_Plant;
    public GameObject CurrContainer;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlacePlant()
    {
        if(Drag_Plant!=null && CurrContainer !=null)
        {
            Instantiate(Drag_Plant.GetComponent<PlantDragging>().card.Planted_Pea, CurrContainer.transform);
            CurrContainer.GetComponent<PlantContainer>().isFull = true;
        }
    }
}
